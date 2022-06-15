using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class HospitalTable : ITable
    {
        private List<Models.AppModels.Hospital> Hospitals = new List<Models.AppModels.Hospital>();
        public HospitalTable() : base()
        {
            this.dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            Hospitals = this.dbCrud.ReadAllModes().Select(x => (Models.AppModels.Hospital)x).ToList();
            AddHeader();

            foreach (var h in Hospitals)
            {
                AddHospital(h);
            }
        }

        protected override void AddHeader()
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            TextBox t1 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Name:"
            };

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Address:"
            };

            sp.Children.Add(t2);

            
            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Date built:"
            };

            sp.Children.Add(t3);

            
            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Departments:"
            };

            sp.Children.Add(t4);

            this.Children.Add(sp);
        }
    
        private void AddHospital(Models.AppModels.Hospital h)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            TextBox t1 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = h.Name
            };

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = h.Address
            };

            sp.Children.Add(t2);


            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = h.DateBuilt.ToString()
            };

            sp.Children.Add(t3);

            String depsStr = String.Empty;

            h.Departments.ToList().ForEach((dep) =>
            {
                String s = String.Format("Field:{0}, Phone:{1}\n", dep.DepartmentField, dep.PhoneNumber);
                depsStr += s;
            });

            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = depsStr
            };

            sp.Children.Add(t4);

            this.Children.Add(sp);
        }
    }
}
