using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Room : ISystemModel
    {
        public int IDRoom { get; set; }
        public int IDH { get; set; }
        public int IDDep { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        public ICollection<Patient> Patients { get; set; }

    }
}
