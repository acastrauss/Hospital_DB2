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

        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.Patient)this.Model).RoomId = this.Rooms[cb.SelectedIndex].IDRoom;
        }
    }
}
