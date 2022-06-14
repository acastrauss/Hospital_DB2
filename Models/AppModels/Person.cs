using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    public class Person : ISystemModel
    {
        public int IDP { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String PhoneNumber { get; set; }

        public Person(string name, DateTime birthDate, string phoneNumber, int idp = -1)
        {
            IDP = idp;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        public Person(): base() { }
    }
}
