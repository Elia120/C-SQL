//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSES3
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoorsDeatail
    {
        public int DoorsDeatailsID { get; set; }
        public int DoorsID { get; set; }
        public Nullable<int> UsersID { get; set; }
        public Nullable<System.DateTime> AccessDate { get; set; }
        public Nullable<bool> AccessGranted { get; set; }
    
        public virtual Door Door { get; set; }
        public virtual User User { get; set; }
    }
}
