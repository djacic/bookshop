//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class korisnik
    {
        public korisnik()
        {
            this.aktivnostis = new HashSet<aktivnosti>();
            this.komentars = new HashSet<komentar>();
            this.korpas = new HashSet<korpa>();
            this.ocenas = new HashSet<ocena>();
        }
    
        public int id_korisnik { get; set; }
        public int id_uloga { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<aktivnosti> aktivnostis { get; set; }
        public virtual ICollection<komentar> komentars { get; set; }
        public virtual uloga uloga { get; set; }
        public virtual ICollection<korpa> korpas { get; set; }
        public virtual ICollection<ocena> ocenas { get; set; }
    }
}
