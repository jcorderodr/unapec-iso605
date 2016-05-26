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
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        }

    }
}
