using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class MedicalRecordForm : IForm
    {
        private Models.ICRUD.ICRUD DbCrud { get; set; } = null;

        private List<Models.AppModels.Patient> Patients { get; set; } = new List<Models.AppModels.Patient>();
        private List<Models.AppModels.Doctor> Doctors { get; set; } = new List<Models.AppModels.Doctor>();
        private int SelectedDoctorID { get; set; } = 0;

        public MedicalRecordForm() : base()
        {
            this.Model = new Models.AppModels.MedicalRecord();

            Label lName = new Label()
            {
                Content = "Diagnosis:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.MedicalRecord)this.Model).Diagnosis = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });

            Label lName1 = new Label()
            {
                Content = "Therapy:"
            };
            TextBox tbName1 = new TextBox()
            {
                Width = 100
            };
            tbName1.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.MedicalRecord)this.Model).Therapy = tbName1.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName1, tbName1
            });

            Label lHospitals = new Label()
            {
                Content = "Patients:"
            };
            DbCrud = new MSSQLDB.CRUD.CRUDPatient();
            Patients = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Patient)x).ToList();
            var patientInfo = Patients.Select(x =>
                String.Format("{0} with insurance {1}", x.Name, x.InsurancePolicy)
            ).ToList();
            ComboBox cb = new ComboBox();
            cb.ItemsSource = patientInfo;
            cb.SelectionChanged += Cb_SelectionChanged1;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals, cb
            });

            Label lHospitals1 = new Label()
            {
                Content = "Doctors:"
            };
            DbCrud = new MSSQLDB.CRUD.CRUDDoctor();
            Doctors = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Doctor)x).ToList();
            var doctorInfo = Doctors.Select(x =>
                String.Format("{0} with specialty {1}", x.Name, x.Specialty)
            ).ToList();
            ComboBox cb1 = new ComboBox();
            cb1.ItemsSource = doctorInfo;
            cb1.SelectionChanged += Cb_SelectionChanged2;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals1, cb1
            });
        }

        private void Cb_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            SelectedDoctorID = this.Doctors[cb.SelectedIndex].IDP;
        }

        private void Cb_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.MedicalRecord)this.Model).IDP = this.Patients[cb.SelectedIndex].IDP;
        }

        public override Models.AppModels.ISystemModel GetModel()
        {
            ((Models.AppModels.MedicalRecord)this.Model).DoctorIDs.Add(SelectedDoctorID);
            return Model;
        }
    }
}
