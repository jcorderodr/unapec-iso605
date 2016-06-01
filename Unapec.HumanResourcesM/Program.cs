using System;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo(Framework.Helpers.FormatHelper.APP_CULTURE);
            System.Globalization.CultureInfo.CurrentCulture = Application.CurrentCulture;
            System.Globalization.CultureInfo.CurrentUICulture = Application.CurrentCulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = Application.CurrentCulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = Application.CurrentCulture;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(Application.CurrentCulture);

            Application.ThreadException += Application_ThreadException;

            var signIn = new Forms.Security.SignIn();
            var signInResult = signIn.ShowDialog();
            if (signInResult != DialogResult.OK && signInResult != DialogResult.Ignore) return;

            if(signInResult == DialogResult.Ignore)
            {
                Application.Run(new Forms.Candidates.NewApplicationWizard());
                Application.Restart();
            }
            else
            {
                Application.Run(new Forms.MainForm());
            }
            
        }

        public readonly static string AppName = Resources.Strings.AppName;

        public static Employee SignedUser { get; internal set; }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Forms.MessagesExtensions.ShowErrorMessage(null, e.Exception.Message);
        }
    }
}
