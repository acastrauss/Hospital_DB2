using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tabs
{
    class ReadTab : ITab
    {
        public Models.ICRUD.ICRUD dbCrud = null;
        public Tables.ITable _Table = new Tables.HospitalTable();
        public ComboBox _Entities = new ComboBox()
        {
            Width = 150,
            MaxHeight = 30
        };

        public ReadTab() : base()
        {
            _Table = new Tables.HospitalTable();
            this._Entities.ItemsSource = Enum.GetValues(typeof(Entities)).Cast<Entities>();
            this._Entities.SelectedIndex = 0;
            this._Entities.SelectionChanged += _Entities_SelectionChanged;
            this.Children.Add(_Entities);
            this.Children.Add(_Table);
        }

        private void _Entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var aaa = cb.SelectedIndex;
            Entities selected = (Entities)aaa;
            this.Children.Remove(_Table);

            switch (selected)
            {
                case Entities.Hospital:
                    _Table = new Tables.HospitalTable();
                    break;
                case Entities.Department:
                    _Table = new Tables.DepartmentTable();
                    break;
                case Entities.Room:

                    break;
                case Entities.Patient:
                    _Table = new Tables.PatientTable();
                    break;
                case Entities.Doctor:
                    _Table = new Tables.DoctorTable();
                    break;
                case Entities.Nurse:
                    _Table = new Tables.NurseTable();
                    break;
                case Entities.MedicalRecord:
                    break;
                default:
                    break;
            }

            this.Children.Add(_Table);
        }
    }
}
