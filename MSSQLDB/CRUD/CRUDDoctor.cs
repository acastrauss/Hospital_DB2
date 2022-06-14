using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDDoctor : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    Models.AppModels.Doctor doctor = model as Models.AppModels.Doctor;
                    db.uspCreateDoctor(
                        doctor.Name,
                        doctor.BirthDate,
                        doctor.PhoneNumber,
                        doctor.MedicalLicense,
                        doctor.DegreeOfEducation,
                        doctor.DoctorLicense,
                        doctor.Specialty,
                        doctor.IDDep,
                        doctor.IDH
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
