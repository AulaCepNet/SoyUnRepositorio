using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Espais de noms necessaris per utilitzar els usuaris
using System.Web.Security;
public partial class Inici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            return 1;
        }
    }
    protected void btnConectar_Click(object sender, ImageClickEventArgs e)
    {
        if (Membership.ValidateUser(txtusuari.Text, txtpass.Text))
        {
          //  FormsAuthentication.SetAuthCookie(txtusuari.Text, false);

            FormsAuthentication.RedirectFromLoginPage(txtusuari.Text, false);
        }
        else
        {
            lblErrors.Text = "Usuari o contrasenya incorrecte";
        }
    }
}
