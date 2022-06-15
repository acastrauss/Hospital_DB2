using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tabs
{
    enum Entities
    {
        Hospital = 0,
        Department = 1,
        Room = 2,
        Patient = 3,
        Doctor = 4,
        Nurse = 5,
        MedicalRecord = 6
    };
    class CreateTab : ITab
    {
        public Models.ICRUD.ICRUD dbCrud = null;
        public Hospital_DB2.UIComponents.Forms.IForm modelForm = null;
        private StackPanel _BaseStackPannel = new StackPanel();
        private Button _AddEntity = new Button();
        private ComboBox _Entities = new ComboBox()
        {
            Width = 150
        };

        public CreateTab() : base()
        {
            this._Entities.ItemsSource = Enum.GetValues(typeof(Entities)).Cast<Entities>();
            this._Entities.SelectionChanged += _Entities_SelectionChanged;
            this._Entities.MaxHeight = 30;
            this._Entities.MaxWidth = 150;
            this.Children.Add(_Entities);

            _AddEntity.Content = "Add Entity";
            _AddEntity.Width = 75;
            _AddEntity.Height = 30;
            _AddEntity.Click += _AddEntity_Click;
            this.Children.Add(_AddEntity);

            _BaseStackPannel.Orientation = Orientation.Vertical;
            this.Children.Add(_BaseStackPannel);
        }

        private void _Entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            var aaa = cb.SelectedIndex;
            Entities selected = (Entities)aaa;
            _BaseStackPannel.Children.Clear();
            switch (selected)
            {
                case Entities.Hospital:
                    dbCrud = new MSSQLDB.CRUD.CRUDHospital();
                    modelForm = new UIComponents.Forms.HospitalForm();
                    break;
                case Entities.Department:
                    dbCrud = new MSSQLDB.CRUD.CRUDDepartment();
                    modelForm = new UIComponents.Forms.DepartmentForm(dbCrud);
                    break;
                case Entities.Room:
                    dbCrud = new MSSQLDB.CRUD.CRUDRoom();
                    modelForm = new UIComponents.Forms.RoomForm(dbCrud);
                    break;
                case Entities.Patient:
                    dbCrud = new MSSQLDB.CRUD.CRUDPatient();
                    modelForm = new UIComponents.Forms.PatientForm();
                    break;
                case Entities.Doctor:
                    dbCrud = new MSSQLDB.CRUD.CRUDDoctor();
                    modelForm = new UIComponents.Forms.DoctorForm();
                    break;
                case Entities.Nurse:
                    dbCrud = new MSSQLDB.CRUD.CRUDNurse();
                    modelForm = new UIComponents.Forms.NurseForm();
                    break;
                case Entities.MedicalRecord:
                    dbCrud = new MSSQLDB.CRUD.CRUDMedicalRecord();
                    modelForm = new UIComponents.Forms.MedicalRecordForm();
                    break;
                default:
                    break;
            }

            _BaseStackPannel.Children.Add(modelForm);
        }

        private void _AddEntity_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dbCrud.CreateModel(modelForm.GetModel());
            _BaseStackPannel.Children.Clear();
        }
    }
}
