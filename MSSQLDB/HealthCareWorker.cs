//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class HealthCareWorker : Models.DTOConversion.IDBModel
    {
        public string DegreeOfEducation { get; set; }
        public string MedicalLicense { get; set; }
        public int IDP { get; set; }
        public int IDDep { get; set; }
        public int IDH { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Person Person { get; set; }
        public virtual Nurse Nurse { get; set; }
    }
}