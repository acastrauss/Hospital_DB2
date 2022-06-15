using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class PatientTable : ITable
    {
        private List<Models.AppModels.Patient> Patients = new List<Models.AppModels.Patient>();

        public PatientTable() :base()
        {
            this.dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            Patients = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Patient)x).ToList();

            AddHeader();

            foreach (var p in Patients)
            {
                AddPatient(p);
            }
        }

        protected override void AddHeader()
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            TextBox t01 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Name:"
            };

            sp.Children.Add(t01);

            TextBox t02 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Phone number:"
            };

            sp.Children.Add(t02);
            
            TextBox t03 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Insurance policy:"
            };

            sp.Children.Add(t03);

            TextBox t0 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "At Hospital:"
            };

            sp.Children.Add(t0);


            TextBox t1 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "At Department:"
            };

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Room at floor:"
            };

            sp.Children.Add(t2);

            this.Children.Add(sp);

        }

        private void AddPatient(Models.AppModels.Patient p)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            var tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDRoom();
            var room = ((Models.AppModels.Room)dbCrud.ReadModel(p.RoomId));
            dbCrud = tempCrud;
            
            tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            var hospital = ((Models.AppModels.Hospital)dbCrud.ReadModel(room.IDH));
            dbCrud = tempCrud;

            tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            var dep = ((Models.AppModels.Department)dbCrud.ReadModel(room.IDDep));
            dbCrud = tempCrud;

            var db = new MSSQLDB.HospitalDBEntities1();
            var doctors = db.uspPatientDoctors(p.IDP);
            // find doctors and medical records

            TextBox t01 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.Name
            };

            sp.Children.Add(t01);

            TextBox t02 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.PhoneNumber
            };

            sp.Children.Add(t02);


            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.InsurancePolicy
            };

            sp.Children.Add(t2);

            TextBox t0 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = hospital.Name
            };

            sp.Children.Add(t0);

            TextBox t1 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = dep.DepartmentField
            };

            sp.Children.Add(t1);

            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = room.Floor.ToString()
            };

            sp.Children.Add(t3);

            this.Children.Add(sp);

        }
    }
}
