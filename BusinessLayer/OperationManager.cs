using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public class OperationManager
    {
        // Klasa OperationManager sluzi za centralizovani rad sa operacijama.
        // Klasa treba da sadrzi zajednicki kod koji je potreban za izvrsavanje bilo koje operacije.
        // U ovom malom primeru zajednicki deo je:
        // - objekat klase Baza1Entities koji se pravi samo jednom u konsrtuktoru OperationManager i prosledjuje operacjijama,
        // - obrada izuzetaka.
        // U slozenijem slucaju menadzer operacija bi mogao da radi npr. sledece:
        // - Proveru da li treba izvrsiti operaciju na osnovu kriterijuma koji mogu na neki nacin biti zadati trajno ili privremeno,
        //   npr. privremeno se nekom korsniku onemogucava update, insert, delete u vezi nekog od mogucih poslova.
        // - Upravljanje redom za cekanje u kojem stoje operacije koje treba izvsiti.
        //      1. stavljanje operacija u red za cekanje na izvrsenje u slucaju velikog broja operacija, odnosno opterecenja servera
        //      2. izvrsavanje operacija iz reda za cekanje po prioritetu operacija, ili prioritetu korisnika cije su operacije, u slucaju da ima vise operacija u redu za cekanje
        //   Upravljanje redom za cekanje od starne OperationManager dolazi u obzir u slucaju pisanja serverske aplikacije koja nema takvu podrsku,
        //   tj. ne dolazi u obzir za projekat tipa "Web Aplikacija".


        // Klasa OperationManager je singleton klasa, sto znaci da je obezbedjeno da moze da se napravi samo jedan objekat te klase.
        // Taj objekat pravi sama klasa i zato ima samo privatni konstruktor.
        // Postoji svojstvo koje se zove "Singleton" koje sluzi za dohvatanje objekta klase.
        // Objekat se pravi u trenutku kad se prvi put pokusa dohvatanje objekta preko svojstava "Singleton"
        // i to na bezbedan nacin i u slucaju koriscenja vise thread-ova koji pokusaju istovremeno da dohvate objekat klase.
        // To se postize koriscenjem dvostrukog lock-a.

        #region Singleton
        private OperationManager() { }
        private static volatile OperationManager singleton;
        private static object syncRoot = new object();

        public static OperationManager Singleton
        {
            get
            {
                if (OperationManager.singleton == null)
                {
                    lock (OperationManager.syncRoot)
                    {
                        if (OperationManager.singleton == null)
                            OperationManager.singleton = new OperationManager();
                    }
                }
                return OperationManager.singleton;
            }
        }
        #endregion

        private bazaEntities entiteti = new bazaEntities();

        public OperacijaRezultat izvrsiOperaciju(Operacija op)
        {
            try
            {
                return op.izvrsi(this.entiteti);
            }
            catch(Exception e)
            {
                //return null;
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.Status = false;
        #if DEBUG   // predprocesorska direktiva za uslovno prevodjenje dela koda
                // Poruka okruzenja o izuzetku se setuje u objekat samo u "debug" modu, a ne i u "release" modu
                obj.Poruka = e.Message;
        #endif
                return obj;
            }
        }

    }
}
