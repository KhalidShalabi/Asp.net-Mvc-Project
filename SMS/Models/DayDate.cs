//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DayDate
    {
        public int DayId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> TeacherId { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
