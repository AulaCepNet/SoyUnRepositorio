using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

//Espais de noms necessaris per utilitzar els usuaris
using System.Web.Security;


public partial class Rols : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelUnRol.Visible = false;
            PanelLlistaRols.Visible = true;
            cargarolsGrid();
           
        }

    }

    private void cargarolsGrid()
    {
        lblmensagesRols.Visible = false;
        lblmensagesRols.Text = "";
        String[] roles = Roles.GetAllRoles();

        ArrayList aTotRols = new ArrayList();

        foreach (String rol in roles)
        {
            Rol addRol = new Rol();
            addRol.NomRol = rol;
            aTotRols.Add(addRol);
        }

        dgvRoles.Columns.Clear();
        //Inserir una columna de tipus CommandField per esborrar:
        CommandField cf = new CommandField();
        cf.ButtonType = ButtonType.Image;
        cf.DeleteImageUrl = "~/Imatges/remove_user_32.png";
        cf.ShowDeleteButton = true;
        cf.ControlStyle.CssClass = "columnasBotonDGV";
        dgvRoles.Columns.Add(cf);

        //Inserir una columna de tipus CommandField per seleccionar:
        CommandField cfs = new CommandField();
        cfs.ButtonType = ButtonType.Image;
        cfs.SelectImageUrl = "~/Imatges/edit_user_32.png";

        cfs.ShowSelectButton = true;
        cfs.ControlStyle.CssClass = "columnasBotonDGV";
        dgvRoles.Columns.Add(cfs);

        //Inserir una columna de tipus BoundField pel nom d’usuari:
        BoundField bf = new BoundField();

        bf.HeaderText = "Rol";
       bf.DataField = "NomRol";
        bf.ControlStyle.CssClass = "columnasTextDGV";
        dgvRoles.Columns.Add(bf);



        //Fer que la font de dades de la gridview sigui l’ArrayList i fer que es mostri a la gridview
        dgvRoles.DataSource = aTotRols;
        dgvRoles.DataBind(); // Es necesario para bidenar
    }

    protected void imgAddRol_Click(object sender, ImageClickEventArgs e)
    {
        PanelUnRol.Visible = true;
        lblTituloPanelRol.Text = "Alta rol";
        ArrayList aUsers = cargaUsuarios();
        lstPosiibles.DataSource = aUsers;
        lstPosiibles.DataBind();
        lstAsignats.Items.Clear();
        txtNomRol.Text = "";
    }

    private void ponevisibleAltaRol()
    {
       

    }

    private ArrayList cargaUsuarios(){

        ArrayList aTotstUsers = new ArrayList();

        //Pilla todos los usarios y hago un bucle donde creo el usuario y lo añado a la arrailist
        MembershipUserCollection users = Membership.GetAllUsers();

        foreach (MembershipUser user in users)
        {
            Usuari usu = new Usuari();
            usu.NomUsuari = user.UserName;  //con el user de "MembershipUser" pudeo conseuir el username y email
            usu.Email = user.Email;

            //El profilecoommon es el perfl unico de un user. Se consguigue con un metodo estatido de 
            //profile el GetProfile(Username que he obtenido antees)
            ProfileCommon perfil = Profile.GetProfile(user.UserName);
            usu.Cognoms = perfil.Cognoms;
            usu.Nom = perfil.Nom;

            aTotstUsers.Add(usu.NomUsuari);


        }

        return aTotstUsers;
    }


    private ArrayList cargaUsuarios(String[] lista_asignats)
    {

        ArrayList aTotstUsers = new ArrayList();
        ArrayList aTotstUsersFiltro = new ArrayList();

        //Pilla todos los usarios y hago un bucle donde creo el usuario y lo añado a la arrailist
        MembershipUserCollection users = Membership.GetAllUsers();
      

        foreach (MembershipUser user in users)
        {
            Usuari usu = new Usuari();
            usu.NomUsuari = user.UserName;  //con el user de "MembershipUser" pudeo conseuir el username y email
            usu.Email = user.Email;

            //El profilecoommon es el perfl unico de un user. Se consguigue con un metodo estatido de 
            //profile el GetProfile(Username que he obtenido antees)
            ProfileCommon perfil = Profile.GetProfile(user.UserName);
            usu.Cognoms = perfil.Cognoms;
            usu.Nom = perfil.Nom;

            aTotstUsers.Add(usu.NomUsuari);
        }
        Boolean estaAsignat = false;
        for (int i = 0; i < aTotstUsers.Count; i++)
        {
            estaAsignat = false;
            for (int a = 0; a < lista_asignats.Length; a++)
            {
               
                String usu1 = aTotstUsers[i].ToString();
                String usu2 = lista_asignats[a].ToString();
                if (aTotstUsers[i].ToString() == lista_asignats[a].ToString())
                {
                    estaAsignat = true;
                }
            }
            if (!estaAsignat)
            {
                aTotstUsersFiltro.Add(aTotstUsers[i].ToString());
            }
        }

        return aTotstUsersFiltro;
    }

    protected void bttraer_Click(object sender, EventArgs e)
    {
        int[] indicesSelec = lstPosiibles.GetSelectedIndices();

        for (int i = 0; i < indicesSelec.Length; i++)
        {
            int index = indicesSelec[i];
            String Item = lstPosiibles.Items[index].Text;
            lstAsignats.Items.Add(Item);
        }

        for (int i = indicesSelec.Length-1; i >=0; i--)
        {
            lstPosiibles.Items.RemoveAt(i);
        }

    }
    protected void btpasar_Click(object sender, EventArgs e)
    {
        int[] indicesSelec = lstAsignats.GetSelectedIndices();

        for (int i = 0; i < indicesSelec.Length; i++)
        {
            int index = indicesSelec[i];
            String Item = lstAsignats.Items[index].Text;
            lstPosiibles.Items.Add(Item);
        }

        for (int i = indicesSelec.Length - 1; i >= 0; i--)
        {
            lstAsignats.Items.RemoveAt(i);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        PanelUnRol.Visible = false;
    }
    protected void imgAccept_Click(object sender, ImageClickEventArgs e)
    {
        if (lblTituloPanelRol.Text == "Modificació rol")
        {
            
            String[] usersInrol = Roles.GetUsersInRole(txtNomRol.Text);
            //Roles.Remove
            if (Roles.GetUsersInRole(txtNomRol.Text).Length > 0)
            {
                Roles.RemoveUsersFromRole(Roles.GetUsersInRole(txtNomRol.Text), txtNomRol.Text);
            }
                String[] arraiAsigs = new String[lstAsignats.Items.Count];


            for (int i = 0; i < lstAsignats.Items.Count; i++)
            {
                Roles.AddUserToRole(lstAsignats.Items[i].Value, txtNomRol.Text);
            }
            PanelUnRol.Visible = false;
            PanelLlistaRols.Visible = true;
            cargarolsGrid();
        }
        else  //Crea uno nuevo
        {

            if (!Roles.RoleExists(txtNomRol.Text))
            {
                
                Roles.CreateRole(txtNomRol.Text);
                String[] arraiAsigs = new String[lstAsignats.Items.Count];
                for (int i = 0; i < lstAsignats.Items.Count; i++)
                {
                    Roles.AddUserToRole(lstAsignats.Items[i].Value, txtNomRol.Text);
                }
                PanelUnRol.Visible = false;
                PanelLlistaRols.Visible = true;
                cargarolsGrid();
            }
            else
            {
                lblmensagesRols.Visible = true;
                lblmensagesRols.Text = "Rol existente";
            }
        }

     
    }
    protected void dgvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String rolselect = dgvRoles.Rows[e.RowIndex].Cells[2].Text;

        if (Roles.GetUsersInRole(rolselect).Length == 0)
        {
            Roles.DeleteRole(rolselect);
            PanelUnRol.Visible = false;
            PanelLlistaRols.Visible = true;
            cargarolsGrid();
        }
        else
        {
            lblmensagesRols.Visible = true;
            lblmensagesRols.Text = "El rol tiene usuarios asignados";
        }
    }
    protected void dgvRoles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        String rolselect= dgvRoles.Rows[e.NewSelectedIndex].Cells[2].Text;
        PanelUnRol.Visible = true;
        lblTituloPanelRol.Text = "Modificació rol";
        txtNomRol.Text = rolselect;
        lstAsignats.DataSource = Roles.GetUsersInRole(rolselect);
        lstPosiibles.DataSource = cargaUsuarios(Roles.GetUsersInRole(rolselect));
        lstAsignats.DataBind();
        lstPosiibles.DataBind();
    }
}