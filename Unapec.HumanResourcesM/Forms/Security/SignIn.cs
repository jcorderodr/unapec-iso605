using System;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Security
{
    public partial class SignIn : FormBaseUtility
    {
        private readonly UserService _userService;
        private Employee _user;

        public SignIn()
        {
            InitializeComponent();
            ShowApplicantFooter = true;
            //
            _userService = new UserService();
        }

        public bool ShowApplicantFooter
        {

            set
            {
                label1.Visible = value;
                label2.Visible = value;
                linkLabelRegisterCandidate.Visible = value;
            }
        }


        public Employee GetSigned()
        {
            return _user;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            this.Text += " Inicio de Sesión";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //var tryLogin = _userService.DoLogin(txtUsername.Text, txtPassword.Text);
            //if (tryLogin == null)
            //{
            //    if (_userService.IsFirstLoginAttempt(txtUsername.Text))
            //    {
            //        this.ShowErrorMessage(Strings.Message_FirstLogin);
            //        return;
            //    }
            //    this.ShowErrorMessage(Strings.Message_WrongCredentials);
            //    return;
            //}
            //_user = tryLogin;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelRegisterCandidate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            txtUsername.Text = System.Text.RegularExpressions.Regex.Replace(txtUsername.Text, "[^0-9]", "");
        }
    }
}
