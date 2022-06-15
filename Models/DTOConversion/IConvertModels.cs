using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOConversion
{
    public interface IConvertModels
    {
        AppModels.Hospital ConvertHospital(DTOConversion.IDBModel dbModel);
        AppModels.Department ConvertDepartment(DTOConversion.IDBModel dbModel);
        AppModels.Person ConvertPerson(DTOConversion.IDBModel dbModel);
        AppModels.HealthCareWorker ConvertHCW(DTOConversion.IDBModel dbModel);
        AppModels.Doctor ConvertDoctor(DTOConversion.IDBModel dbModel);
        AppModels.Nurse ConvertNurse(DTOConversion.IDBModel dbModel);
        AppModels.Patient ConvertPatient(DTOConversion.IDBModel dbModel);
        AppModels.MedicalRecord ConvertMedicalRecord(DTOConversion.IDBModel dbModel);
        AppModels.TakenCareBy ConvertTakenCareBy(DTOConversion.IDBModel dbModel);
        AppModels.Room ConvertRoom(DTOConversion.IDBModel dbModel);

        #region USP_Models

        AppModels.FunctionsModels.uspDoctorPatientsResult ConvertUSPDPResult(DTOConversion.IDBModel dbModel);
        AppModels.FunctionsModels.uspPatientDoctorsResult ConvertUSPPDResult(DTOConversion.IDBModel dbModel);
        AppModels.FunctionsModels.uspPatientNurseResult ConvertUSPPNResult(DTOConversion.IDBModel dbModel);
        AppModels.FunctionsModels.uspPatient_DoctorRecords uspPatientDoctorRecords(IDBModel dBModel);

        #endregion
    }
}
