using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinElectronic
{
    internal class AdminMenu
    {
        public Action goBack;
        private void Window_Closed(object sender, EventArgs e)
        {
            goBack();
        }
    }
}
