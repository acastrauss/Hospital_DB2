using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDPatient : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    Models.AppModels.Patient patient = model as Models.AppModels.Patient;
                    db.uspCreatePatient(
                        patient.Name,
                        patient.BirthDate,
                        patient.PhoneNumber,
                        patient.InsurancePolicy,
                        patient.RoomId
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
