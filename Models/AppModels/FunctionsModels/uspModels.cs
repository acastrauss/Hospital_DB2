using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels.FunctionsModels
{
    public class uspDoctorPatientsResult
    {
        public string InsurancePolicy { get; set; }
        public int IDP { get; set; }
        public int IDRoom { get; set; }
        public int IDPDoctor { get; set; }
        public int IDPPatient { get; set; }
        public int IDTCB { get; set; }
    }
    
    public class uspPatientDoctorsResult
    {
        public string DoctorLicense { get; set; }
        public string Specialty { get; set; }
        public int IDP { get; set; }
        public int IDPDoctor { get; set; }
        public int IDPPatient { get; set; }
        public int IDTCB { get; set; }
    }

    public class uspPatientNurseResult
    {
        public int SeniorityLevel { get; set; }
        public int IDP { get; set; }
        public int IDPNurse { get; set; }
        public int IDTCB { get; set; }
    }

    public class uspPatient_DoctorRecords
    {
        public string DoctorLicense { get; set; }
        public string Specialty { get; set; }
        public String DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
    }

}
