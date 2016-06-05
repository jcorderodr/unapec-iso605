using System;
using System.Drawing;
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
            Icon icon = Icon.FromHandle(Properties.Resources.icon.GetHicon());
            this.Icon = icon;
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
