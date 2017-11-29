using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;

namespace aspSajt.Front
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["uloga"] == "adm")
            {
                Response.Redirect("home.aspx");
            }

         
        }

        protected void btnKontakt_Click(object sender, EventArgs e)
        {
            KontaktInsert knt = new KontaktInsert();
            knt.Kontakti = new KontaktDb();
            knt.Kontakti.Ime = tbIme.Text;
            knt.Kontakti.Email = tbMail.Text;
            knt.Kontakti.Naslov = tbNaslov.Text;
            knt.Kontakti.Poruka = tbPoruka.Text;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knt);

            Session["poruka"] = "Vasa poruka je uspesno poslata!";
            if ((String)Session["poruka"] != "")
            {
                feedLabel.Text = (String)Session["poruka"];
                tbIme.Text = "";
                tbPoruka.Text = "";
                tbNaslov.Text = "";
                tbPoruka.Text = "";
                Session.Remove("poruka");
            }
        }
    }
}