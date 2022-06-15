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

        public ICollection<Models.AppModels.FunctionsModels.uspPatient_DoctorRecords> GetPatientRecords(int patientId)
        {
            List<Models.AppModels.FunctionsModels.uspPatient_DoctorRecords> retVal = new List<Models.AppModels.FunctionsModels.uspPatient_DoctorRecords>();

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    retVal = db.uspPatient_DoctorMedicalRecords(patientId).Select(x => _Converter.uspPatientDoctorRecords(x)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public ICollection<Models.AppModels.FunctionsModels.uspPatientNurseResult> GetNursesPatient(int patientId)
        {
            List<Models.AppModels.FunctionsModels.uspPatientNurseResult> retVal = new List<Models.AppModels.FunctionsModels.uspPatientNurseResult>();

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    retVal = db.uspPatientNurse(patientId).Select(x => _Converter.ConvertUSPPNResult(x)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities())
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
                        var nurses = db.Nurses.Where(x => patient.NurseIds.Contains(x.IDP)).ToList();

                        var tcb = new TakenCareBy()
                        {
                            IDPDoctor = did,
                            IDPPatient = patientId,
                            Nurses = nurses
                        };

                        db.TakenCareBies.Add(tcb);
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
            int retVal = -1;

            try
            {
                using (var db = new HospitalDBEntities())
                {
                    var p = db.People.Where(x => x.IDP == id).FirstOrDefault();
                    if(p != null)
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
            int ret = -1;
            try
            {
                Models.AppModels.Patient patient = model as Models.AppModels.Patient;

                using (var db = new HospitalDBEntities())
                {
                    var patientDB = db.Patients.Where(x => x.IDP == patient.IDP).FirstOrDefault();

                    patientDB.Person.Name = patient.Name;
                    patientDB.Person.PhoneNumber = patient.PhoneNumber;
                    patientDB.InsurancePolicy = patient.InsurancePolicy;

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
