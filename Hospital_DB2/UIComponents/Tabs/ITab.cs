using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tabs
{
    abstract class ITab : StackPanel
    {
        
        public ITab() : base()
        {
            this.Orientation = Orientation.Horizontal;
        }
    }
}
