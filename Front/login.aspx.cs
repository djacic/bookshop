using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;
using System.Web.Security;

namespace aspSajt.Front
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["registered"] != "")
            {
                feedLabel.Text = (string)Session["registered"];
                Session.Remove("registered");
            }
            if ((string)Session["uloga"] == "adm")
            {
                Response.Redirect("~/admin.aspx");
            }
            else if ((string)Session["uloga"] == "reg")
            {
                Response.Redirect("~/Front/books.aspx");
            }
            else
            {

            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Logovanje log = new Logovanje();
            log.Login = new LoginOperation();
            log.Login.Username = tbUsername.Text;
            log.Login.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(tbPassword.Text, "MD5"); 

            OperacijaRezultat op = OperationManager.Singleton.izvrsiOperaciju(log);

            DbItem[] items = op.DbItems;
            UserDb[] niz = items.Cast<UserDb>().ToArray();

            if (niz.Length != 0 && niz[0].Id_uloga==1)
            {
                Session["uloga"] = "adm";
                Session["username"] = niz[0].Username;
                Session["id_korisnik"] = niz[0].Id_korisnik;
                Response.Redirect("~/admin.aspx");
            }
            else if(niz.Length != 0 && niz[0].Id_uloga == 2)
            {
                Session["uloga"] = "reg";
                Session["username"] = niz[0].Username;
                Session["id_korisnik"] = niz[0].Id_korisnik;
                Response.Redirect("~/Front/books.aspx");
            }
            else
            {
                feedLabel.Text = "Really?";
            }
        }
    }
}