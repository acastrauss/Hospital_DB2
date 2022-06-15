using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDDepartment : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    Models.AppModels.Department department = model as Models.AppModels.Department;

                    db.Departments.Add(new MSSQLDB.Department()
                    {
                        DepartmentField = department.DepartmentField,
                        IDH = department.IDH,
                        PhoneNumber = department.PhoneNumber,
                        HealthCareWorkers = new List<MSSQLDB.HealthCareWorker>(),
                        Rooms = new List<MSSQLDB.Room>()
                    });

                    ret = db.SaveChanges();
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
            List<ISystemModel> retVal = new List<ISystemModel>();

            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    db.Departments.ToList().ForEach(x => retVal.Add(_Converter.ConvertDepartment(x)));
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
            Models.AppModels.Department retVal = new Models.AppModels.Department();

            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    var hdb = db.Departments.Where(x => x.IDDep == id).FirstOrDefault();
                    retVal = _Converter.ConvertDepartment(hdb);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public int UpdateModel(ISystemModel model)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfNurses(int depId)
        {
            int retVal = 0;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    retVal = db.Nurses.ToList().Count(x => x.HealthCareWorker.IDDep == depId);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }
        
        public int GetNumberOfDoctors(int depId)
        {
            int retVal = 0;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    retVal = db.Doctors.ToList().Count(x => x.HealthCareWorker.IDDep == depId);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public ICollection<ISystemModel> ReadMultipleModels(ICollection<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
