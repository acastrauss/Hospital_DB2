using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Hospital : ISystemModel
    {
        public int IDH { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public DateTime DateBuilt { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
