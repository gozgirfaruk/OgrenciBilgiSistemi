//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciBilgiSistemi.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class OgrenciDers
    {
        public int Id { get; set; }
        public Nullable<int> OgrenciId { get; set; }
        public Nullable<int> DersId { get; set; }
        public string DevamsizlikSayisi { get; set; }
        public Nullable<int> VizeNotu { get; set; }
        public Nullable<int> FinalNotu { get; set; }
        public Nullable<int> ButNotu { get; set; }
    
        public virtual Ders Ders { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
    }
}