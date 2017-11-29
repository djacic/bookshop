
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.DataLayer;
using aspSajt.BusinessLayer;

namespace aspSajt
{
    public partial class menus : System.Web.UI.Page
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
            MeniSelect meni = new MeniSelect();
            meni.Kriterijum = new MeniKriterijum();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(meni);


            if ((obj == null) || (!obj.Status))
            {
                ifEmpty.Visible = true; ifEmpty.Text = obj.Poruka;
            }
            DbItem[] items = obj.DbItems;
            MeniDb[] menus = items.Cast<MeniDb>().ToArray();
            if (menus.Count() > 0) ifEmpty.Visible = false;

            menuGrid.DataSource = menus;
            menuGrid.DataBind();

        }

        protected void menuDeleteBtn(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            MeniDelete meni = new MeniDelete();
            meni.Kriterijum = new MeniKriterijum();
            meni.Id_meni = id;

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(meni);

            MeniSelect mn = new MeniSelect();
            mn.Kriterijum = new MeniKriterijum();
            OperacijaRezultat obj2 = OperationManager.Singleton.izvrsiOperaciju(mn);
            DbItem[] items = obj2.DbItems;
            MeniDb[] menu = items.Cast<MeniDb>().ToArray();
            if (menu.Count() == 0) ifEmpty.Visible = true;
            menuGrid.DataSource = menu;
            menuGrid.DataBind();

        }

        protected void prikaziInsertPanel(object sender, EventArgs e)
        {
            insertPanel.Visible = true;

            MeniSelect meni = new MeniSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(meni);



            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                MeniDb[] menus = items.Cast<MeniDb>().ToArray();



            }
        }

        protected void dodajMeni_Click(object sender, EventArgs e)
        {
            string naslov = naslovBtn.Text;
            string url = urlBtn.Text;
            MeniInsert op = new MeniInsert();
            op.Meni = new MeniDb { };
            op.Kriterijum = new MeniKriterijum();
            op.Meni.Naslov = naslov;
            op.Meni.Url = url;
            OperacijaRezultat rezultat = OperationManager.Singleton.izvrsiOperaciju(op);
            DbItem[] items = rezultat.DbItems;
            MeniDb[] menus = items.Cast<MeniDb>().ToArray();
            if (menus.Count() > 0) ifEmpty.Visible = false;

            menuGrid.DataSource = menus;
            menuGrid.DataBind();
            foreach (ListItem item in this.chbList.Items)
            {

                

                if (item.Selected)
                {
                    
                    
                        MeniUlogaInsert mn = new MeniUlogaInsert();
                        mn.MeniKriterijum = new MeniKriterijum();
                        mn.MeniKriterijum.Uloga = item.Value;

                        OperacijaRezultat rez = OperationManager.Singleton.izvrsiOperaciju(mn);
               
               
                    



                }
       
                
              

            }
           
            
               
             
          



        }

        protected void zatvoriPanel_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
        }
    }
}