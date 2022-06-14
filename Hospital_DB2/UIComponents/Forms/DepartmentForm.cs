using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class DepartmentForm : IForm
    {
        private Models.ICRUD.ICRUD DbCrud { get; set; } = null;
        private List<Models.AppModels.Hospital> Hospitals { get; set; } = new List<Models.AppModels.Hospital>();
        public DepartmentForm(Models.ICRUD.ICRUD crud) : base()
        {
            this.Model = new Models.AppModels.Department();
            DbCrud = crud;

            Label lDepartmentField = new Label()
            {
                Content = "Field of medicine:"
            };
            TextBox tbDepartmentField = new TextBox()
            {
                Width = 100
            };
            tbDepartmentField.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Department)this.Model).DepartmentField = tbDepartmentField.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lDepartmentField, tbDepartmentField
            });
            
            Label lPhoneNumber = new Label()
            {
                Content = "Phone number:"
            };
            TextBox tbPhoneNumber = new TextBox()
            {
                Width = 100
            };
            tbPhoneNumber.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Department)this.Model).PhoneNumber = tbPhoneNumber.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lPhoneNumber, tbPhoneNumber
            });

            Label lHospitals = new Label()
            {
                Content = "Hospital:"
            };
            var tempCrud = DbCrud;
            DbCrud = new MSSQLDB.CRUD.CRUDHospital();
            Hospitals = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Hospital)x).ToList();
            var names = Hospitals.Select(x => x.Name);
            DbCrud = tempCrud;

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
            ((Models.AppModels.Department)this.Model).IDH = this.Hospitals[cb.SelectedIndex].IDH;
        }
    }
}
