using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents.DocumentStructures;
using System.Security.RightsManagement;

namespace MagazinElectronic
{
    public class Account 
    {
        private string _name;
        private string _password;

        public Account(string name, string password)
        {
            _name = name;
            _password = password;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
               
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
               
            }
        }

       
    }
}
