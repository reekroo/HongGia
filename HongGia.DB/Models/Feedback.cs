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
    
    public partial class Feedback
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string AuthorMail { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Language Language { get; set; }
    }
}
