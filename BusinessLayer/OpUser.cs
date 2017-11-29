using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspSajt.DataLayer;
using System.Web.Security;

namespace aspSajt.BusinessLayer
{
    public class UserDb : DbItem
    {
        #region Podaci
        private int id_korisnik;
        private int id_uloga;
        private string username;
        private string password;
        private string email;
        private string naziv;
        #endregion

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

        public int Id_uloga
        {
            get
            {
                return id_uloga;
            }

            set
            {
                id_uloga = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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
            return this.Id_korisnik + " " + this.username + " " + this.password;
        }
    }

    public class LoginOperation
    {
        public string username;
        public string password;
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class OpUserBase : Operacija
    {
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<UserDb> ieUsers;
            ieUsers = from usr in entiteti.korisniks
                      join rol in entiteti.ulogas on usr.id_uloga equals rol.id_uloga
                      select new UserDb
                      {
                          Id_korisnik = usr.id_korisnik,
                          Id_uloga = rol.id_uloga,
                          Username = usr.username,
                          Password = usr.pass,
                          Email = usr.email,
                          Naziv = rol.naziv
                      };
            UserDb[] niz = ieUsers.ToArray();
            OperacijaRezultat obj = new OperacijaRezultat();
            obj.DbItems = niz;
            obj.Status = true;
            return obj;
        }
    }

    public class Logovanje : Operacija
    {
        public LoginOperation Login { get; set; }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<UserDb> ieLogin;
            ieLogin = from usr in entiteti.korisniks
                      join rol in entiteti.ulogas on usr.id_uloga equals rol.id_uloga
                      where this.Login.Username == usr.username && this.Login.Password == usr.pass
            select new UserDb
                      {
                          Id_korisnik = usr.id_korisnik,
                          Id_uloga = rol.id_uloga,
                          Username = usr.username,
                          Password = usr.pass,
                          Email = usr.email
                      };
            UserDb[] niz = ieLogin.ToArray();
            OperacijaRezultat obj = new OperacijaRezultat();
            obj.DbItems = niz;
            obj.Status = true;
            return obj;


        }

        


    }

    public class UlogaSelect : Operacija
    {
        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            IEnumerable<UserDb> ieUloge;
            ieUloge = from rol in entiteti.ulogas
                      select new UserDb
                      {
                          Id_uloga = rol.id_uloga,
                          Naziv = rol.naziv
                      };
            UserDb[] niz = ieUloge.ToArray();
            OperacijaRezultat obj = new OperacijaRezultat();
            obj.DbItems = niz;
            obj.Status = true;
            return obj;
        }
    }
    public class KorisnikSelect : OpUserBase
    {

    }

    public class KorisnikInsert : OpUserBase
    {
        private UserDb user;

        public UserDb User { get { return user; } set { user = value; } }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {

            entiteti.KorisnikInsert(user.Id_uloga, user.Username, user.Password, user.Email);
            return base.izvrsi(entiteti);
        }
    }

    public class KorisnikDelete : OpUserBase
    {
        private int id_korisnik;

        public int Id_korisnik
        {
            get { return id_korisnik; }
            set { id_korisnik = value; }
        }

        public override OperacijaRezultat izvrsi(bazaEntities entiteti)
        {
            if (this.id_korisnik > 0)
                entiteti.KorisnikDelete(this.id_korisnik);
            return base.izvrsi(entiteti);
        }
    }

    

}