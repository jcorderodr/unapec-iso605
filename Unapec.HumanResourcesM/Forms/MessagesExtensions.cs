using System.Windows.Forms;

namespace Unapec.HumanResourcesM.Forms
{
    internal static class MessagesExtensions
    {

        public static DialogResult ShowErrorMessage(this FormBase form, string message)
        {
            MessageBox.Show(form, message, Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return DialogResult.OK;
        }

        public static DialogResult ShowInformationMessage(this FormBase form, string message)
        {
            MessageBox.Show(form, message, Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return DialogResult.OK;
        }

        public static DialogResult ShowQuestionMessage(this FormBase form, string message)
        {
            return MessageBox.Show(form, message, Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowWarningMessage(this FormBase form, string message)
        {
            return MessageBox.Show(form, message, Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }


    }
}
