using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;

namespace aspSajt.Front
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uloga"] != null)
            {
                Response.Redirect("books.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;

            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(tbPassword.Text, "MD5");

            string email = tbEmail.Text;

            int uloga = 2;

            KorisnikInsert ins = new KorisnikInsert();
            ins.User = new UserDb();
            ins.User.Username = username;
            ins.User.Password = password;
            ins.User.Email = email;
            ins.User.Id_uloga = 2;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ins);

            if (obj.Status)
            {
                Session["registered"] = "Uspesno ste se registrovali. Ulogujte se!";
                Response.Redirect("login.aspx");
            }

          
        }


    }
}