using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;
using System.Web.Security;

namespace aspSajt
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["uloga"] != "adm")
            {
                Response.Redirect("~/Front/books.aspx");
            }
            ifEmpty.Text = "Nothing to do here :(";
            ifEmpty.Visible = false;
            insertPanel.Visible = false;
            KorisnikSelect kor = new KorisnikSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(kor);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                UserDb[] usr = items.Cast<UserDb>().ToArray();
                if (usr.Count() == 0) ifEmpty.Visible = true;


                userGrid.DataSource = usr;
                userGrid.DataBind();

                UlogaSelect usrsel = new UlogaSelect();
                OperacijaRezultat usrobj = OperationManager.Singleton.izvrsiOperaciju(usrsel);

                if (!IsPostBack)
                {
                    odabirUloge.DataTextField = "naziv";
                    odabirUloge.DataValueField = "id_uloga";
                    odabirUloge.DataSource = usrobj.DbItems;
                    odabirUloge.DataBind();
                }
                



            }
        }

        protected void userDeleteBtn(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            KorisnikDelete delusr = new KorisnikDelete();
            delusr.Id_korisnik = id;

            OperacijaRezultat delobj = OperationManager.Singleton.izvrsiOperaciju(delusr);

            KorisnikSelect usrsel = new KorisnikSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(usrsel);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                UserDb[] users = items.Cast<UserDb>().ToArray();
                if (users.Count() == 0) ifEmpty.Visible = true;


                userGrid.DataSource = users;
                userGrid.DataBind();

            }
        }

        protected void prikaziUsersPanel(object sender, EventArgs e)
        {
            insertPanel.Visible = true;

            KorisnikSelect usr = new KorisnikSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(usr);



            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                UserDb[] users = items.Cast<UserDb>().ToArray();



            }
        }

        protected void dodajUser_Click(object sender, EventArgs e)
        {

            string username = tbUsername.Text;
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(tbPassword.Text, "MD5");
            string email = tbEmail.Text;
            int id_uloga = Convert.ToInt32(odabirUloge.SelectedItem.Value);
            KorisnikInsert ins = new KorisnikInsert();
            ins.User = new UserDb { };
            ins.User.Id_uloga = id_uloga;
            ins.User.Username = username;
            ins.User.Password = password;
            ins.User.Email = email;

            
                OperacijaRezultat rezultat = OperationManager.Singleton.izvrsiOperaciju(ins);
                if ((rezultat == null) || (!rezultat.Status))
                {
                    return;
                }
                else
                {
                    DbItem[] items = rezultat.DbItems;
                    UserDb[] users = items.Cast<UserDb>().ToArray();
                    if (users.Count() > 0) ifEmpty.Visible = false;

                    userGrid.DataSource = users;
                userGrid.DataBind();
                }
            }

        protected void zatvoriPanel_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
        }
    }
    }
