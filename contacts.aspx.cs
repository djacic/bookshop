using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;
using System.Net.Mail;
using System.Net;


namespace aspSajt
{
    public partial class contacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["uloga"] != "adm")
            {
                Response.Redirect("~/Front/books.aspx");
            }

            ifEmpty.Text = "Nothing to do here :(";
            ifEmpty.Visible = false;
            respondPanel.Visible = false;
            KontaktSelect kontakt = new KontaktSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(kontakt);


            if ((obj == null) || (!obj.Status))
            {
                ifEmpty.Visible = true; ifEmpty.Text = obj.Poruka;
            }
            DbItem[] items = obj.DbItems;
            KontaktDb[] kontakts = items.Cast<KontaktDb>().ToArray();
            if (kontakts.Count() > 0) ifEmpty.Visible = false;

            contactsGrid.DataSource = kontakts;
            contactsGrid.DataBind();

        }

        protected void contactsDeleteBtn(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            KontaktDelete kontakt = new KontaktDelete();
            kontakt.Id_kontakt = id;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(kontakt);


            KontaktSelect kn = new KontaktSelect();
            OperacijaRezultat obj2 = OperationManager.Singleton.izvrsiOperaciju(kn);
            DbItem[] items = obj2.DbItems;
            KontaktDb[] kon = items.Cast<KontaktDb>().ToArray();
            if (kon.Count() == 0) ifEmpty.Visible = true;
            contactsGrid.DataSource = kon;
            contactsGrid.DataBind();

        }

        protected void contactsRespondBtn(object sender, EventArgs e)
        {
            respondPanel.Visible = true;
            Button taster = (Button)sender;
            KontaktSelect kontakt = new KontaktSelect();
            kontakt.kontaktkriterjum = new KontaktKriterijum();
            kontakt.kontaktkriterjum.id_kontakt = Convert.ToInt32(taster.CommandArgument);


            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(kontakt);

            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                KontaktDb[] niz = items.Cast<KontaktDb>().ToArray();
                emailPrenos.Text = niz[0].Email;
                imePrenos.Text = niz[0].Ime;
                tbKome.Text = emailPrenos.Text;
                tbKome.Enabled = false;


            }
        }


        protected void dodajRespond_Click(object sender, EventArgs e)
        {
            string poruka = tbPoruka.Text;
            string email = emailPrenos.Text;
            string ime = imePrenos.Text;

            var fromAddress = new MailAddress("milos.djacic.11.14@ict.edu.rs", "Books Shop");
            var toAddress = new MailAddress(email, ime);
            string subject = "Admin Response";
            string body = poruka;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("milos.djacic.11.14@ict.edu.rs", "lozinka_ovde")

            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                smtp.Send(message);
            }
            message.Visible = true;





            KontaktSelect op = new KontaktSelect();
                OperacijaRezultat rezultat = OperationManager.Singleton.izvrsiOperaciju(op);
                DbItem[] items = rezultat.DbItems;
                KontaktDb[] menus = items.Cast<KontaktDb>().ToArray();
                if (menus.Count() > 0) ifEmpty.Visible = false;

                contactsGrid.DataSource = menus;
                contactsGrid.DataBind();





            }
        }
    }
