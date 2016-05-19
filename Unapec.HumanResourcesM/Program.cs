using System;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Data;

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
    }
}
