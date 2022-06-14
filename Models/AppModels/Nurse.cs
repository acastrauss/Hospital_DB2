using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Nurse : HealthCareWorker
    {
        public int SeniorityLevel { get; set; }
        public ICollection<int> HelpsWithCareIDs { get; set; }

        public Nurse(
            string name, DateTime birthDate, string phoneNumber,
            string medicalLicense, string degreeOfEducation,
            int seniorityLevel,
            int idH, int idDep, int idp = -1, ICollection<int> helpingWithCareIds = null
            ) : base(name, birthDate, phoneNumber, medicalLicense, degreeOfEducation, idH, idDep, idp)
        {
            SeniorityLevel = seniorityLevel;
            if(helpingWithCareIds == null)
            {
                helpingWithCareIds = new List<int>();
            }
            HelpsWithCareIDs = helpingWithCareIds;
        }

        public Nurse() : base () { }
    }
}
