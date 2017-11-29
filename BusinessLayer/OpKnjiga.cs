using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspSajt.DataLayer;
using PagedList;

namespace aspSajt.BusinessLayer
{
    public class DbOcena : DbItem
    {
        private int id_ocena;
        private int id_knjiga;
        private int id_korisnik;
        private double ocena;
        

        #region Svojstva
        public int Id_ocena
        {
            get
            {
                return id_ocena;
            }

            set
            {
                id_ocena = value;
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

        public int Id_korisnik
        {
            get
            {
                return id_korisnik;
            }

            set
            {
                id_korisnik = value;
            }
        }

        public double Ocena
        {
            get
            {
                return ocena;
            }

            set
            {
                ocena = value;
            }
        }

        

        
        #endregion

        public override string ToString()
        {
            return "" + this.ocena;
        }

    }

    public class OcenaKriterijum
    {
        private int id_korisnik;
        private int id_knjiga;

        #region Svojstva
        public int Id_korisnik
        {
            get
            {
                return id_korisnik;
            }

            set
            {
                id_korisnik = value;
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
        #endregion
    }
    public abstract class OpBaseOcena : Operacija
    {
        public OcenaKriterijum ocenaKriterijum;
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<DbOcena> ieOcenica;

            ieOcenica = from ocn in entiteti.ocenas
                        where ocn.id_korisnik == this.ocenaKriterijum.Id_korisnik && ocn.id_knjiga == this.ocenaKriterijum.Id_knjiga
                        select new DbOcena
                        {
                            Id_korisnik = ocn.id_korisnik,
                            Id_knjiga = ocn.id_knjiga
                        };
            DbOcena[] niz = ieOcenica.ToArray();

            OperacijaRezultat obj = new OperacijaRezultat();

            obj.DbItems = niz;
            obj.Status = true;
            return obj;

        }
    }

    public class OcenaSelect : OpBaseOcena
    {

    }
    public class InsertOcena : OpBaseOcena
    {
        private DbOcena dbocena;

        public DbOcena Dbocena
        {
            get
            {
                return dbocena;
            }

            set
            {
                dbocena = value;
            }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            entiteti.OcenaInsert(this.Dbocena.Id_knjiga, this.Dbocena.Id_korisnik, this.Dbocena.Ocena);
            return base.izvrsi(entiteti);
        }
    }
    public class KnjigaDb : DbItem
    {

        #region Podaci
        private int id_knjiga;
        private int id_autor;
        private int id_zanr;
        private string ime;
        private string prezime;
        private string autor_bio;
        private string zanr;
        private string naziv;
        private string slika;
        private string slikaMala;
        private string godina;
        private string opis;
        private int cena;
        private IEnumerable<DbOcena> ocena;


        #endregion
        #region Svojstva

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
        public string ZbirnaOcena
        {
            get
            {
                DbOcena o = this.ocena.FirstOrDefault();//da probamo
                                                        //moze biti jer nema ocene 
                                                        //pa i nema.. nisam stavio defautl.. ima s amo za jednu knjigu ocena, zato nece znam :D
                                                        // moze -1 pa ti ako je ne moze :D bind radis :D da da vazi kako sada da mu -1 vratim
                if (o != null)//mozda i bude xD
                    return o.Ocena.ToString();
                else
                    return "Nije ocenjena";
            }
        }//posle se ti igraj


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

        public string Slika
        {
            get
            {
                return slika;
            }

            set
            {
                slika = value;
            }
        }

        public string Godina
        {
            get
            {
                return godina;
            }

            set
            {
                godina = value;
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }

            set
            {
                opis = value;
            }
        }

        

        public int Cena
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

        

        public string Zanr
        {
            get
            {
                return zanr;
            }

            set
            {
                zanr = value;
            }
        }

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

        public string Autor_bio
        {
            get
            {
                return autor_bio;
            }

            set
            {
                autor_bio = value;
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

        public string SlikaMala
        {
            get
            {
                return slikaMala;
            }

            set
            {
                slikaMala = value;
            }
        }

        public IEnumerable<DbOcena> Ocena
        {
            get
            {
                return ocena;
            }
            set
            {
                ocena = value;
            }
        }

        




        #endregion

        public override string ToString()
        {
            return this.id_knjiga.ToString() + " " + this.naziv + " " + this.opis;
        }


    }
    public class KriterijumKnjiga : SelectKriterijum
    {
        public string zanr;
        private int id_korisnik;
        public int id_knjiga;
        public int get_cena;
        public string knjiga_pretraga;
        public string Zanr { get; set; }

        public int Id_knjiga { get; set; }

        public int Get_cena { get; set; }

        public int Id_korisnik
        {
            get;

            set;
        }
        public string Knjiga_pretraga
        {
            get; set;
        }
    }

    public abstract class OpKnjigaBase : Operacija
    {

        
        public KriterijumKnjiga Kriterijum { get; set; }

        public KnjigaDb Knjiga{ get; set;}
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
           
            IEnumerable<KnjigaDb> ieKnjige;
            


           if ((this.Kriterijum!=null) && (this.Kriterijum.Id_knjiga > 0))
            {
                ieKnjige = from knj in entiteti.knjigas
                           join aut in entiteti.autors on knj.id_autor equals aut.id_autor
                           join cen in entiteti.cenas on knj.id_knjiga equals cen.id_knjiga
                           join znk in entiteti.zanrKnjigas on knj.id_knjiga equals znk.id_knjiga
                           join znr in entiteti.zanrs on znk.id_zanr equals znr.id_zanr
                           select new KnjigaDb
                           {
                               Id_knjiga = knj.id_knjiga,
                               Ime = aut.ime,
                               Prezime = aut.prezime,
                               Autor_bio = aut.biografija,
                               Cena = cen.cena1,
                               Godina = knj.godina,
                               Naziv = knj.naziv,
                               Opis = knj.opis,
                               Slika = knj.slika,
                               Zanr = znr.naziv,
                               SlikaMala = knj.slikaMala,


                               Id_autor = knj.id_autor,
                               Id_zanr = znr.id_zanr
                           };
            }
            else if ((this.Kriterijum != null) && (this.Kriterijum.Zanr!= null))
            {
                ieKnjige = from knj in entiteti.knjigas
                           join aut in entiteti.autors on knj.id_autor equals aut.id_autor
                           join cen in entiteti.cenas on knj.id_knjiga equals cen.id_knjiga
                           join znk in entiteti.zanrKnjigas on knj.id_knjiga equals znk.id_knjiga
                           join znr in entiteti.zanrs on znk.id_zanr equals znr.id_zanr
                           where znr.naziv == this.Kriterijum.Zanr
                           select new KnjigaDb
                           {
                               Id_knjiga = knj.id_knjiga,
                               Ime = aut.ime,
                               Prezime = aut.prezime,
                               Autor_bio = aut.biografija,
                               Cena = cen.cena1,
                               Godina = knj.godina,
                               Naziv = knj.naziv,
                               Opis = knj.opis,
                               Slika = knj.slika,
                               Zanr = znr.naziv,
                               SlikaMala = knj.slikaMala,
                               Ocena = (from ocn in entiteti.ocenas
                                        where ocn.id_knjiga == knj.id_knjiga
                                        group new { ocn.ocena1 } by ocn.id_knjiga into g
                                        select new DbOcena
                                        {
                                            Ocena = (double)(g.Sum(x => x.ocena1)) / (g.Count())

                                        }),

                               Id_autor = knj.id_autor,
                               Id_zanr = znr.id_zanr
                           };
            }
           else if ((this.Kriterijum != null) && (this.Kriterijum.Knjiga_pretraga != null))
            {
                ieKnjige = from knj in entiteti.knjigas
                           join aut in entiteti.autors on knj.id_autor equals aut.id_autor
                           join cen in entiteti.cenas on knj.id_knjiga equals cen.id_knjiga
                           join znk in entiteti.zanrKnjigas on knj.id_knjiga equals znk.id_knjiga
                           join znr in entiteti.zanrs on znk.id_zanr equals znr.id_zanr
                           select new KnjigaDb
                           {
                               Id_knjiga = knj.id_knjiga,
                               Ime = aut.ime,
                               Prezime = aut.prezime,
                               Autor_bio = aut.biografija,
                               Cena = cen.cena1,
                               Godina = knj.godina,
                               Naziv = knj.naziv,
                               Opis = knj.opis,
                               Slika = knj.slika,
                               Zanr = znr.naziv,
                               SlikaMala = knj.slikaMala,
                               Ocena = (from ocn in entiteti.ocenas
                                        where ocn.id_knjiga == knj.id_knjiga
                                        group new { ocn.ocena1 } by ocn.id_knjiga into g
                                        select new DbOcena
                                        {
                                            Ocena = (double)(g.Sum(x => x.ocena1)) / (g.Count())

                                        })
                           };
            }
            
            else
            {
                ieKnjige = from knj in entiteti.knjigas
                           join aut in entiteti.autors on knj.id_autor equals aut.id_autor
                           join cen in entiteti.cenas on knj.id_knjiga equals cen.id_knjiga
                           join znk in entiteti.zanrKnjigas on knj.id_knjiga equals znk.id_knjiga
                           join znr in entiteti.zanrs on znk.id_zanr equals znr.id_zanr
                           select new KnjigaDb
                           {
                               Id_knjiga = knj.id_knjiga,
                               Ime = aut.ime,
                               Prezime = aut.prezime,
                               Autor_bio = aut.biografija,
                               Cena = cen.cena1,
                               Godina = knj.godina,
                               Naziv = knj.naziv,
                               Opis = knj.opis,
                               Slika = knj.slika,
                               Zanr = znr.naziv,
                               SlikaMala = knj.slikaMala,
                               Ocena = (from ocn in entiteti.ocenas
                                        where ocn.id_knjiga == knj.id_knjiga
                                        group new { ocn.ocena1 } by ocn.id_knjiga into g
                                        select new DbOcena
                                        {
                                            Ocena = (double) (g.Sum(x => x.ocena1)) / (g.Count())

                                        })
                           };
                

            }
           if((this.Kriterijum!=null) && (this.Kriterijum.Knjiga_pretraga != null))
            {
                KnjigaDb[] niz2 = ieKnjige.Where(x => x.Naziv.Contains(this.Kriterijum.Knjiga_pretraga)).ToArray();
                OperacijaRezultat obj2 = new OperacijaRezultat();
                obj2.DbItems = niz2;
                obj2.Status = true;
                return obj2;
            }


                KnjigaDb[] niz = ieKnjige.ToArray();
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.DbItems = niz;
                obj.Status = true;
                return obj;
            
           

        }
    }
    public class OpKnjigaSelect : OpKnjigaBase
    {
        
    }
    public class OpKnjigaInsert : OpKnjigaBase
    {
        private KnjigaDb knjiga;
        public KnjigaDb Knjiga
        {
            get { return knjiga; }
            set { knjiga = value; }
        }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            //if ((this.knjiga != null) && !string.isnullorempty(this.knjiga.naziv) &&
            //    !string.isnullorempty(this.knjiga.slika) &&
            //    !string.isnullorempty(this.knjiga.godina) &&
            //    !string.isnullorempty(this.knjiga.opis) &&
            //    !string.isnullorempty(this.knjiga.zanr) &&
            //    (this.knjiga.cena != 0) &&
            //    !string.isnullorempty(this.knjiga.autor))
                entiteti.KnjigaInsert(knjiga.Id_autor, knjiga.Id_zanr, knjiga.Naziv, knjiga.Slika, knjiga.SlikaMala, knjiga.Godina, knjiga.Opis, knjiga.Cena);
            return base.izvrsi(entiteti);
        }
    }


  
    public class OpKnjigaUpdate : OpKnjigaBase
    {
        private KnjigaDb knjiga;
        public KnjigaDb Knjiga
        {
            get { return knjiga; }
            set { knjiga = value; }
        }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            //if ((this.knjiga != null) && (this.knjiga.Id_knjiga) > 0 && 
            //    !string.IsNullOrEmpty(this.knjiga.Naziv) &&
            //    !string.IsNullOrEmpty(this.knjiga.Slika) &&
            //    !string.IsNullOrEmpty(this.knjiga.Godina) &&
            //    !string.IsNullOrEmpty(this.knjiga.Opis) &&
            //    !string.IsNullOrEmpty(this.knjiga.Zanr) &&
            //    (this.knjiga.Cena != 0) &&
            //    !string.IsNullOrEmpty(this.knjiga.Autor))
                entiteti.KnjigaUpdate(knjiga.Id_knjiga, knjiga.Id_autor, knjiga.Id_zanr, knjiga.Naziv, knjiga.Slika, knjiga.SlikaMala, knjiga.Godina, knjiga.Opis, knjiga.Cena);
            return base.izvrsi(entiteti);
        }

    }
    public class OpKnjigaDelete : OpKnjigaBase
    {
        private int id_knjiga;
        public int Id_knjiga
        {
            get { return id_knjiga; }
            set { id_knjiga = value; }
        }
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
                entiteti.KnjigaDelete(this.id_knjiga);
            return base.izvrsi(entiteti);
        }

    }
    
   

}
