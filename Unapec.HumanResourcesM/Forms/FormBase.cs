using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unapec.HumanResourcesM.Forms
{
    public class FormBase : Form
    {

        public FormBase()
        {
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            this.Text = Program.AppName;
        }
    }
}
