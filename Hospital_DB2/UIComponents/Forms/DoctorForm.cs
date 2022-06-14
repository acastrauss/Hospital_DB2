using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    class DoctorForm : HCWForm
    {
        public DoctorForm() : base()
        {
            this.Model = new Models.AppModels.Doctor();
            this.DbCrud = new MSSQLDB.CRUD.CRUDDoctor();

            Label lName = new Label()
            {
                Content = "Doctor License:"
            };
            TextBox tbName = new TextBox()
            {
                Width = 100
            };
            tbName.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Doctor)this.Model).DoctorLicense = tbName.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName, tbName
            });

            Label lName1 = new Label()
            {
                Content = "Specialty:"
            };
            TextBox tbName1 = new TextBox()
            {
                Width = 100
            };
            tbName1.TextChanged += new TextChangedEventHandler(delegate (object sender, TextChangedEventArgs args)
            {
                ((Models.AppModels.Doctor)this.Model).Specialty = tbName1.Text;
            });
            this.CreateInnerStackPanel(new List<System.Windows.UIElement>()
            {
                lName1, tbName1
            });


        }
    }
}
