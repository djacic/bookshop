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
    public partial class korpa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["osvezena"] != null)
            {
                jePrazna.Text = (String)Session["osvezena"];
                Session.Remove("osvezena");
            }
            if ((string)Session["uloga"] != "reg")
            {
                Response.Redirect("~/Front/books.aspx");
            }

            KorpaSelect sel = new KorpaSelect();
            sel.Korpa = new DbKorpa();
            sel.Korpa.Id_korisnika = Convert.ToInt32(Session["id_korisnik"]);
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(sel);

            if (obj.Status)
            {
                if (obj.DbItems.Count() == 0)
                {
                    jePrazna.Text = " je prazna!";
                }
                else
                {
                    korpaGrid.DataSource = obj.DbItems;
                    korpaGrid.DataBind();
                }
            }
            
        }

        protected void ukloniIzKorpe_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            KorpaDelete korpa = new KorpaDelete();
            korpa.Korpa = new DbKorpa();
            korpa.Korpa.Id_knjiga = id;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(korpa);
            if(obj.Status)
            {
                KorpaSelect sel = new KorpaSelect();
                sel.Korpa = new DbKorpa();
                sel.Korpa.Id_korisnika = Convert.ToInt32(Session["id_korisnik"]);
                OperacijaRezultat obj2 = OperationManager.Singleton.izvrsiOperaciju(sel);

                if (obj2.Status)
                {
                    if (obj2.DbItems.Count() == 0)
                    {
                        jePrazna.Text = " je prazna!";

                        korpaGrid.DataSource = obj2.DbItems;
                        korpaGrid.DataBind();
                    }
                    else
                    {
                        korpaGrid.DataSource = obj2.DbItems;
                        korpaGrid.DataBind();
                    }
                }
            }
            else
            {
                jePrazna.Text = obj.Poruka;
            }

          
        }
    }
}