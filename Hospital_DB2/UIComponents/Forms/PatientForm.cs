using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class PatientForm :PersonForm
    {
        private List<Models.AppModels.Room> Rooms { get; set; } = new List<Models.AppModels.Room>();
        private List<Models.AppModels.Doctor> Doctors { get; set; } = new List<Models.AppModels.Doctor>();
        private List<Models.AppModels.Nurse> Nurses { get; set; } = new List<Models.AppModels.Nurse>();

        private int DoctorId { get; set; } = -1;
        
        public PatientForm() :base()
        {
            this.Model = new Models.AppModels.Patient();
            this.DbCrud = new MSSQLDB.CRUD.CRUDPatient();

            Label lName = new Label()
            {
                Content = "Insurance Policy:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Patient)this.Model).InsurancePolicy = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });

            Label lHospitals = new Label()
            {
                Content = "Rooms:"
            };
            var tempCrud = DbCrud;
            DbCrud = new MSSQLDB.CRUD.CRUDRoom();
            Rooms = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Room)x).ToList();
            Rooms = Rooms.Where(x => x.Capacity > 0).ToList();
            DbCrud = tempCrud;
            // napravi proceduru da vrati departman za sobu
            var names = Rooms.Select(x => String.Format("Floor:{0} Capacity:{1}", x.Floor, x.Capacity));

            ComboBox cb = new ComboBox();
            cb.ItemsSource = names;
            cb.SelectionChanged += Cb_SelectionChanged;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals, cb
            });


            Label lHospitals1 = new Label()
            {
                Content = "Doctors:"
            };
            tempCrud = DbCrud;
            DbCrud = new MSSQLDB.CRUD.CRUDDoctor();
            Doctors = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Doctor)x).ToList();
            DbCrud = tempCrud;
            
            DoctorsLb = new ListBox();
            DoctorsLb.SelectionMode = SelectionMode.Multiple;
            DoctorsLb.ItemsSource = Doctors;
            DoctorsLb.SelectionChanged += Cb_SelectionChanged2;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals1, DoctorsLb
            });

            Label lHospitals2 = new Label()
            {
                Content = "Nurses:"
            };
            tempCrud = DbCrud;
            DbCrud = new MSSQLDB.CRUD.CRUDNurse();
            Nurses = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Nurse)x).ToList();
            DbCrud = tempCrud;

            NursesLb = new ListBox();
            NursesLb.SelectionMode = SelectionMode.Multiple;
            NursesLb.ItemsSource = Nurses;
            NursesLb.SelectionChanged += Cb_SelectionChanged2;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals2, NursesLb
            });

        }

        ListBox DoctorsLb = new ListBox();
        ListBox NursesLb = new ListBox();

        private void Cb_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            //ListBox cb = sender as ListBox;
            //DoctorId = this.Doctors[cb.SelectedIndex].IDP;
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.Patient)this.Model).RoomId = this.Rooms[cb.SelectedIndex].IDRoom;
        }

        public override Models.AppModels.ISystemModel GetModel()
        {
            var selected = DoctorsLb.SelectedItems.OfType<Models.AppModels.Doctor>().ToList();
            selected.ForEach(s => ((Models.AppModels.Patient)this.Model).DoctorIds.Add(s.IDP));

            var nursesSel = NursesLb.SelectedItems.OfType<Models.AppModels.Nurse>().ToList();
            nursesSel.ForEach(s => ((Models.AppModels.Patient)this.Model).NurseIds.Add(s.IDP));

            return Model;
        }
    }
}
