using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public class MeniDb : DbItem
    {
        #region Podaci
        private int id_meni;
        private string naslov;
        private string url;
        private string uloga;
        #endregion

        #region Svojstva
        public int Id_meni
        {
            get
            {
                return id_meni;
            }

            set
            {
                id_meni = value;
            }
        }

        public string Naslov
        {
            get
            {
                return naslov;
            }

            set
            {
                naslov = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Uloga
        {
            get
            {
                return uloga;
            }

            set
            {
                uloga = value;
            }
        }

        #endregion

        public override string ToString()
        {
            return this.id_meni + " " + this.naslov + " " + this.url + " " + this.uloga;
        }
    }

    public class MeniKriterijum
    {
        public string uloga;
        public string Uloga { get; set; }
    }
    public abstract class OpMeniBase : Operacija
    {
        public MeniKriterijum Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<MeniDb> ieMeni;
            if ((this.Kriterijum.Uloga != null) && (this.Kriterijum !=null))
            {
                ieMeni = from men in entiteti.menis
                         join men2 in entiteti.meniulogas on men.id_meni equals men2.id_meni
                         where this.Kriterijum.Uloga == men2.uloga
                         select new MeniDb
                         {
                             Id_meni = men.id_meni,
                             Naslov = men.naslov,
                             Url = men.url
                         };
                MeniDb[] niz = ieMeni.ToArray();
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.DbItems = niz;
                obj.Status = true;
                return obj;
            }
            else
            {
                ieMeni = from men in entiteti.menis
                         select new MeniDb
                         {
                             Id_meni = men.id_meni,
                             Naslov = men.naslov,
                             Url = men.url
                         };
                MeniDb[] niz = ieMeni.ToArray();
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.DbItems = niz;
                obj.Status = true;
                return obj;
            }

        }
    }

    public class MeniUlogaInsert : OpMeniBase
    {
        public MeniKriterijum MeniKriterijum { get; set; }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.MeniUlogaInsert(this.MeniKriterijum.Uloga);
            return base.izvrsi(entiteti);
        }
    }


    public class MeniSelect : OpMeniBase
    {

    }

    public class MeniInsert : OpMeniBase
    {

        public MeniDb meni;

        public MeniDb Meni
        {
            get
            {
                return meni;
            }

            set
            {
                meni = value;
            }
        }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.MeniInsert(this.Meni.Naslov, this.Meni.Url);
            return base.izvrsi(entiteti);
        }
    }

    



    public class MeniDelete : OpMeniBase
    {
        private int id_meni;
        public int Id_meni
        {
            get
            {
                return id_meni;
            }
            set
            {
                id_meni = value;
            }
        }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            if (this.id_meni > 0)
                entiteti.MeniDelete(this.id_meni);
            return base.izvrsi(entiteti);
        }
    }

    
}