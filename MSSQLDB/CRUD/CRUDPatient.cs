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

                    db.SaveChanges();

                    int patientId = db.Patients.Max(x => x.IDP);

                    patient.DoctorIds.ToList().ForEach((did) =>
                    {
                        db.TakenCareBies.Add(new TakenCareBy()
                        {
                            IDPDoctor = did,
                            IDPPatient = patientId
                        });
                    });

                    if(db.Rooms.Where(x => x.IDRoom == patient.RoomId).Count() > 0)
                    {
                        db.Rooms.Where(x => x.IDRoom == patient.RoomId).First().Capacity -= 1;
                    }

                    db.SaveChanges();
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
                    db.Patients.ToList().ForEach(x => retVal.Add(_Converter.ConvertPatient(x)));
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
