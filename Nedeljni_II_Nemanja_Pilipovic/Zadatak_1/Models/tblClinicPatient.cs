//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClinicPatient : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> IDNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> HealthInsuranceNumber { get; set; }
        public Nullable<System.DateTime> HealthInsuranceExperationDate { get; set; }
        public Nullable<int> DoctorUniqueNumber { get; set; }
        public Nullable<int> FKDoctor { get; set; }
    
        public virtual tblClinicDoctor tblClinicDoctor { get; set; }
    }
}
