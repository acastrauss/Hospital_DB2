using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_DB2
{

    enum Entities
    {
        Hospital = 0,
        Department = 1,
        Room = 2,
        Patient = 3,
        Doctor = 4,
        Nurse = 5
    };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Models.ICRUD.ICRUD dbCrud = null;
        public Hospital_DB2.UIComponents.Forms.IForm modelForm = null;

        public MainWindow()
        {
            InitializeComponent();
            
            EntitiesSelect.ItemsSource = Enum.GetValues(typeof(Entities)).Cast<Entities>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbCrud.CreateModel(modelForm.Model);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            var aaa = cb.SelectedIndex;
            Entities selected = (Entities)aaa;
            formDiv.Children.Clear();
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
                default:
                    break;
            }

            formDiv.Children.Add(modelForm);
        }
    }
}
