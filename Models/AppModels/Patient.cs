using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Patient : Person
    {
        public String InsurancePolicy { get; set; }
        public int RoomId { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<int> DoctorIds { get; set; } = new List<int>();
        public ICollection<int> NurseIds { get; set; } = new List<int>();
        public Patient(
            string name, DateTime birthDate, string phoneNumber,
            string insurancePolicy,
            int idRoom, int idp = -1, ICollection<MedicalRecord> medicalRecords = null,
            ICollection<int> doctorIds = null
        ) : base(name, birthDate, phoneNumber, idp)
        {
            InsurancePolicy = insurancePolicy;
            RoomId = idRoom;
            if (medicalRecords == null)
            {
                medicalRecords = new List<MedicalRecord>();
            }
            MedicalRecords = medicalRecords;
            if (doctorIds == null)
            {
                doctorIds = new List<int>();
            }
            DoctorIds = doctorIds;
        }

        public Patient(): base() { }
    }
}
