using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDRoom : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities())
                {
                    Models.AppModels.Room room = model as Models.AppModels.Room;

                    db.Rooms.Add(new MSSQLDB.Room()
                    {
                        Capacity = room.Capacity,
                        Floor = room.Floor,
                        IDDep = room.IDDep,
                        IDH = room.IDH,
                        Patients = new List<MSSQLDB.Patient>()
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
                using (var db = new HospitalDBEntities())
                {
                    db.Rooms.ToList().ForEach(x => retVal.Add(_Converter.ConvertRoom(x)));
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
            Models.AppModels.Room retVal = new Models.AppModels.Room();

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    var hdb = db.Rooms.Where(x => x.IDRoom == id).FirstOrDefault();
                    retVal = _Converter.ConvertRoom(hdb);
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

        public int UpdateModel(ISystemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
