using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

//Espais de noms necessaris per utilitzar els usuaris
using System.Web.Security;

public partial class Usuaris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelUsuaris.Visible = true;
            PanelUsuari.Visible = false;
            cargausersGrid();
         
        }
    }

    private void cargausersGrid()
    {
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

            aTotstUsers.Add(usu);


        }

        //for (int i = dgvUsers.Columns.Count - 1; i >= 0; i--)
        //{
        //    dgvUsers.Columns.RemoveAt(i);
        //}

        dgvUsers.Columns.Clear();
        //Inserir una columna de tipus CommandField per esborrar:
        CommandField cf = new CommandField();
        cf.ButtonType = ButtonType.Image;
        cf.DeleteImageUrl = "~/Imatges/remove_user_32.png";
        cf.ShowDeleteButton = true;
        cf.ControlStyle.CssClass = "columnasBotonDGV";
        dgvUsers.Columns.Add(cf);

        //Inserir una columna de tipus CommandField per seleccionar:
        CommandField cfs = new CommandField();
        cfs.ButtonType = ButtonType.Image;
        cfs.SelectImageUrl = "~/Imatges/edit_user_32.png";

        cfs.ShowSelectButton = true;
        cfs.ControlStyle.CssClass = "columnasBotonDGV";
        dgvUsers.Columns.Add(cfs);

        //Inserir una columna de tipus BoundField pel nom d’usuari:
        BoundField bf = new BoundField();

        bf.HeaderText = "Nom usuari";
        bf.DataField = "NomUsuari";
        bf.ControlStyle.CssClass = "columnasTextDGV";
        dgvUsers.Columns.Add(bf);

        //Inserir una columna de tipus BoundField per l’email:
        BoundField bfmail = new BoundField();
        bfmail.HeaderText = "Correu";
        bfmail.DataField = "Email";
        bfmail.ControlStyle.CssClass = "columnasTextDGV";
        dgvUsers.Columns.Add(bfmail);


        //Inserir una columna de tipus BoundField pels cognoms:
        BoundField bfcog = new BoundField();
        bfcog.HeaderText = "Cognoms";
        bfcog.DataField = "Cognoms";
        bfcog.ControlStyle.CssClass = "columnasTextDGV";
        dgvUsers.Columns.Add(bfcog);

        //Inserir una columna de tipus BoundField pel nom:
        BoundField bfnom = new BoundField();
        bfnom.HeaderText = "Nom";
        bfnom.DataField = "Nom";
        bfnom.ControlStyle.CssClass = "columnasTextDGV";
        dgvUsers.Columns.Add(bfnom);


        //Fer que la font de dades de la gridview sigui l’ArrayList i fer que es mostri a la gridview
        dgvUsers.DataSource = aTotstUsers;
        dgvUsers.DataBind(); // Es necesario para bidenar
    }

    protected void imgAlta_Click(object sender, ImageClickEventArgs e)
    {
        PanelUsuari.Visible = true;
        PanelUsuaris.Visible = false;
        lbltituoHeader.Text = "Alta d'usuari";
        txtuser.Enabled = true;
        //txtnom.Focus();
        pone_vsibleUsuari();
    }
    private void pone_vsibleUsuari() //pone visible los controles del panelUsuari
    {
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        lblErrorBotonces.Visible = true;
        lbltituoHeader.Visible = true;
        txtcognoms.Visible = true;
        txtconfirm.Visible = true;
        txtcorreo.Visible = true;
        txtnom.Visible = true;
        txtpass.Visible = true;
        txtuser.Visible = true;
        RequiredFieldcognom.Visible = true;
        RequiredMail.Visible = true;
        Requirednom.Visible = true;
        RequiredPass.Visible = true;
        RequiredUser.Visible = true;
        ComparePass.Visible = true;
    }

    private void pone_Invisibleusuari()
    {
        lblErrorBotonces.Visible = false;
        txtpass.Visible = false;
        txtconfirm.Visible = false;
        RequiredPass.Visible = false;
        ComparePass.Visible = false;
    }


    protected void dgvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
          //  MembershipUserCollection deluser = Membership.GetAllUsers();
         // usu.NomUsuari = user.UserName; 
        //ProfileCommon perfil = Profile.GetProfile(user.UserName);
        String userSelect =  dgvUsers.Rows[e.RowIndex].Cells[2].Text;
       // ProfileCommon delUser = Profile.GetProfile(userSelect);
        Membership.DeleteUser(userSelect);
        cargausersGrid();
    }
    protected void dgvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        String userSelect = dgvUsers.SelectedRow.Cells[2].Text;
         ProfileCommon PerfilUser = Profile.GetProfile(userSelect);
         MembershipUser userP = Membership.GetUser(userSelect);
        PanelUsuari.Visible = true;
        PanelUsuaris.Visible = false;
        txtuser.Text = userP.UserName;
        txtcorreo.Text = userP.Email;
        txtcognoms.Text = PerfilUser.Cognoms;
        txtnom.Text = PerfilUser.Nom;
        lbltituoHeader.Text = "Modificació d’usuari";
        txtuser.Enabled = false;
        //txtnom.Focus();
        pone_Invisibleusuari();
    }
    protected void imgAceptar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtpass.Visible)
        {
            if (Membership.FindUsersByName(txtuser.Text).Count == 0)
            {
                Membership.CreateUser(txtuser.Text, txtpass.Text, txtcorreo.Text);
                ProfileCommon altaUser = Profile.GetProfile(txtuser.Text);
                altaUser.Nom = txtnom.Text;
                altaUser.Cognoms = txtcognoms.Text;
                altaUser.Save();

                cargausersGrid();
                PanelUsuaris.Visible = true;
                PanelUsuari.Visible = false;
            }
            else
            {
                lblErrorBotonces.Text = "El usuario ya existe";
            }

        }

        else
        {
            String userSelect = dgvUsers.SelectedRow.Cells[2].Text;
            ProfileCommon PerfilUser = Profile.GetProfile(userSelect);
            MembershipUser userP = Membership.GetUser(userSelect);
            userP.Email = txtcorreo.Text;
            PerfilUser.Cognoms = txtcognoms.Text;
            PerfilUser.Nom = txtnom.Text;
            PerfilUser.Save();
            cargausersGrid();
            PanelUsuaris.Visible = true;
            PanelUsuari.Visible = false;
        }

    }
    protected void imgCancel_Click(object sender, ImageClickEventArgs e)
    {
        PanelUsuaris.Visible = true;
        PanelUsuari.Visible = false;
    }
}