using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    public class HospitalForm : IForm
    {
        public HospitalForm() : base()
        {
            this.Model = new Models.AppModels.Hospital();

            Label lName = new Label()
            {
                Content = "Name:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Hospital)this.Model).Name = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });

            Label lAddres = new Label()
            {
                Content = "Address:"
            };

            TextBox tbAddress = new TextBox()
            {
                Width = 100
            };
            tbAddress.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Hospital)this.Model).Address = tbAddress.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lAddres, tbAddress
            });

            Label lDate = new Label()
            {
                Content = "Date built:"
            };

            DatePicker dp = new DatePicker()
            {
                Width = 100
            };
            dp.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(delegate (object sender, SelectionChangedEventArgs args)
            {
                ((Models.AppModels.Hospital)this.Model).DateBuilt = (DateTime)dp.SelectedDate;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lDate, dp
            });

            ((Models.AppModels.Hospital)this.Model).Departments = new List<Models.AppModels.Department>();
        }
    }
}
