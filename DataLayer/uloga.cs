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
    
    public partial class uloga
    {
        public uloga()
        {
            this.korisniks2 = new HashSet<korisnik>();
        }
    
        public int id_uloga { get; set; }
        public string naziv { get; set; }
    
        public virtual ICollection<korisnik> korisniks2 { get; set; }
    }
}
