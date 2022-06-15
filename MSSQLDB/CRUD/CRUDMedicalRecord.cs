using Models.AppModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.CRUD
{
    public class CRUDMedicalRecord : Models.ICRUD.ICRUD
    {
        public IConvertModels _Converter { get; set; } = new MSSQLDB.MSSQLDTOConversion.MSSQLDTOConversion();

        public int CreateModel(ISystemModel model)
        {
            int ret = -1;
            try
            {
                using (var db = new HospitalDBEntities())
                {
                    Models.AppModels.MedicalRecord medicalRecord = model as Models.AppModels.MedicalRecord;

                    var doctors = db.Doctors.Where(x => medicalRecord.DoctorIDs.Contains(x.IDP)).ToList();

                    db.MedicalRecords.Add(new MSSQLDB.MedicalRecord()
                    {
                        Diagnosis = medicalRecord.Diagnosis,
                        Therapy = medicalRecord.Therapy,
                        IDP = medicalRecord.IDP,
                        Doctors = doctors
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
            throw new NotImplementedException();
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
