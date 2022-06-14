using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class HealthCareWorker : Person
    {
        public int IDDep { get; set; }
        public int IDH { get; set; }
        public String MedicalLicense { get; set; }
        public String DegreeOfEducation { get; set; }

        public HealthCareWorker(
            string name, DateTime birthDate, string phoneNumber,
            string medicalLicense, string degreeOfEducation,
            int idH, int idDep, int idp = -1
        ): base(name, birthDate, phoneNumber, idp)
        {
            IDDep = idDep;
            IDH = idH;
            MedicalLicense = medicalLicense;
            DegreeOfEducation = degreeOfEducation;
        }

        public HealthCareWorker():base() { }
    }
}
