using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class MedicalRecord : ISystemModel
    {
        public int IDRecord { get; set; }
        public int IDP { get; set; }
        public ICollection<int> DoctorIDs { get; set; } = new List<int>();
        public String Diagnosis { get; set; }
        public String Therapy { get; set; }

    }
}
