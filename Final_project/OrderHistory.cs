//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderHistory
    {
        public int HistoryID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StatusDate { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
