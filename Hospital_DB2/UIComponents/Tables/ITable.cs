using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital_DB2.UIComponents.Tables
{
    abstract class ITable : StackPanel
    {
        public Models.ICRUD.ICRUD dbCrud = null;

        public ITable() : base()
        {
            this.Orientation = Orientation.Vertical;
        }


        protected abstract void AddHeader();
    }
}
