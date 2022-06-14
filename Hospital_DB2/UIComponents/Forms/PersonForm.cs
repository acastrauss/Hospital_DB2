using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class PersonForm : IForm
    {
        protected Models.ICRUD.ICRUD DbCrud { get; set; } = null;

        public PersonForm() : base()
        {
            this.Model = new Models.AppModels.Person();

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
                ((Models.AppModels.Person)this.Model).Name = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });
            
            Label lPhoneNumber = new Label()
            {
                Content = "Phone number:"
            };
            TextBox tbPn = new TextBox()
            {
                Width = 100
            };
            tbPn.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Person)this.Model).PhoneNumber = tbPn.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lPhoneNumber, tbPn
            });

            Label lDate = new Label()
            {
                Content = "Date born:"
            };

            DatePicker dp = new DatePicker()
            {
                Width = 100
            };
            dp.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(delegate (object sender, SelectionChangedEventArgs args)
            {
                ((Models.AppModels.Person)this.Model).BirthDate = (DateTime)dp.SelectedDate;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lDate, dp
            });
        }
    }
}
