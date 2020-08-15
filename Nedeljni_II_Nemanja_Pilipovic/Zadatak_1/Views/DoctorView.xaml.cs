using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for DoctorView.xaml
    /// </summary>
    public partial class DoctorView : Window
    {
        public DoctorView(tblClinicDoctor doctor)
        {
            InitializeComponent();
            this.DataContext = new DoctorViewModel(this, doctor);
        }
    }
}
