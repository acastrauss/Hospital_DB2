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
    
    public partial class uspDoctorPatients_Result : Models.DTOConversion.IDBModel
    {
        public string InsurancePolicy { get; set; }
        public int IDP { get; set; }
        public int IDRoom { get; set; }
        public int IDPDoctor { get; set; }
        public int IDPPatient { get; set; }
        public int IDTCB { get; set; }
    }
}
