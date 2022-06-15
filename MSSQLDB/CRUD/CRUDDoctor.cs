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
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities())
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
            int retVal = -1;

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    var p = db.Doctors.Where(x => x.IDP == id).FirstOrDefault();
                    if (p != null)
                    {
                        db.Doctors.Remove(p);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public ICollection<ISystemModel> ReadAllModes()
        {
            List<ISystemModel> retVal = new List<ISystemModel>();

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    db.Doctors.ToList().ForEach(x => retVal.Add(_Converter.ConvertDoctor(x)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public ISystemModel ReadModel(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ISystemModel> ReadMultipleModels(ICollection<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(ISystemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
