//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HongGia.DB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FirmAddress
    {
        public int Id { get; set; }
        public int FirmId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Zip { get; set; }
    
        public virtual Firm Firm { get; set; }
    }
}
