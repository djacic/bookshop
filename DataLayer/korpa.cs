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
    
    public partial class korpa
    {
        public int id_korpa { get; set; }
        public int id_korisnik { get; set; }
        public int id_knjiga { get; set; }
    
        public virtual knjiga knjiga { get; set; }
        public virtual korisnik korisnik2 { get; set; }
    }
}