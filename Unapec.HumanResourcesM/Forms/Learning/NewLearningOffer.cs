using System;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Learning
{
    public partial class NewLearningOffer : FormBase
    {

        private readonly CourseService _courseService;

        public NewLearningOffer()
        {
            InitializeComponent();
            this.Text = "Registro de Capacitación";
            _courseService = new CourseService();
            FillComponents();
        }

        private void FillComponents()
        {
            dateTimePickerStartDate.SetDateTimePickerFormat();
            dateTimePickerEndDate.SetDateTimePickerFormat();
        }

        private void CleanComponents()
        {
            txtBoxCapacity.ResetText();
            txtBoxDescription.Clear();
            txtBoxName.Clear();
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
        }

        private bool IsInvalid()
        {
            if(string.IsNullOrEmpty(txtBoxName.Text))
            {
                this.ShowErrorMessage("Debe indicar un nombre para la capacitación.");
                return true;
            }

            if(txtBoxCapacity.Value <= 1)
            {
                this.ShowErrorMessage("La cantidad de participantes debe ser mayor de cero (0).");
                return true;
            }

            if (dateTimePickerStartDate.Value >= dateTimePickerEndDate.Value)
            {
                this.ShowErrorMessage("La Fecha de Inicio no puede  mayor o más reciente a la Fecha de Finalización.");
                return true;
            }


            return false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var dResult = this.ShowQuestionMessage(Strings.Question_CreationFormSubmit);

            if (dResult != System.Windows.Forms.DialogResult.Yes) return;

            if (IsInvalid()) return;

            var course = new Course
            {
                Capacity = txtBoxCapacity.Value.As<int>(),
                Description = txtBoxDescription.Text,
                Name = txtBoxName.Text,
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value
            };
            _courseService.Create(course);
            this.ShowInformationMessage(Strings.Message_FormSubmitSuccess);
            CleanComponents();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
