using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;
using System.Web.Services;

namespace aspSajt.Front
{
    public partial class books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            OpKnjigaSelect knjiga = new OpKnjigaSelect();
            //knjiga.Kriterijum = new KriterijumKnjiga();
            //knjiga.Kriterijum.Get_cena = 31; //samo da bih probao da li ce da vrati svuda
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knjiga);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {

                BookList.DataSource = obj.DbItems;
                BookList.DataBind();
            }

            ZanrSelect znr = new ZanrSelect();
            OperacijaRezultat obj2 = OperationManager.Singleton.izvrsiOperaciju(znr);

            if ((obj2 == null) || (!obj2.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj2.DbItems;
                ZanrDb[] zanr = items.Cast<ZanrDb>().ToArray();
                if (!Page.IsPostBack)
                {
                    ddlZanr.DataTextField = "naziv";
                    ddlZanr.DataValueField = "naziv";
                    ddlZanr.DataSource = zanr;
                    ddlZanr.DataBind();
                }

            }
        }

        protected void btnOcena_Click(object sender, EventArgs e)
        {

        }

        protected void BookList_PagePropertiesChanged(object sender, EventArgs e)
        {
            BookList.DataBind();
        }

        protected void ddlZanr_SelectedIndexChanged(object sender, EventArgs e)
        {

            string vrednost = ddlZanr.SelectedValue;

            OpKnjigaSelect knjsort = new OpKnjigaSelect();
            if (vrednost != "0")
            {
                knjsort.Kriterijum = new KriterijumKnjiga();
                knjsort.Kriterijum.Zanr = vrednost;
            }



            OperacijaRezultat objsort = OperationManager.Singleton.izvrsiOperaciju(knjsort);

            DbItem[] itemsort = objsort.DbItems;
            KnjigaDb[] knj = itemsort.Cast<KnjigaDb>().ToArray();
            if (knj.Count() == 0)
            {
                this.DataPager1.SetPageProperties(0, DataPager1.PageSize, false);

                BookList.DataSource = knj;
                BookList.DataBind();
                noBooks.Visible = true;
            }
            else {
                noBooks.Visible = false;
                this.DataPager1.SetPageProperties(0, DataPager1.PageSize, false);

                BookList.DataSource = knj;
                BookList.DataBind();
            }




        }

        [WebMethod]
        public static string ajaxOceni(string ocena, string id)
        {
            InsertOcena ocn = new InsertOcena();
            ocn.Dbocena = new DbOcena();
            ocn.Dbocena.Ocena = Convert.ToDouble(ocena);
            ocn.Dbocena.Id_knjiga = Convert.ToInt32(id);
            ocn.Dbocena.Id_korisnik = Convert.ToInt32(HttpContext.Current.Session["id_korisnik"]);

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ocn);

            return "Success";


        }

        protected void BookList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item == null)
                return;

            Button btnRate = (Button)e.Item.FindControl("btnRate");
            Button btnAdd = (Button)e.Item.FindControl("btnAdd");
            Panel alr = (Panel)e.Item.FindControl("alreadyPanel");
            if (Session["uloga"] == null || (String)Session["uloga"] == "adm")
            {
                btnRate.Visible = false;
                btnAdd.Visible = false;
            }



            int Id_korisnik = Convert.ToInt32(HttpContext.Current.Session["id_korisnik"]);
            int Id_knjiga = Convert.ToInt32(btnRate.CommandArgument);

            OcenaSelect ocena = new OcenaSelect();
            ocena.ocenaKriterijum = new OcenaKriterijum();
            ocena.ocenaKriterijum.Id_knjiga = Id_knjiga;
            ocena.ocenaKriterijum.Id_korisnik = Id_korisnik;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ocena);

            DbItem[] items = obj.DbItems;

            if (items.Count() == 0)
            {

            }
            else
            {
                btnRate.CssClass = "btn btn-warning";
                btnRate.Enabled = false;
                btnRate.Text = "Glasali ste!";
            }


            if (Session["uloga"] == null || (String)Session["uloga"] == "adm")
            {
                btnRate.Visible = false;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string text = tbSearch.Text;
            OpKnjigaSelect knjiga = new OpKnjigaSelect();
            knjiga.Kriterijum = new KriterijumKnjiga();
            knjiga.Kriterijum.Knjiga_pretraga = text;
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knjiga);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }

            else {
                if (obj.DbItems.Count() == 0)
                {
                    noBooks.Visible = true;
                }
                else
                {
                    noBooks.Visible = false;
                }
                this.DataPager1.SetPageProperties(0, DataPager1.PageSize, false);
                BookList.DataSource = obj.DbItems;
                BookList.DataBind();
                ddlZanr.SelectedValue = "0";
            }

          
                
            }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);
            int id_kor = Convert.ToInt32(Session["id_korisnik"]);

            KorpaInsert krp = new KorpaInsert();
            krp.Korpa = new DbKorpa();
            krp.Korpa.Id_knjiga = id;
            krp.Korpa.Id_korisnika = id_kor;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(krp);

            if (obj.Status)
            {
                Session["osvezena"] = " je osvezena!";
                Response.Redirect("korpa.aspx");
            }
        }

        //protected void BookList_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{
        //    int Id_korisnik = Convert.ToInt32(HttpContext.Current.Session["id_korisnik"]);
        //    int Id_knjiga = Convert.ToInt32(e.CommandArgument);

        //    OcenaSelect ocena = new OcenaSelect();
        //    ocena.ocenaKriterijum = new OcenaKriterijum();
        //    ocena.ocenaKriterijum.Id_knjiga = Id_knjiga;
        //    ocena.ocenaKriterijum.Id_korisnik = Id_korisnik;

        //    OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(ocena);

        //    DbItem[] items = obj.DbItems;

        //    if(items.Count() == 0)
        //    {
        //        Response.Redirect("http://www.google.com");
        //    }
        //    else
        //    {
        //        Response.Redirect("http://www.facebook.com");
        //    }


        //}
    }
    }
