using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class DoctorTable : ITable
    {
        private List<Models.AppModels.Doctor> Doctors = new List<Models.AppModels.Doctor>();

        public DoctorTable() : base()
        {
            this.dbCrud = new MSSQLDB.CRUD.CRUDDoctor();
            Doctors = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Doctor)x).ToList();

            AddHeader();

            foreach (var d in Doctors)
            {
                AddDoctor(d);
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
                Text = "Medical license:"
            };

            sp.Children.Add(t2);


            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Degree of education:"
            };

            sp.Children.Add(t3);


            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Doctor license:"
            };

            sp.Children.Add(t4);

            TextBox t5 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Specialty:"
            };

            sp.Children.Add(t5);

            this.Children.Add(sp);
        }


        private void AddDoctor(Models.AppModels.Doctor d)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            var tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            var hospital = ((Models.AppModels.Hospital)dbCrud.ReadModel(d.IDH));
            dbCrud = tempCrud;


            TextBox t01 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.Name
            };

            sp.Children.Add(t01);

            TextBox t02 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.PhoneNumber
            };

            sp.Children.Add(t02);


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

            tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            var dep = ((Models.AppModels.Department)dbCrud.ReadModel(d.IDDep));
            dbCrud = tempCrud;

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

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.MedicalLicense
            };

            sp.Children.Add(t2);


            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.DegreeOfEducation
            };

            sp.Children.Add(t3);


            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.DoctorLicense
            };

            sp.Children.Add(t4);

            TextBox t5 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.Specialty
            };

            sp.Children.Add(t5);

            this.Children.Add(sp);
        }
    }
}
