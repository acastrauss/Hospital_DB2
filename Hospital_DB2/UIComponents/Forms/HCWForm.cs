using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class HCWForm : PersonForm
    {
        private List<Models.AppModels.Department> Departments { get; set; } = new List<Models.AppModels.Department>();

        public HCWForm() : base()
        {
            this.Model = new Models.AppModels.HealthCareWorker();
            this.DbCrud = null;

            Label lName = new Label()
            {
                Content = "Medical license:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.HealthCareWorker)this.Model).MedicalLicense = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });

            Label lName1 = new Label()
            {
                Content = "Degree of education:"
            };
            TextBox tbName1 = new TextBox()
            {
                Width = 100
            };
            tbName1.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.HealthCareWorker)this.Model).DegreeOfEducation = tbName1.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName1, tbName1
            });

            Label lHospitals = new Label()
            {
                Content = "Departments:"
            };
            DbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            Departments = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Department)x).ToList();
            var fields = Departments.Select(x => x.DepartmentField).ToList();
            ComboBox cb = new ComboBox();
            cb.ItemsSource = fields;
            cb.SelectionChanged += Cb_SelectionChanged;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lHospitals, cb
            });
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.HealthCareWorker)this.Model).IDDep = this.Departments[cb.SelectedIndex].IDDep;
            ((Models.AppModels.HealthCareWorker)this.Model).IDH = this.Departments[cb.SelectedIndex].IDH;
        }
    }
}
