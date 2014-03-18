using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Espais de noms necessaris per utilitzar els usuaris
using System.Web.Security;

public partial class MasterPageUsuaris : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page (Load) Y Botó imatge Sortir (Clic) SIN HACER pag.2

            ProfileCommon perfil = Profile.GetProfile(HttpContext.Current.User.Identity.Name);
            //this.Page.User.Identity.name
        lblNomCognoms.Text = perfil.Nom + " " + perfil.Cognoms;
        }
    }
    protected void btnExit_Click(object sender, ImageClickEventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Index.aspx");
    }
}
