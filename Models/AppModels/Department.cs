using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Department : ISystemModel
    {
        public int IDH;
        public int IDDep;
        public String DepartmentField { get; set; }
        public String PhoneNumber { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<HealthCareWorker> HealthCareWorkers { get; set; }
    }
}
