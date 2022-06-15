using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class NurseTable : ITable
    {
        private List<Models.AppModels.Nurse> Nurses = new List<Models.AppModels.Nurse>();

        public NurseTable(): base() 
        {
            Restart();
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
                Text = "Seniority level:"
            };

            sp.Children.Add(t4);

            this.Children.Add(sp);
        }

        private void AddNurse(Models.AppModels.Nurse n, int indx)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            var tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDHospital();
            var hospital = ((Models.AppModels.Hospital)dbCrud.ReadModel(n.IDH));
            dbCrud = tempCrud;


            TextBox t01 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = n.Name
            };
            t01.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Nurses[indx]).Name = t01.Text;
            });

            sp.Children.Add(t01);

            TextBox t02 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = n.PhoneNumber
            };
            t02.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Nurses[indx]).PhoneNumber = t02.Text;
            });
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
            var dep = ((Models.AppModels.Department)dbCrud.ReadModel(n.IDDep));
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
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = n.MedicalLicense
            };
            t2.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Nurses[indx]).MedicalLicense = t2.Text;
            });

            sp.Children.Add(t2);


            TextBox t3 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = n.DegreeOfEducation
            };
            t3.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Nurses[indx]).DegreeOfEducation = t3.Text;
            });

            sp.Children.Add(t3);


            TextBox t4 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = n.SeniorityLevel.ToString()
            };
            t4.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Nurses[indx]).SeniorityLevel = int.Parse(t4.Text);
            });

            sp.Children.Add(t4);

            Button delete = new Button();
            delete.Click += Delete_Click;
            delete.Content = "Delete";
            delete.Name = "btn_" + n.IDP.ToString();
            sp.Children.Add(delete);

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

            this.dbCrud = new MSSQLDB.CRUD.CRUDNurse();
            this.dbCrud.UpdateModel(this.Nurses[patientIndx]);

            Restart();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button del = sender as Button;
            int nurseId = int.Parse(del.Name.Split('_')[1]);

            this.dbCrud = new MSSQLDB.CRUD.CRUDNurse();
            this.dbCrud.DeleteModel(nurseId);

            Restart();
        }

        private void Restart()
        {
            this.Children.Clear();
            this.dbCrud = new MSSQLDB.CRUD.CRUDNurse();
            Nurses = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Nurse)x).ToList();

            AddHeader();
            int indx = 0;
            foreach (var p in Nurses)
            {
                AddNurse(p, indx++);
            }
        }
    }
}
