using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspSajt.BusinessLayer;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public class DbKorpa : DbItem
    {
        #region Podaci
        private int id_korisnika;
        private int id_korpa;
        private int id_knjiga;
        private string naziv;
        private double cena;
        #endregion

        #region Svojstva
        public int Id_korisnika
        {
            get
            {
                return id_korisnika;
            }

            set
            {
                id_korisnika = value;
            }
        }

        public int Id_korpa
        {
            get
            {
                return id_korpa;
            }

            set
            {
                id_korpa = value;
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

        public double Cena
        {
            get
            {
                return cena;
            }

            set
            {
                cena = value;
            }
        }

        public int Id_knjiga
        {
            get
            {
                return id_knjiga;
            }

            set
            {
                id_knjiga = value;
            }
        }
    } 
    #endregion
}

     public abstract class OpKorpaBase : Operacija
{
    public DbKorpa korpa;

    public DbKorpa Korpa
    {
        get; set;
    }
    public override OperacijaRezultat izvrsi(bazaEntities entiteti)
    {
       
    IEnumerable<DbKorpa> ieKorpa;
        ieKorpa = from krp in entiteti.korpas
                  join knj in entiteti.knjigas on krp.id_knjiga equals knj.id_knjiga
                  join cen in entiteti.cenas on knj.id_knjiga equals cen.id_knjiga
                  where this.Korpa.Id_korisnika == krp.id_korisnik
                  select new DbKorpa
                  {
                      Id_korisnika = krp.id_korisnik,
                      Naziv = knj.naziv,
                      Cena = cen.cena1,
                      Id_knjiga = krp.id_knjiga
                  };
        DbKorpa[] niz = ieKorpa.ToArray();
        OperacijaRezultat obj = new OperacijaRezultat();
        obj.DbItems = niz;
        obj.Status = true;
        return obj;

    }
   

    
}
public class KorpaSelect : OpKorpaBase
{

}

public class KorpaInsert : OpKorpaBase
{

    public override OperacijaRezultat izvrsi(bazaEntities entiteti)
    {
        entiteti.KorpaInsert(this.Korpa.Id_korisnika, this.Korpa.Id_knjiga);
        return base.izvrsi(entiteti);
    }
}
public class KorpaDelete : OpKorpaBase
{
    public override OperacijaRezultat izvrsi(bazaEntities entiteti)
    {
        entiteti.KorpaDelete(this.Korpa.Id_knjiga);
        return base.izvrsi(entiteti);
    }
}