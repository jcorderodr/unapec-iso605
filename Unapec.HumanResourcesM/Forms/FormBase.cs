using System;
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
            
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
           
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormBase";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.ResumeLayout(false);
        }

    }
}
