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
    
    public partial class uspPatient_DoctorMedicalRecords_Result : Models.DTOConversion.IDBModel
    {
        public string Name { get; set; }
        public string DoctorLicense { get; set; }
        public string Specialty { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
    }
}