using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public class ZanrDb : DbItem
    {
        private int id_zanr;
        private string naziv;

        #region Svojstva
        public int Id_zanr
        {
            get
            {
                return id_zanr;
            }

            set
            {
                id_zanr = value;
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return this.id_zanr.ToString() + " " + this.naziv;
        }
    }

    public class OpZanrBase : Operacija
    {
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<ZanrDb> ieZanr;
            ieZanr = from znr in entiteti.zanrs
                     select new ZanrDb
                     {
                         Id_zanr = znr.id_zanr,
                         Naziv = znr.naziv
                     };
            ZanrDb[] niz = ieZanr.ToArray();
            OperacijaRezultat obj = new OperacijaRezultat();
            obj.DbItems = niz;
            obj.Status = true;
            return obj;
        }
    }

    public class ZanrSelect : OpZanrBase
    {

    }

    public class ZanrInsert : OpZanrBase
    {
        private ZanrDb zanr;

        public ZanrDb Zanr
        {
            get { return zanr; }
            set { zanr = value; }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.ZanrInsert(this.zanr.Naziv);
            return base.izvrsi(entiteti);
        }

    }

    public class ZanrDelete : OpZanrBase
    {
        private int id_zanr;

        public int Id_zanr
        {
            get { return id_zanr; }
            set { id_zanr = value; }
        }
        
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            if(this.id_zanr>0)
            entiteti.ZanrDelete(this.id_zanr);
            return base.izvrsi(entiteti);
        }
    }


    public class AutorDb : DbItem
    {
        private int id_autor;
        private string ime;
        private string prezime;
        private string biografija;

        #region Svojstva
        public int Id_autor
        {
            get
            {
                return id_autor;
            }

            set
            {
                id_autor = value;
            }
        }

        

        public string Biografija
        {
            get
            {
                return biografija;
            }

            set
            {
                biografija = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }



        #endregion

        public override string ToString()
        {
            return this.Ime + " " + this.Prezime;
        }
    }

    public class OpAutorBase : Operacija
    {
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<AutorDb> ieAutor;
            ieAutor = from aut in entiteti.autors
                      select new AutorDb
                      {
                          Id_autor = aut.id_autor,
                          Ime = aut.ime,
                          Prezime = aut.prezime,
                          Biografija = aut.biografija
        };
            AutorDb[] niz = ieAutor.ToArray();
            OperacijaRezultat obj = new OperacijaRezultat();
            obj.DbItems = niz;
            obj.Status = true;
            return obj;
        }
    }

    public class AutorSelect : OpAutorBase
    {

    }

    public class AutorInsert : OpAutorBase
    {
        private AutorDb autor;

        public AutorDb Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.AutorInsert(this.Autor.Ime, this.Autor.Prezime, this.Autor.Biografija);
            return base.izvrsi(entiteti);
        }

    }
    public class AutorDelete : OpZanrBase
    {
        private int id_autor;

        public int Id_autor
        {
            get
            {
                return id_autor;
            }
            set
            {
                id_autor = value;
            }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            if (this.Id_autor > 0)
                entiteti.AutorDelete(this.Id_autor);
            return base.izvrsi(entiteti);
        }
    }


}