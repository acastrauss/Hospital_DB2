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
            // napravi proceduru da vrati departman za sobu
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
            DoctorId = this.Doctors[cb.SelectedIndex].IDP;
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.Patient)this.Model).RoomId = this.Rooms[cb.SelectedIndex].IDRoom;
        }

        public override Models.AppModels.ISystemModel GetModel()
        {
            ((Models.AppModels.Patient)this.Model).DoctorIds.Add(DoctorId);
            return Model;
        }
    }
}
