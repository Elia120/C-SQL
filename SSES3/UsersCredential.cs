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
    
    public partial class UsersCredential
    {
        public int UsersCredentialsID { get; set; }
        public int UsersID { get; set; }
        public int CredentialsID { get; set; }
        public string Value { get; set; }
    
        public virtual Credential Credential { get; set; }
        public virtual User User { get; set; }
    }
}
