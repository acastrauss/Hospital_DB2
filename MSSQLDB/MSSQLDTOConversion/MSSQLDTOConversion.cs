using Models.AppModels.FunctionsModels;
using Models.DTOConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDB.MSSQLDTOConversion
{
    public class MSSQLDTOConversion : Models.DTOConversion.IConvertModels
    {
        public Models.AppModels.Department ConvertDepartment(IDBModel dbModel)
        {
            MSSQLDB.Department dbDep = dbModel as MSSQLDB.Department;

            List<Models.AppModels.HealthCareWorker> healthCareWorkersApp = new List<Models.AppModels.HealthCareWorker>();
            dbDep.HealthCareWorkers.ToList().ForEach(x => healthCareWorkersApp.Add(this.ConvertHCW(x)));

            List<Models.AppModels.Room> roomsApp = new List<Models.AppModels.Room>();
            dbDep.Rooms.ToList().ForEach(x => roomsApp.Add(this.ConvertRoom(x)));

            Models.AppModels.Department d = new Models.AppModels.Department()
            {
                DepartmentField = dbDep.DepartmentField.Trim(),
                HealthCareWorkers = healthCareWorkersApp,
                IDDep = dbDep.IDDep,
                IDH = dbDep.IDH,
                PhoneNumber = dbDep.PhoneNumber.Trim(),
                Rooms = roomsApp
            };

            return d;
        }

        public Models.AppModels.Doctor ConvertDoctor(IDBModel dbModel)
        {
            MSSQLDB.Doctor dbDoc = dbModel as MSSQLDB.Doctor;

            List<Models.AppModels.MedicalRecord> medicalRecordsApp = new List<Models.AppModels.MedicalRecord>();
            dbDoc.MedicalRecords.ToList().ForEach(x => medicalRecordsApp.Add(ConvertMedicalRecord(x)));

            return new Models.AppModels.Doctor(
                    dbDoc.HealthCareWorker.Person.Name.Trim(),
                    dbDoc.HealthCareWorker.Person.BirthDate,
                    dbDoc.HealthCareWorker.Person.PhoneNumber.Trim(),                    dbDoc.HealthCareWorker.MedicalLicense.Trim(),
                    dbDoc.HealthCareWorker.DegreeOfEducation.Trim(),
                    dbDoc.DoctorLicense.Trim(),
                    dbDoc.Specialty.Trim(),
                    dbDoc.HealthCareWorker.IDH,
                    dbDoc.HealthCareWorker.IDDep,
                    dbDoc.HealthCareWorker.Person.IDP,
                    medicalRecordsApp
                );
        }

        public Models.AppModels.HealthCareWorker ConvertHCW(IDBModel dbModel)
        {
            MSSQLDB.HealthCareWorker hcwDb = dbModel as MSSQLDB.HealthCareWorker;

            return new Models.AppModels.HealthCareWorker(
                    hcwDb.Person.Name.Trim(),
                    hcwDb.Person.BirthDate,
                    hcwDb.Person.PhoneNumber.Trim(),
                    hcwDb.MedicalLicense.Trim(),
                    hcwDb.DegreeOfEducation.Trim(),
                    hcwDb.IDH,
                    hcwDb.IDDep,
                    hcwDb.IDP
                );
        }

        public Models.AppModels.Hospital ConvertHospital(IDBModel dbModel)
        {
            MSSQLDB.Hospital hospitalDb = dbModel as MSSQLDB.Hospital;

            List<Models.AppModels.Department> departmentsApp = new List<Models.AppModels.Department>();
            hospitalDb.Departments.ToList().ForEach(x => departmentsApp.Add(this.ConvertDepartment(x)));

            return new Models.AppModels.Hospital()
            {
                Address = hospitalDb.Address.Trim(),
                DateBuilt = hospitalDb.DateBuilt,
                IDH = hospitalDb.IDH,
                Name = hospitalDb.Name.Trim(),
                Departments = departmentsApp
            };
        }

        public Models.AppModels.MedicalRecord ConvertMedicalRecord(IDBModel dbModel)
        {
            MSSQLDB.MedicalRecord medicalRecordDb = dbModel as MSSQLDB.MedicalRecord;

            List<int> doctorIdsApp = new List<int>();
            medicalRecordDb.Doctors.ToList().ForEach(x => doctorIdsApp.Add(x.IDP));

            return new Models.AppModels.MedicalRecord()
            {
                Diagnosis = medicalRecordDb.Diagnosis.Trim(),
                Therapy = medicalRecordDb.Therapy.Trim(),
                IDP = medicalRecordDb.IDP,
                IDRecord = medicalRecordDb.IDRecord,
                DoctorIDs = doctorIdsApp
            };
        }

        public Models.AppModels.Nurse ConvertNurse(IDBModel dbModel)
        {
            MSSQLDB.Nurse dbNurse = dbModel as MSSQLDB.Nurse;

            return new Models.AppModels.Nurse(
                    dbNurse.HealthCareWorker.Person.Name.Trim(),
                    dbNurse.HealthCareWorker.Person.BirthDate,
                    dbNurse.HealthCareWorker.Person.PhoneNumber.Trim(),
                    dbNurse.HealthCareWorker.MedicalLicense.Trim(),
                    dbNurse.HealthCareWorker.DegreeOfEducation.Trim(),
                    dbNurse.SeniorityLevel,
                    dbNurse.HealthCareWorker.IDH,
                    dbNurse.HealthCareWorker.IDDep,
                    dbNurse.HealthCareWorker.Person.IDP
                );
        }

        public Models.AppModels.Patient ConvertPatient(IDBModel dbModel)
        {
            MSSQLDB.Patient patientDb = dbModel as MSSQLDB.Patient;

            List<Models.AppModels.MedicalRecord> medicalRecordsApp = new List<Models.AppModels.MedicalRecord>();
            patientDb.MedicalRecords.ToList().ForEach(x => medicalRecordsApp.Add(ConvertMedicalRecord(x)));

            return new Models.AppModels.Patient(
                    patientDb.Person.Name.Trim(),
                    patientDb.Person.BirthDate,
                    patientDb.Person.PhoneNumber.Trim(),
                    patientDb.InsurancePolicy.Trim(),
                    patientDb.IDRoom,
                    patientDb.IDP,
                    medicalRecordsApp
                );
        }

        public Models.AppModels.Person ConvertPerson(IDBModel dbModel)
        {
            throw new NotImplementedException();
        }

        public Models.AppModels.Room ConvertRoom(IDBModel dbModel)
        {
            MSSQLDB.Room roomDb = dbModel as MSSQLDB.Room;

            List<Models.AppModels.Patient> patientsApp = new List<Models.AppModels.Patient>();
            roomDb.Patients.ToList().ForEach(x => patientsApp.Add(this.ConvertPatient(x)));

            return new Models.AppModels.Room()
            {
                Capacity = roomDb.Capacity,
                Floor = roomDb.Floor,
                IDDep = roomDb.IDDep,
                IDH = roomDb.IDH,
                IDRoom = roomDb.IDRoom,
                Patients = patientsApp
            };
        }

        public Models.AppModels.TakenCareBy ConvertTakenCareBy(IDBModel dbModel)
        {
            MSSQLDB.TakenCareBy tcbDb = dbModel as MSSQLDB.TakenCareBy;

            List<Models.AppModels.Nurse> nursesApp = new List<Models.AppModels.Nurse>();
            tcbDb.Nurses.ToList().ForEach(x => nursesApp.Add(ConvertNurse(x)));

            return new Models.AppModels.TakenCareBy()
            {
                Doctor_ = this.ConvertDoctor(tcbDb.Doctor),
                Patient_ = this.ConvertPatient(tcbDb.Patient),
                IDTCB = tcbDb.IDTCB,
                Nurses = nursesApp
            };
        }

        public uspDoctorPatientsResult ConvertUSPDPResult(IDBModel dbModel)
        {
            MSSQLDB.uspDoctorPatients_Result uspRes = dbModel as MSSQLDB.uspDoctorPatients_Result;
            return new uspDoctorPatientsResult()
            {
                IDP = uspRes.IDP,
                IDPDoctor = uspRes.IDPDoctor,
                IDPPatient = uspRes.IDPPatient,
                IDRoom = uspRes.IDRoom,
                IDTCB = uspRes.IDTCB,
                InsurancePolicy = uspRes.InsurancePolicy.Trim()
            };
        }

        public uspPatientDoctorsResult ConvertUSPPDResult(IDBModel dbModel)
        {
            MSSQLDB.uspPatientDoctors_Result uspRes = dbModel as MSSQLDB.uspPatientDoctors_Result;
            return new uspPatientDoctorsResult()
            {
                DoctorLicense = uspRes.DoctorLicense.Trim(),
                Specialty = uspRes.Specialty.Trim(),
                IDP = uspRes.IDP,
                IDPDoctor = uspRes.IDPDoctor,
                IDPPatient = uspRes.IDPPatient,
                IDTCB = uspRes.IDTCB
            };
        }

        public uspPatientNurseResult ConvertUSPPNResult(IDBModel dbModel)
        {
            MSSQLDB.uspPatientNurse_Result uspRes = dbModel as MSSQLDB.uspPatientNurse_Result;
            return new uspPatientNurseResult()
            {
                SeniorityLevel = uspRes.SeniorityLevel,
                IDP = uspRes.IDP,
                IDPNurse = uspRes.IDPNurse,
                IDTCB = uspRes.IDTCB
            };
        }
    }
}
