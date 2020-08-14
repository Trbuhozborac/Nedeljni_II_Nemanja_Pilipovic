using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for UpdateDoctorView.xaml
    /// </summary>
    public partial class UpdateDoctorView : Window
    {
        public UpdateDoctorView()
        {
            InitializeComponent();
            this.DataContext = new UpdateDoctorViewModel(this);
        }

        public UpdateDoctorView(tblClinicDoctor doctor)
        {
            InitializeComponent();
            this.DataContext = new UpdateDoctorViewModel(this, doctor);
        }

        /// <summary>
        /// Validate that User input are just letters
        /// </summary>
        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Validate that User input is just letters and digits
        /// </summary>
        private void LetterAndNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Validate that User input is just numbers
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
