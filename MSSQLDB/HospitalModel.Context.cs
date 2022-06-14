﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HospitalDBEntities1 : DbContext
    {
        public HospitalDBEntities1()
            : base("name=HospitalDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<HealthCareWorker> HealthCareWorkers { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<TakenCareBy> TakenCareBies { get; set; }
    
        [DbFunction("HospitalDBEntities1", "udfDoctorPatients")]
        public virtual IQueryable<udfDoctorPatients_Result> udfDoctorPatients(Nullable<int> iDDoctor)
        {
            var iDDoctorParameter = iDDoctor.HasValue ?
                new ObjectParameter("IDDoctor", iDDoctor) :
                new ObjectParameter("IDDoctor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfDoctorPatients_Result>("[HospitalDBEntities1].[udfDoctorPatients](@IDDoctor)", iDDoctorParameter);
        }
    
        [DbFunction("HospitalDBEntities1", "udfPatientDoctors")]
        public virtual IQueryable<udfPatientDoctors_Result> udfPatientDoctors(Nullable<int> iDPatient)
        {
            var iDPatientParameter = iDPatient.HasValue ?
                new ObjectParameter("IDPatient", iDPatient) :
                new ObjectParameter("IDPatient", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfPatientDoctors_Result>("[HospitalDBEntities1].[udfPatientDoctors](@IDPatient)", iDPatientParameter);
        }
    
        [DbFunction("HospitalDBEntities1", "udfPatientNurses")]
        public virtual IQueryable<udfPatientNurses_Result> udfPatientNurses(Nullable<int> iDPatient)
        {
            var iDPatientParameter = iDPatient.HasValue ?
                new ObjectParameter("IDPatient", iDPatient) :
                new ObjectParameter("IDPatient", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfPatientNurses_Result>("[HospitalDBEntities1].[udfPatientNurses](@IDPatient)", iDPatientParameter);
        }
    
        public virtual int uspCreateDoctor(string nameD, Nullable<System.DateTime> birthDateD, string phoneNumberD, string medicalLicenseD, string degreeOfEducationD, string doctorLicense, string specialty, Nullable<int> iDDepartmentD, Nullable<int> iDHospitalD)
        {
            var nameDParameter = nameD != null ?
                new ObjectParameter("NameD", nameD) :
                new ObjectParameter("NameD", typeof(string));
    
            var birthDateDParameter = birthDateD.HasValue ?
                new ObjectParameter("BirthDateD", birthDateD) :
                new ObjectParameter("BirthDateD", typeof(System.DateTime));
    
            var phoneNumberDParameter = phoneNumberD != null ?
                new ObjectParameter("PhoneNumberD", phoneNumberD) :
                new ObjectParameter("PhoneNumberD", typeof(string));
    
            var medicalLicenseDParameter = medicalLicenseD != null ?
                new ObjectParameter("MedicalLicenseD", medicalLicenseD) :
                new ObjectParameter("MedicalLicenseD", typeof(string));
    
            var degreeOfEducationDParameter = degreeOfEducationD != null ?
                new ObjectParameter("DegreeOfEducationD", degreeOfEducationD) :
                new ObjectParameter("DegreeOfEducationD", typeof(string));
    
            var doctorLicenseParameter = doctorLicense != null ?
                new ObjectParameter("DoctorLicense", doctorLicense) :
                new ObjectParameter("DoctorLicense", typeof(string));
    
            var specialtyParameter = specialty != null ?
                new ObjectParameter("Specialty", specialty) :
                new ObjectParameter("Specialty", typeof(string));
    
            var iDDepartmentDParameter = iDDepartmentD.HasValue ?
                new ObjectParameter("IDDepartmentD", iDDepartmentD) :
                new ObjectParameter("IDDepartmentD", typeof(int));
    
            var iDHospitalDParameter = iDHospitalD.HasValue ?
                new ObjectParameter("IDHospitalD", iDHospitalD) :
                new ObjectParameter("IDHospitalD", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreateDoctor", nameDParameter, birthDateDParameter, phoneNumberDParameter, medicalLicenseDParameter, degreeOfEducationDParameter, doctorLicenseParameter, specialtyParameter, iDDepartmentDParameter, iDHospitalDParameter);
        }
    
        public virtual int uspCreateHealthCareWorker(string nameHCW, Nullable<System.DateTime> birthDateHCW, string phoneNumberHCW, string medicalLicense, string degreeOfEducation, Nullable<int> iDDepartment, Nullable<int> iDHospital, ObjectParameter iDCreatedHCW)
        {
            var nameHCWParameter = nameHCW != null ?
                new ObjectParameter("NameHCW", nameHCW) :
                new ObjectParameter("NameHCW", typeof(string));
    
            var birthDateHCWParameter = birthDateHCW.HasValue ?
                new ObjectParameter("BirthDateHCW", birthDateHCW) :
                new ObjectParameter("BirthDateHCW", typeof(System.DateTime));
    
            var phoneNumberHCWParameter = phoneNumberHCW != null ?
                new ObjectParameter("PhoneNumberHCW", phoneNumberHCW) :
                new ObjectParameter("PhoneNumberHCW", typeof(string));
    
            var medicalLicenseParameter = medicalLicense != null ?
                new ObjectParameter("MedicalLicense", medicalLicense) :
                new ObjectParameter("MedicalLicense", typeof(string));
    
            var degreeOfEducationParameter = degreeOfEducation != null ?
                new ObjectParameter("DegreeOfEducation", degreeOfEducation) :
                new ObjectParameter("DegreeOfEducation", typeof(string));
    
            var iDDepartmentParameter = iDDepartment.HasValue ?
                new ObjectParameter("IDDepartment", iDDepartment) :
                new ObjectParameter("IDDepartment", typeof(int));
    
            var iDHospitalParameter = iDHospital.HasValue ?
                new ObjectParameter("IDHospital", iDHospital) :
                new ObjectParameter("IDHospital", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreateHealthCareWorker", nameHCWParameter, birthDateHCWParameter, phoneNumberHCWParameter, medicalLicenseParameter, degreeOfEducationParameter, iDDepartmentParameter, iDHospitalParameter, iDCreatedHCW);
        }
    
        public virtual int uspCreateNurse(string nameN, Nullable<System.DateTime> birthDateN, string phoneNumberN, string medicalLicenseN, string degreeOfEducationN, Nullable<int> seniorityLevel, Nullable<int> iDDepartmentN, Nullable<int> iDHospitalN)
        {
            var nameNParameter = nameN != null ?
                new ObjectParameter("NameN", nameN) :
                new ObjectParameter("NameN", typeof(string));
    
            var birthDateNParameter = birthDateN.HasValue ?
                new ObjectParameter("BirthDateN", birthDateN) :
                new ObjectParameter("BirthDateN", typeof(System.DateTime));
    
            var phoneNumberNParameter = phoneNumberN != null ?
                new ObjectParameter("PhoneNumberN", phoneNumberN) :
                new ObjectParameter("PhoneNumberN", typeof(string));
    
            var medicalLicenseNParameter = medicalLicenseN != null ?
                new ObjectParameter("MedicalLicenseN", medicalLicenseN) :
                new ObjectParameter("MedicalLicenseN", typeof(string));
    
            var degreeOfEducationNParameter = degreeOfEducationN != null ?
                new ObjectParameter("DegreeOfEducationN", degreeOfEducationN) :
                new ObjectParameter("DegreeOfEducationN", typeof(string));
    
            var seniorityLevelParameter = seniorityLevel.HasValue ?
                new ObjectParameter("SeniorityLevel", seniorityLevel) :
                new ObjectParameter("SeniorityLevel", typeof(int));
    
            var iDDepartmentNParameter = iDDepartmentN.HasValue ?
                new ObjectParameter("IDDepartmentN", iDDepartmentN) :
                new ObjectParameter("IDDepartmentN", typeof(int));
    
            var iDHospitalNParameter = iDHospitalN.HasValue ?
                new ObjectParameter("IDHospitalN", iDHospitalN) :
                new ObjectParameter("IDHospitalN", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreateNurse", nameNParameter, birthDateNParameter, phoneNumberNParameter, medicalLicenseNParameter, degreeOfEducationNParameter, seniorityLevelParameter, iDDepartmentNParameter, iDHospitalNParameter);
        }
    
        public virtual int uspCreatePatient(string nameP, Nullable<System.DateTime> birthDateP, string phoneNumberP, string insurancePolicy, Nullable<int> iDRoom)
        {
            var namePParameter = nameP != null ?
                new ObjectParameter("NameP", nameP) :
                new ObjectParameter("NameP", typeof(string));
    
            var birthDatePParameter = birthDateP.HasValue ?
                new ObjectParameter("BirthDateP", birthDateP) :
                new ObjectParameter("BirthDateP", typeof(System.DateTime));
    
            var phoneNumberPParameter = phoneNumberP != null ?
                new ObjectParameter("PhoneNumberP", phoneNumberP) :
                new ObjectParameter("PhoneNumberP", typeof(string));
    
            var insurancePolicyParameter = insurancePolicy != null ?
                new ObjectParameter("InsurancePolicy", insurancePolicy) :
                new ObjectParameter("InsurancePolicy", typeof(string));
    
            var iDRoomParameter = iDRoom.HasValue ?
                new ObjectParameter("IDRoom", iDRoom) :
                new ObjectParameter("IDRoom", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreatePatient", namePParameter, birthDatePParameter, phoneNumberPParameter, insurancePolicyParameter, iDRoomParameter);
        }
    
        public virtual int uspCreatePerson(string name, Nullable<System.DateTime> birthDate, string phoneNumber, ObjectParameter iDCreated)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreatePerson", nameParameter, birthDateParameter, phoneNumberParameter, iDCreated);
        }
    
        public virtual ObjectResult<uspDoctorPatients_Result> uspDoctorPatients(Nullable<int> iDDoctor)
        {
            var iDDoctorParameter = iDDoctor.HasValue ?
                new ObjectParameter("IDDoctor", iDDoctor) :
                new ObjectParameter("IDDoctor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspDoctorPatients_Result>("uspDoctorPatients", iDDoctorParameter);
        }
    
        public virtual ObjectResult<uspPatientDoctors_Result> uspPatientDoctors(Nullable<int> iDPatient)
        {
            var iDPatientParameter = iDPatient.HasValue ?
                new ObjectParameter("IDPatient", iDPatient) :
                new ObjectParameter("IDPatient", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspPatientDoctors_Result>("uspPatientDoctors", iDPatientParameter);
        }
    
        public virtual ObjectResult<uspPatientNurse_Result> uspPatientNurse(Nullable<int> iDPatient)
        {
            var iDPatientParameter = iDPatient.HasValue ?
                new ObjectParameter("IDPatient", iDPatient) :
                new ObjectParameter("IDPatient", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspPatientNurse_Result>("uspPatientNurse", iDPatientParameter);
        }
    }
}
