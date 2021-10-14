using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDC.Forms
{
    public abstract class DeveloperConsoleForm : Form
    {
        public abstract void Print(string text);
    }
}
