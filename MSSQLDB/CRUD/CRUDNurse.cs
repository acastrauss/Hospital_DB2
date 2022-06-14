using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDNurse : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    Models.AppModels.Nurse nurse = model as Models.AppModels.Nurse;
                    db.uspCreateNurse(
                        nurse.Name,
                        nurse.BirthDate,
                        nurse.PhoneNumber,
                        nurse.MedicalLicense,
                        nurse.DegreeOfEducation,
                        nurse.SeniorityLevel,
                        nurse.IDDep,
                        nurse.IDH
                    );
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int DeleteModel(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ISystemModel> ReadAllModes()
        {
            throw new NotImplementedException();
        }

        public ISystemModel ReadModel(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(ISystemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
