using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class HospitalTable : ITable
    {
        private List<Models.AppModels.Hospital> Hospitals = new List<Models.AppModels.Hospital>();
        public HospitalTable() : base()
        {
            Restart();
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
    
        private void AddHospital(Models.AppModels.Hospital h, int indx)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            TextBox t1 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = h.Name
            };
            t1.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Hospital)this.Hospitals[indx]).Name = t1.Text;
            });

            sp.Children.Add(t1);

            TextBox t2 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = h.Address
            };
            t2.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Hospital)this.Hospitals[indx]).Address = t2.Text;
            });

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

            Button update = new Button();
            update.Content = "Update";
            update.Name = "btn_" + indx + "_upd";
            update.Click += Update_Click;

            sp.Children.Add(update);

            this.Children.Add(sp);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button update = sender as Button;
            int patientIndx = int.Parse(update.Name.Split('_')[1]);

            this.dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            this.dbCrud.UpdateModel(this.Hospitals[patientIndx]);

            Restart();
        }

        private void Restart()
        {
            this.Children.Clear();
            this.dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            Hospitals = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Hospital)x).ToList();

            AddHeader();
            int indx = 0;

            foreach (var p in Hospitals)
            {
                AddHospital(p, indx++);
            }
        }
    }
}
