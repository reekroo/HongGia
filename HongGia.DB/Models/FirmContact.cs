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
    
    public partial class FirmContact
    {
        public int Id { get; set; }
        public int FirmId { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
    
        public virtual Firm Firm { get; set; }
    }
}
