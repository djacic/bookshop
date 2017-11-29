using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public class KontaktDb : DbItem
    {
        #region Podaci
        private int id_kontakt;
        private string ime;
        private string email;
        private string naslov;
        private string poruka;
        #endregion

        #region Svojstva
        public int Id_kontakt
        {
            get
            {
                return id_kontakt;
            }

            set
            {
                id_kontakt = value;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
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

        public string Poruka
        {
            get
            {
                return poruka;
            }

            set
            {
                poruka = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return this.id_kontakt.ToString() + " " + this.ime + " " + this.naslov + " " + this.poruka;
        }

    }
    
    public class KontaktKriterijum
    {
        public int id_kontakt;
        public int Id_kontakt
        {
            get
            {
                return id_kontakt;
            }
            set
            {
                id_kontakt = value;
            }
        }
    }
    public class OpKontaktBase : Operacija
    {
        public KontaktKriterijum kontaktkriterjum;
        public KontaktDb kontakt {get;set;}
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<KontaktDb> ieKontakt;
            if(this.kontaktkriterjum!=null)
            {
                ieKontakt = from kon in entiteti.kontakts
                            where kon.id_kontakt == this.kontaktkriterjum.id_kontakt
                            select new KontaktDb
                            {
                                Id_kontakt = kon.id_kontakt,
                                Email = kon.email,
                                Ime = kon.ime,
                                Naslov = kon.naslov,
                                Poruka = kon.poruka
                            };
                KontaktDb[] niz = ieKontakt.ToArray();
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.DbItems = niz;
                obj.Status = true;
                return obj;
            }
            else
            {
                ieKontakt = from kon in entiteti.kontakts
                            select new KontaktDb
                            {
                                Id_kontakt = kon.id_kontakt,
                                Email = kon.email,
                                Ime = kon.ime,
                                Naslov = kon.naslov,
                                Poruka = kon.poruka
                            };
                KontaktDb[] niz = ieKontakt.ToArray();
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.DbItems = niz;
                obj.Status = true;
                return obj;
            }
            
        }
    }

    public class KontaktSelect : OpKontaktBase
    {
    }

    public class KontaktInsert : OpKontaktBase
    {
        private KontaktDb kontakti;

        public KontaktDb Kontakti
        {
            get
            {
                return kontakti;
            }

            set
            {
                kontakti = value;
            }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.KontaktInsert(this.Kontakti.Ime, this.Kontakti.Email, this.Kontakti.Naslov, this.Kontakti.Poruka);
            return base.izvrsi(entiteti);
        }
    }

    public class KontaktDelete : OpKontaktBase
    {
        private int id_kontakt;

        public int Id_kontakt
        {
            get { return id_kontakt; }
            set { id_kontakt = value; }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            if (this.id_kontakt > 0)
                entiteti.KontaktDelete(this.id_kontakt);
            return base.izvrsi(entiteti);
        }
    }

}