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
    public partial class front : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {


            MeniSelect meni = new MeniSelect();
            meni.Kriterijum = new MeniKriterijum();
            if (Session["uloga"] == null)
            {
                
                meni.Kriterijum.Uloga = "nereg";
            }
            else { meni.Kriterijum.Uloga = (string)Session["uloga"]; }
           
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(meni);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                MeniDb[] menus = items.Cast<MeniDb>().ToArray();

               
                MenuList.DataSource = menus;
                MenuList.DataBind();
            }
        }
    }
}