using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class TakenCareBy : ISystemModel
    {
        public int IDTCB { get; set; }
        public Doctor Doctor_ { get; set; }
        public Patient Patient_ { get; set; }

        public ICollection<Nurse> Nurses { get; set; }
    }
}
