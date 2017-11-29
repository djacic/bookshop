using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;

namespace aspSajt
{
    public partial class booksgenres : System.Web.UI.Page
    {
        public void loadData()
        {
            if ((string)Session["uloga"] != "adm")
            {
                Response.Redirect("~/Front/books.aspx");
            }
            ZanrSelect genre = new ZanrSelect();
            OperacijaRezultat objx = OperationManager.Singleton.izvrsiOperaciju(genre);
            if ((objx == null) || (!objx.Status))
            {
                infoLabel.Text = objx.Poruka;
            }
            else
            {
                DbItem[] nizx = objx.DbItems;
                ZanrDb[] zanrovi = nizx.Cast<ZanrDb>().ToArray();

                zanrGrid.DataSource = zanrovi;
                zanrGrid.DataBind();
            }

            AutorSelect author = new AutorSelect();
            OperacijaRezultat objy = OperationManager.Singleton.izvrsiOperaciju(author);
            if ((objy == null) || (!objy.Status))
            {
                infoLabel.Text = objy.Poruka;
            }
            else
            {
                DbItem[] nizy = objy.DbItems;
                AutorDb[] autori = nizy.Cast<AutorDb>().ToArray();

                autorGrid.DataSource = autori;
                autorGrid.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();

        }

        protected void zanrObrisiBtn_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            ZanrDelete del = new ZanrDelete();
            del.Id_zanr = id;


            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(del);

            
                loadData();
           

        }

        protected void btnDodajZanr_Click(object sender, EventArgs e)
        {
            string zanr = tbDodajZanr.Text;

            ZanrInsert ins = new ZanrInsert();
            ins.Zanr = new ZanrDb { };
            ins.Zanr.Naziv = zanr;
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ins);
            if ((obj == null) || (!obj.Status))
            {
                infoLabel.Text = obj.Poruka;
            }
            else
            {
                loadData();
            }
        }

        protected void btnDodajAutora_Click(object sender, EventArgs e)
        {
            string ime = tbDodajIme.Text;
            string prezime = tbDodajPrezime.Text;
            string bio = tbDodajBiografiju.Text;

            AutorInsert ins = new AutorInsert();
            ins.Autor = new AutorDb { };
            ins.Autor.Ime = ime;
            ins.Autor.Prezime = prezime;
            ins.Autor.Biografija = bio;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ins);
            if ((obj == null) || (!obj.Status))
            {
                infoLabel2.Text = obj.Poruka;
            }
            else
            {
                loadData();
            }
        }

        protected void autorObrisiBtn_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            AutorDelete del = new AutorDelete();
            del.Id_autor = id;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(del);

            loadData();
        }


    }
}