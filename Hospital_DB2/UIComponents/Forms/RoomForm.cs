using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hospital_DB2.UIComponents.Forms
{
    class RoomForm : IForm
    {
        private Models.ICRUD.ICRUD DbCrud { get; set; } = null;
        private List<Models.AppModels.Department> Departments { get; set; } = new List<Models.AppModels.Department>();

        public RoomForm(Models.ICRUD.ICRUD crud) : base()
        {
            this.Model = new Models.AppModels.Room();
            DbCrud = crud;

            Label label1 = new Label()
            {
                Content = "Capacity:"
            };
            TextBox tb1 = new TextBox()
            {
                Width = 100
            };
            tb1.PreviewTextInput += NumberValidationTB;

            tb1.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Room)this.Model).Capacity = int.Parse(tb1.Text);
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                label1, tb1
            });

            Label label2 = new Label()
            {
                Content = "Floor:"
            };
            TextBox tb2 = new TextBox()
            {
                Width = 100
            };
            tb2.PreviewTextInput += NumberValidationTB;

            tb2.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Room)this.Model).Floor = int.Parse(tb2.Text);
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                label2, tb2
            });

            Label label3 = new Label()
            {
                Content = "Departments:"
            };
            var tempCrud = DbCrud;
            DbCrud = new MSSQLDB.CRUD.CRUDDepartment();
            Departments = DbCrud.ReadAllModes().Select(x => (Models.AppModels.Department)x).ToList();
            var fields = Departments.Select(x => x.DepartmentField);
            DbCrud = tempCrud;

            ComboBox cb = new ComboBox();
            cb.ItemsSource = fields;
            cb.SelectionChanged += Cb_SelectionChanged;
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                label3, cb
            });
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ((Models.AppModels.Room)this.Model).IDDep = this.Departments[cb.SelectedIndex].IDDep;
            ((Models.AppModels.Room)this.Model).IDH = this.Departments[cb.SelectedIndex].IDH;
        }

        private void NumberValidationTB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
