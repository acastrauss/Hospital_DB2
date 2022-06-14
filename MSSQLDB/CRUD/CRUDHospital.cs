using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDHospital : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    Models.AppModels.Hospital hospital = model as Models.AppModels.Hospital;

                    db.Hospitals.Add(new MSSQLDB.Hospital()
                    {
                        Address = hospital.Address,
                        DateBuilt = hospital.DateBuilt,
                        Departments = hospital.Departments.Cast<MSSQLDB.Department>().ToList(),
                        Name = hospital.Name
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
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    var h = db.Hospitals.Where(x => x.IDH == id).FirstOrDefault();
                    db.Hospitals.Remove(h);
                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public ICollection<ISystemModel> ReadAllModes()
        {
            List<ISystemModel> retVal = new List<ISystemModel>();

            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    db.Hospitals.ToList().ForEach(x => retVal.Add(_Converter.ConvertHospital(x)));
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
            Models.AppModels.Hospital retVal = new Models.AppModels.Hospital();

            try
            {
                using (var db = new HospitalDBEntities1())
                {
                    var hdb = db.Hospitals.Where(x => x.IDH == id).FirstOrDefault();
                    retVal = _Converter.ConvertHospital(hdb);
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
            int ret = -1;
            try
            {
                Models.AppModels.Hospital happ = model as Models.AppModels.Hospital;

                using (var db = new HospitalDBEntities1())
                {
                    var hdb = db.Hospitals.Where(x => x.IDH == happ.IDH).FirstOrDefault();

                    hdb.Address = happ.Address;
                    hdb.DateBuilt = happ.DateBuilt;
                    hdb.Name = happ.Name;

                    List<MSSQLDB.Department> deps = new List<Department>();
                    // convert system model -> db model
                    //happ.Departments.ToList().ForEach(x => deps.Add(_Converter.ConvertDepartment(hdb)));
                    hdb.Departments = deps;

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
