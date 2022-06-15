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
                using (var db = new HospitalDBEntities())
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
            int retVal = -1;

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    var p = db.People.Where(x => x.IDP == id).FirstOrDefault();
                    if (p != null)
                    {
                        db.People.Remove(p);
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
                    db.Nurses.ToList().ForEach(x => retVal.Add(_Converter.ConvertNurse(x)));
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
            int ret = -1;
            try
            {
                Models.AppModels.Nurse nurse = model as Models.AppModels.Nurse;

                using (var db = new HospitalDBEntities())
                {
                    var nurseDB = db.Nurses.Where(x => x.IDP == nurse.IDP).FirstOrDefault();

                    nurseDB.HealthCareWorker.Person.Name = nurse.Name;
                    nurseDB.HealthCareWorker.Person.PhoneNumber = nurse.PhoneNumber;
                    nurseDB.HealthCareWorker.MedicalLicense = nurse.MedicalLicense;
                    nurseDB.HealthCareWorker.DegreeOfEducation = nurse.DegreeOfEducation;
                    nurseDB.SeniorityLevel = nurse.SeniorityLevel;
                    
                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ret;

        }
    }
}
