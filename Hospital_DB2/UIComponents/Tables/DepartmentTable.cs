using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class DepartmentTable : ITable
    {
        private List<Models.AppModels.Department> Departments = new List<Models.AppModels.Department>();
        public DepartmentTable() : base()
        {
            Restart();
        }

        protected override void AddHeader()
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

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
                Text = "Phone Number:"
            };

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Field:"
            };

            sp.Children.Add(t2);


            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Number of nurses:"
            };

            sp.Children.Add(t3);


            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Number of doctors:"
            };

            sp.Children.Add(t4);
            
            TextBox t5 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Number of rooms:"
            };

            sp.Children.Add(t5);

            this.Children.Add(sp);
        }

        private void AddDepartment(Models.AppModels.Department d)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            var tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            var hospital = ((Models.AppModels.Hospital)dbCrud.ReadModel(d.IDH));
            dbCrud = tempCrud;

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
                Text = d.PhoneNumber
            };

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.DepartmentField
            };

            sp.Children.Add(t2);

            int nursesNum = ((MSSQLDB.CRUD.CRUDDepartment)dbCrud).GetNumberOfNurses(d.IDDep);

            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = nursesNum.ToString()
            };

            sp.Children.Add(t3);

            int doctorsNum = ((MSSQLDB.CRUD.CRUDDepartment)dbCrud).GetNumberOfDoctors(d.IDDep);

            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = doctorsNum.ToString()
            };

            sp.Children.Add(t4);
            
            TextBox t5 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = d.Rooms.Count.ToString()
            };

            sp.Children.Add(t5);

            Button delete = new Button();
            delete.Click += Delete_Click;
            delete.Content = "Delete";
            delete.Name = "btn_" + d.IDDep.ToString();
            sp.Children.Add(delete);


            this.Children.Add(sp);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button del = sender as Button;
            int depId = int.Parse(del.Name.Split('_')[1]);

            //this.dbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            //this.dbCrud.DeleteModel(depId);

            Restart();
        }

        private void Restart()
        {
            this.Children.Clear();
            this.dbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            Departments = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Department)x).ToList();

            AddHeader();

            foreach (var p in Departments)
            {
                AddDepartment(p);
            }
        }
    }
}
