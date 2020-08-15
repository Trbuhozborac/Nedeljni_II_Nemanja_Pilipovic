using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : Window
    {
        public PatientView()
        {
            InitializeComponent();
            this.DataContext = new PatientViewModel(this);
        }

        public PatientView(tblClinicPatient patient)
        {
            InitializeComponent();
            this.DataContext = new PatientViewModel(this, patient);
        }
    }
}
