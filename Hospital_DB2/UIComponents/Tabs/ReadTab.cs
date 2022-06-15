using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tabs
{
    enum EntititesRMD
    {
        Hospital = 0,
        Department = 1,
        Patient = 2,
        Doctor = 3,
        Nurse = 4,
    }
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
            this._Entities.ItemsSource = Enum.GetValues(typeof(EntititesRMD)).Cast<Entities>();
            this._Entities.SelectedIndex = 0;
            this._Entities.SelectionChanged += _Entities_SelectionChanged;
            this.Children.Add(_Entities);
            this.Children.Add(_Table);
        }

        private void _Entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var aaa = cb.SelectedIndex;
            EntititesRMD selected = (EntititesRMD)aaa;
            this.Children.Remove(_Table);

            switch (selected)
            {
                case EntititesRMD.Hospital:
                    _Table = new Tables.HospitalTable();
                    break;
                case EntititesRMD.Department:
                    _Table = new Tables.DepartmentTable();
                    break;
                case EntititesRMD.Patient:
                    _Table = new Tables.PatientTable();
                    break;
                case EntititesRMD.Doctor:
                    _Table = new Tables.DoctorTable();
                    break;
                case EntititesRMD.Nurse:
                    _Table = new Tables.NurseTable();
                    break;
                default:
                    break;
            }

            this.Children.Add(_Table);
        }
    }
}
