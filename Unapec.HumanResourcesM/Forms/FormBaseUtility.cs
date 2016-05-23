using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Forms
{
    public class FormBaseUtility : FormBase
    {

        public FormBaseUtility()
        {
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        }

    }
}
