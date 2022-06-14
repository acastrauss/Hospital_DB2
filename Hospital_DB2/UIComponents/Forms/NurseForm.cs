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
    class NurseForm : HCWForm
    {
        public NurseForm() : base()
        {
            this.Model = new Models.AppModels.Nurse();
            this.DbCrud = new MSSQLDB.CRUD.CRUDNurse();

            Label lName = new Label()
            {
                Content = "Seniority level:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.PreviewTextInput += NumberValidationTB;
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Nurse)this.Model).SeniorityLevel = int.Parse(tbName.Text);
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });
        }

        private void NumberValidationTB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
