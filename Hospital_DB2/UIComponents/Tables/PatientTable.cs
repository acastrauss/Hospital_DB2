using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    class PatientTable : ITable
    {
        private List<Models.AppModels.Patient> Patients = new List<Models.AppModels.Patient>();

        public PatientTable() :base()
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
            
            TextBox t3 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Records and doctors:"
            };

            sp.Children.Add(t3);


            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = "Nurses:"
            };

            sp.Children.Add(t4);


            this.Children.Add(sp);

        }

        private void AddPatient(Models.AppModels.Patient p, int indx)
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

            tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            var records = ((MSSQLDB.CRUD.CRUDPatient)dbCrud).GetPatientRecords(p.IDP);
            dbCrud = tempCrud;

            tempCrud = dbCrud;
            dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            var nurses = ((MSSQLDB.CRUD.CRUDPatient)dbCrud).GetNursesPatient(p.IDP);
            dbCrud = tempCrud;

            // find doctors and medical records

            TextBox t01 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.Name
            };
            t01.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Patient)this.Patients[indx]).Name = t01.Text;
            });


            sp.Children.Add(t01);

            TextBox t02 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.PhoneNumber
            };
            t02.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Patient)this.Patients[indx]).PhoneNumber = t02.Text;
            });


            sp.Children.Add(t02);


            TextBox t2 = new TextBox()
            {
                //IsReadOnly = true,
                MaxWidth = 200,
                MaxHeight = 50,
                Width = 200,
                Height = 50,
                Text = p.InsurancePolicy
            };
            t2.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Patient)this.Patients[indx]).InsurancePolicy = t2.Text;
            });

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

            String recordsString = String.Empty;

            foreach (var r in records)
            {
                recordsString += String.Format("Diagnosed:{0}\nPrescribed:{1}\nDoctor:{2}\n\n",
                    r.Diagnosis, r.Therapy, r.DoctorName, r.DoctorLicense, r.Specialty
                );
            }

            TextBox t4 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 500,
                MaxHeight = 300,
                MinWidth = 150,
                MinHeight = 50,
                Text = recordsString
            };

            sp.Children.Add(t4);


            String nursesString = String.Empty;

            int cnt = 0;
            foreach (var n in nurses)
            {
                nursesString += String.Format("Nurse{0} Seniority:{1}\n", ++cnt, n.SeniorityLevel);
            }

            TextBox t5 = new TextBox()
            {
                IsReadOnly = true,
                MaxWidth = 500,
                MaxHeight = 300,
                MinWidth = 150,
                MinHeight = 50,
                Text = nursesString
            };

            sp.Children.Add(t5);

            Button delete = new Button();
            delete.Content = "Delete";
            delete.Name = "btn_" + p.IDP.ToString();
            delete.Click += Delete_Click;

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

            this.dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            this.dbCrud.UpdateModel(this.Patients[patientIndx]);

            Restart();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button del = sender as Button;
            int patientId = int.Parse(del.Name.Split('_')[1]);
            
            this.dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            this.dbCrud.DeleteModel(patientId);

            Restart();
        }

        private void Restart()
        {
            this.Children.Clear();
            this.dbCrud = new MSSQLDB.CRUD.CRUDPatient();
            Patients = dbCrud.ReadAllModes().Select(x => (Models.AppModels.Patient)x).ToList();

            AddHeader();

            int indx = 0;
            foreach (var p in Patients)
            {
                AddPatient(p, indx++);
            }
        }
    }
}
