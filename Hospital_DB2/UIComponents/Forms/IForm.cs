using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Forms
{
    public abstract class IForm : StackPanel
    {
        public Models.AppModels.ISystemModel Model { get; set; } = null;

        public IForm() : base()
        {
            this.Orientation = Orientation.Vertical;
        }

        protected void CreateInnerStackPanel(ICollection<System.Windows.UIElement> uiElements)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            foreach (var el in uiElements)
            {
                sp.Children.Add(el);
            }

            this.Children.Add(sp);
        }

        public virtual Models.AppModels.ISystemModel GetModel()
        {
            return Model;
        }
    }
}
