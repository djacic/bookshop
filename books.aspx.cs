using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Services;

namespace aspSajt
{
    public partial class books : System.Web.UI.Page
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
            Panel2.Visible = false;
            OpKnjigaSelect knjiga = new OpKnjigaSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knjiga);


            if ((obj == null) || (!obj.Status))
            {
                ifEmpty.Visible = true; ifEmpty.Text = obj.Poruka;
            }
            else {
                DbItem[] items = obj.DbItems;
                KnjigaDb[] knjige = items.Cast<KnjigaDb>().ToArray();
                if (knjige.Count() == 0) ifEmpty.Visible = true;
                
                
                bookGrid.DataSource = knjige;
                bookGrid.DataBind();

                AutorSelect  aut = new AutorSelect();
                OperacijaRezultat objaut = OperationManager.Singleton.izvrsiOperaciju(aut);

                if (!IsPostBack)
                {
                    odabirAutora.DataTextField = "ime";
                    odabirAutora.DataValueField = "id_autor";
                    odabirAutora.DataSource = objaut.DbItems;
                    odabirAutora.DataBind();
                }
                if (!IsPostBack)
                {
                    updAutor.DataTextField = "ime";
                    updAutor.DataValueField = "id_autor";
                    updAutor.DataSource = objaut.DbItems;
                    updAutor.DataBind();
                }
                ZanrSelect znr = new ZanrSelect();
                OperacijaRezultat objznr = OperationManager.Singleton.izvrsiOperaciju(znr);

                if (!IsPostBack)
                {
                    odabirZanra.DataTextField = "naziv";
                    odabirZanra.DataValueField = "id_zanr";
                    odabirZanra.DataSource = objznr.DbItems;
                    odabirZanra.DataBind();
                }
                if (!IsPostBack)
                {
                    updZanr.DataTextField = "naziv";
                    updZanr.DataValueField = "id_zanr";
                    updZanr.DataSource = objznr.DbItems;
                    updZanr.DataBind();
                }



            }
        }

        protected void bookDeleteBtn(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            OpKnjigaDelete delknjiga = new OpKnjigaDelete();
            delknjiga.Id_knjiga = id;

            OperacijaRezultat delobj = OperationManager.Singleton.izvrsiOperaciju(delknjiga);

            OpKnjigaSelect knjiga = new OpKnjigaSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knjiga);


            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                KnjigaDb[] knjige = items.Cast<KnjigaDb>().ToArray();
                if (knjige.Count() == 0) ifEmpty.Visible = true;


                bookGrid.DataSource = knjige;
                bookGrid.DataBind();

            }}

        protected void prikaziBooksPanel(object sender, EventArgs e)
        {
            insertPanel.Visible = true;

            OpKnjigaSelect knjiga = new OpKnjigaSelect();
            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knjiga);



            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else {
                DbItem[] items = obj.DbItems;
                KnjigaDb[] menus = items.Cast<KnjigaDb>().ToArray();



            }
        }

        protected void dodajKnjigu_Click(object sender, EventArgs e)
        {
           
                string naziv = nazivBtn.Text;
                string opis = opisBtn.Text;
                int cena = Convert.ToInt32(cenaBtn.Text);
                string godina = godinaBtn.Text;
                int zanr = Convert.ToInt32(odabirZanra.SelectedItem.Value);
                int autor = Convert.ToInt32(odabirAutora.SelectedItem.Value);
                if (FileUpload1.HasFile)
                {
                    string sl = FileUpload1.FileName;
                    Bitmap originalBMP = new Bitmap(FileUpload1.FileContent);
                    double origWidth = originalBMP.Width;
                    double origHeight = originalBMP.Height;
                    double sngRatio = origWidth / origHeight;
                    int newHeight = 100;
                    int newWidth = (int) Math.Ceiling(newHeight * sngRatio);
                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);

                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                // Save the new graphic file to the server
                newBMP.Save(Server.MapPath(".") + "//slike//male//" + sl);

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();

                
                

                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//slike//" + sl);
                    string path = "~//slike//" + sl.ToString();
                    OpKnjigaInsert op = new OpKnjigaInsert();
                    op.Knjiga = new KnjigaDb { };
                    op.Knjiga.Naziv = naziv;
                    op.Knjiga.Opis = opis;
                    op.Knjiga.Cena = cena;
                    op.Knjiga.Godina = godina;
                    op.Knjiga.Slika = "slike/" + sl;
                    op.Knjiga.SlikaMala = "slike/male/" + sl;
                    op.Knjiga.Id_zanr = zanr;
                    op.Knjiga.Id_autor = autor;
                    OperacijaRezultat rezultat = OperationManager.Singleton.izvrsiOperaciju(op);
                    if ((rezultat == null) || (!rezultat.Status))
                    {
                        return;
                    }
                    else
                    {
                        DbItem[] items = rezultat.DbItems;
                        KnjigaDb[] knjige = items.Cast<KnjigaDb>().ToArray();
                        if (knjige.Count() > 0) ifEmpty.Visible = false;

                        bookGrid.DataSource = knjige;
                        bookGrid.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sliku izaberi')", true);

                }



        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Button taster = (Button)sender;
            OpKnjigaSelect knj = new OpKnjigaSelect();
            knj.Kriterijum = new KriterijumKnjiga();
            knj.Knjiga = new KnjigaDb { };
            knj.Kriterijum.Id_knjiga = Convert.ToInt32(taster.CommandArgument);


            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knj);

            DbItem[] items = obj.DbItems;
            KnjigaDb[] niz = items.Cast<KnjigaDb>().ToArray();


            updNaziv.Text = niz[0].Naziv;
            updOpis.Text = niz[0].Opis;
            updCena.Text = niz[0].Cena.ToString();
            updGodina.Text = niz[0].Godina;

            updAutor.SelectedValue = niz[0].Id_autor.ToString();
            updZanr.SelectedValue = niz[0].Id_zanr.ToString();
            hiddenUpdate.Text = niz[0].Id_knjiga.ToString();



        }

        protected void updKnjigu_Click(object sender, EventArgs e)
        {
            
            OpKnjigaUpdate knj = new OpKnjigaUpdate();
            knj.Knjiga = new KnjigaDb { };
            knj.Knjiga.Id_knjiga = Convert.ToInt32(hiddenUpdate.Text);
            knj.Knjiga.Naziv = updNaziv.Text;
            knj.Knjiga.Opis = updOpis.Text;
            knj.Knjiga.Cena = Convert.ToInt32(updCena.Text);
            knj.Knjiga.Godina = updGodina.Text;
            if (FileUpload2.HasFile)
            {
                string sl = FileUpload2.FileName;
                Bitmap originalBMP = new Bitmap(FileUpload1.FileContent);
                int origWidth = originalBMP.Width;
                int origHeight = originalBMP.Height;
                int sngRatio = origWidth / origHeight;
                int newHeight = 100;
                int newWidth = newHeight * sngRatio;
                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);

                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                // Save the new graphic file to the server
                newBMP.Save(Server.MapPath(".") + "//slike//male//" + sl);

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();
                FileUpload2.PostedFile.SaveAs(Server.MapPath(".") + "//slike//" + sl);
                string path = "~//slike//" + sl.ToString();
                knj.Knjiga.Slika = "slike/" + sl;
                knj.Knjiga.SlikaMala = "slike/male" + sl;
            }
            knj.Knjiga.Id_zanr = Convert.ToInt32(updZanr.SelectedItem.Value);
            knj.Knjiga.Id_autor = Convert.ToInt32(updAutor.SelectedItem.Value);

            OperacijaRezultat obj = OperationManager.Singleton.izvrsiOperaciju(knj);

            DbItem[] items = obj.DbItems;
            KnjigaDb[] knjige = items.Cast<KnjigaDb>().ToArray();
            if (knjige.Count() > 0) ifEmpty.Visible = false;

            bookGrid.DataSource = knjige;
            bookGrid.DataBind();
        }

        protected void zatvoriUpdatePanel_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void zatvoriInsertPanel_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
        }


    }
}