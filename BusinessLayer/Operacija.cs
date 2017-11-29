using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspSajt.DataLayer;

namespace aspSajt.BusinessLayer
{
    public abstract class Operacija
    {
        // Osnovna klasa za bilo koju operaciju koja se moze izvrsiti.
        // Logika svake konkretne operacije se nalazi u metodu "izvrsi" koji treba redefinisati.

        // Postoji osnovna klasa za rezultat operacije OperacijaRezultat.
        // Zavisno od rezultata koji treba da vrati operacija, moze se koristiti objekat osnovne klase,
        // ili se iz OperacijaRezultat moze izvesti druga klasa ciji objekat moze da vrati operacija.
        public abstract OperacijaRezultat izvrsi(bazaEntities entiteti);
    }

    public class OperacijaRezultat
    {
        private string poruka;
        private int decimalni;
        private DbItem[] dbItems;

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; }
        }
        public bool Status { get; set; }

        // Osnovna klasa za rezultat ima niz tipa DbItem.
        // Zato se ova klasa moze iskoristiti za vracnje rezultata bilo koje operacije koja vraca jedan niz objekata
        // ako su to objekti klase koja je izvedena iz DbItem.
        // Ovim se smanjuje broj klasa za rezultate operacija koje treba izvoditi iz OperacijaRezultat,
        // ali se mora raditi kastovanje (konverzija) iz niza tipa DbItem u neki drugi niz prilikom upotrebe rezultata operacije.
        public DbItem[] DbItems
        {
            get { return dbItems; }
            set { dbItems = value; }
        }

        public double Decimalni
        {
            get
            {
                return decimalni;
            }
            set
            {
                value = decimalni;
            }
        }
    }

    public abstract class DbItem
    {
    }

    public abstract class SelectKriterijum
    {
    }

 



}
