﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aspSajt.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class bazaEntities : DbContext
    {
        public bazaEntities()
            : base("name=bazaEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aktivnosti> aktivnostis { get; set; }
        public DbSet<cena> cenas { get; set; }
        public DbSet<knjiga> knjigas { get; set; }
        public DbSet<komentar> komentars { get; set; }
        public DbSet<kontakt> kontakts { get; set; }
        public DbSet<korpa> korpas { get; set; }
        public DbSet<ocena> ocenas { get; set; }
        public DbSet<uloga> ulogas { get; set; }
        public DbSet<zanr> zanrs { get; set; }
        public DbSet<zanrKnjiga> zanrKnjigas { get; set; }
        public DbSet<korisnik> korisniks { get; set; }
        public DbSet<autor> autors { get; set; }
        public DbSet<meni> menis { get; set; }
        public DbSet<meniuloga> meniulogas { get; set; }
    
        public virtual int AktivnostiDelete(Nullable<int> id_aktivnosti)
        {
            var id_aktivnostiParameter = id_aktivnosti.HasValue ?
                new ObjectParameter("id_aktivnosti", id_aktivnosti) :
                new ObjectParameter("id_aktivnosti", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AktivnostiDelete", id_aktivnostiParameter);
        }
    
        public virtual int AktivnostiInsert(Nullable<int> id_korisnik, string mess, Nullable<System.DateTime> datum)
        {
            var id_korisnikParameter = id_korisnik.HasValue ?
                new ObjectParameter("id_korisnik", id_korisnik) :
                new ObjectParameter("id_korisnik", typeof(int));
    
            var messParameter = mess != null ?
                new ObjectParameter("mess", mess) :
                new ObjectParameter("mess", typeof(string));
    
            var datumParameter = datum.HasValue ?
                new ObjectParameter("datum", datum) :
                new ObjectParameter("datum", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AktivnostiInsert", id_korisnikParameter, messParameter, datumParameter);
        }
    
        public virtual int AutorDelete(Nullable<int> id_autor)
        {
            var id_autorParameter = id_autor.HasValue ?
                new ObjectParameter("id_autor", id_autor) :
                new ObjectParameter("id_autor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorDelete", id_autorParameter);
        }
    
        public virtual int AutorInsert(string ime, string prezime, string biografija)
        {
            var imeParameter = ime != null ?
                new ObjectParameter("ime", ime) :
                new ObjectParameter("ime", typeof(string));
    
            var prezimeParameter = prezime != null ?
                new ObjectParameter("prezime", prezime) :
                new ObjectParameter("prezime", typeof(string));
    
            var biografijaParameter = biografija != null ?
                new ObjectParameter("biografija", biografija) :
                new ObjectParameter("biografija", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorInsert", imeParameter, prezimeParameter, biografijaParameter);
        }
    
        public virtual int KomentarDelete(Nullable<int> id_komentar)
        {
            var id_komentarParameter = id_komentar.HasValue ?
                new ObjectParameter("id_komentar", id_komentar) :
                new ObjectParameter("id_komentar", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KomentarDelete", id_komentarParameter);
        }
    
        public virtual int KomentarInsert(Nullable<int> id_korisnik, Nullable<int> id_knjiga, string komentar)
        {
            var id_korisnikParameter = id_korisnik.HasValue ?
                new ObjectParameter("id_korisnik", id_korisnik) :
                new ObjectParameter("id_korisnik", typeof(int));
    
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            var komentarParameter = komentar != null ?
                new ObjectParameter("komentar", komentar) :
                new ObjectParameter("komentar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KomentarInsert", id_korisnikParameter, id_knjigaParameter, komentarParameter);
        }
    
        public virtual int KontaktDelete(Nullable<int> id_kontakt)
        {
            var id_kontaktParameter = id_kontakt.HasValue ?
                new ObjectParameter("id_kontakt", id_kontakt) :
                new ObjectParameter("id_kontakt", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KontaktDelete", id_kontaktParameter);
        }
    
        public virtual int KontaktInsert(string ime, string email, string naslov, string poruka)
        {
            var imeParameter = ime != null ?
                new ObjectParameter("ime", ime) :
                new ObjectParameter("ime", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var naslovParameter = naslov != null ?
                new ObjectParameter("naslov", naslov) :
                new ObjectParameter("naslov", typeof(string));
    
            var porukaParameter = poruka != null ?
                new ObjectParameter("poruka", poruka) :
                new ObjectParameter("poruka", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KontaktInsert", imeParameter, emailParameter, naslovParameter, porukaParameter);
        }
    
        public virtual int KorisnikDelete(Nullable<int> id_korisnik)
        {
            var id_korisnikParameter = id_korisnik.HasValue ?
                new ObjectParameter("id_korisnik", id_korisnik) :
                new ObjectParameter("id_korisnik", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KorisnikDelete", id_korisnikParameter);
        }
    
        public virtual int KorisnikInsert(Nullable<int> id_uloga, string username, string pass, string email)
        {
            var id_ulogaParameter = id_uloga.HasValue ?
                new ObjectParameter("id_uloga", id_uloga) :
                new ObjectParameter("id_uloga", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KorisnikInsert", id_ulogaParameter, usernameParameter, passParameter, emailParameter);
        }
    
        public virtual int KorpaDelete(Nullable<int> id_knjiga)
        {
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KorpaDelete", id_knjigaParameter);
        }
    
        public virtual int KorpaInsert(Nullable<int> id_korisnik, Nullable<int> id_knjiga)
        {
            var id_korisnikParameter = id_korisnik.HasValue ?
                new ObjectParameter("id_korisnik", id_korisnik) :
                new ObjectParameter("id_korisnik", typeof(int));
    
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KorpaInsert", id_korisnikParameter, id_knjigaParameter);
        }
    
        public virtual int MeniDelete(Nullable<int> id_meni)
        {
            var id_meniParameter = id_meni.HasValue ?
                new ObjectParameter("id_meni", id_meni) :
                new ObjectParameter("id_meni", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MeniDelete", id_meniParameter);
        }
    
        public virtual int OcenaInsert(Nullable<int> id_knjiga, Nullable<int> id_korisnik, Nullable<double> ocena)
        {
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            var id_korisnikParameter = id_korisnik.HasValue ?
                new ObjectParameter("id_korisnik", id_korisnik) :
                new ObjectParameter("id_korisnik", typeof(int));
    
            var ocenaParameter = ocena.HasValue ?
                new ObjectParameter("ocena", ocena) :
                new ObjectParameter("ocena", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OcenaInsert", id_knjigaParameter, id_korisnikParameter, ocenaParameter);
        }
    
        public virtual int ZanrDelete(Nullable<int> id_zanr)
        {
            var id_zanrParameter = id_zanr.HasValue ?
                new ObjectParameter("id_zanr", id_zanr) :
                new ObjectParameter("id_zanr", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ZanrDelete", id_zanrParameter);
        }
    
        public virtual int ZanrInsert(string naziv)
        {
            var nazivParameter = naziv != null ?
                new ObjectParameter("naziv", naziv) :
                new ObjectParameter("naziv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ZanrInsert", nazivParameter);
        }
    
        public virtual int KnjigaInsert(Nullable<int> id_autor, Nullable<int> id_zanr, string naziv, string slika, string slikaMala, string godina, string opis, Nullable<int> cena)
        {
            var id_autorParameter = id_autor.HasValue ?
                new ObjectParameter("id_autor", id_autor) :
                new ObjectParameter("id_autor", typeof(int));
    
            var id_zanrParameter = id_zanr.HasValue ?
                new ObjectParameter("id_zanr", id_zanr) :
                new ObjectParameter("id_zanr", typeof(int));
    
            var nazivParameter = naziv != null ?
                new ObjectParameter("naziv", naziv) :
                new ObjectParameter("naziv", typeof(string));
    
            var slikaParameter = slika != null ?
                new ObjectParameter("slika", slika) :
                new ObjectParameter("slika", typeof(string));
    
            var slikaMalaParameter = slikaMala != null ?
                new ObjectParameter("slikaMala", slikaMala) :
                new ObjectParameter("slikaMala", typeof(string));
    
            var godinaParameter = godina != null ?
                new ObjectParameter("godina", godina) :
                new ObjectParameter("godina", typeof(string));
    
            var opisParameter = opis != null ?
                new ObjectParameter("opis", opis) :
                new ObjectParameter("opis", typeof(string));
    
            var cenaParameter = cena.HasValue ?
                new ObjectParameter("cena", cena) :
                new ObjectParameter("cena", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KnjigaInsert", id_autorParameter, id_zanrParameter, nazivParameter, slikaParameter, slikaMalaParameter, godinaParameter, opisParameter, cenaParameter);
        }
    
        public virtual int KnjigaUpdate(Nullable<int> id_knjiga, Nullable<int> id_autor, Nullable<int> id_zanr, string naziv, string slika, string slikaMala, string godina, string opis, Nullable<int> cena)
        {
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            var id_autorParameter = id_autor.HasValue ?
                new ObjectParameter("id_autor", id_autor) :
                new ObjectParameter("id_autor", typeof(int));
    
            var id_zanrParameter = id_zanr.HasValue ?
                new ObjectParameter("id_zanr", id_zanr) :
                new ObjectParameter("id_zanr", typeof(int));
    
            var nazivParameter = naziv != null ?
                new ObjectParameter("naziv", naziv) :
                new ObjectParameter("naziv", typeof(string));
    
            var slikaParameter = slika != null ?
                new ObjectParameter("slika", slika) :
                new ObjectParameter("slika", typeof(string));
    
            var slikaMalaParameter = slikaMala != null ?
                new ObjectParameter("slikaMala", slikaMala) :
                new ObjectParameter("slikaMala", typeof(string));
    
            var godinaParameter = godina != null ?
                new ObjectParameter("godina", godina) :
                new ObjectParameter("godina", typeof(string));
    
            var opisParameter = opis != null ?
                new ObjectParameter("opis", opis) :
                new ObjectParameter("opis", typeof(string));
    
            var cenaParameter = cena.HasValue ?
                new ObjectParameter("cena", cena) :
                new ObjectParameter("cena", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KnjigaUpdate", id_knjigaParameter, id_autorParameter, id_zanrParameter, nazivParameter, slikaParameter, slikaMalaParameter, godinaParameter, opisParameter, cenaParameter);
        }
    
        public virtual int KnjigaDelete(Nullable<int> id_knjiga)
        {
            var id_knjigaParameter = id_knjiga.HasValue ?
                new ObjectParameter("id_knjiga", id_knjiga) :
                new ObjectParameter("id_knjiga", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KnjigaDelete", id_knjigaParameter);
        }
    
        public virtual int MeniInsert(string naslov, string url)
        {
            var naslovParameter = naslov != null ?
                new ObjectParameter("naslov", naslov) :
                new ObjectParameter("naslov", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("url", url) :
                new ObjectParameter("url", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MeniInsert", naslovParameter, urlParameter);
        }
    
        public virtual int MeniUlogaInsert(string uloga)
        {
            var ulogaParameter = uloga != null ?
                new ObjectParameter("uloga", uloga) :
                new ObjectParameter("uloga", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MeniUlogaInsert", ulogaParameter);
        }
    }
}
