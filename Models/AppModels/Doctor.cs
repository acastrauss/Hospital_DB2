using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Doctor : HealthCareWorker
    {
        public String DoctorLicense { get; set; }
        public String Specialty { get; set; }

        public ICollection<MedicalRecord> MedicalRecords { get; set; }

        public Doctor(
            string name, DateTime birthDate, string phoneNumber,
            string medicalLicense, string degreeOfEducation,
            string doctorLicense, string specialty, 
            int idH, int idDep, int idp = -1, ICollection<MedicalRecord> medicalRecords = null
            ) : base(name, birthDate, phoneNumber, medicalLicense, degreeOfEducation, idH, idDep, idp)
        {
            DoctorLicense = doctorLicense;
            Specialty = specialty;

            if (medicalRecords == null)
            {
                medicalRecords = new List<MedicalRecord>();
            }
            MedicalRecords = medicalRecords;
        }

        public Doctor() : base() { }
    }
}
