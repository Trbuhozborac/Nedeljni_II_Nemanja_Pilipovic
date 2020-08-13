using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MaintanceView.xaml
    /// </summary>
    public partial class MaintanceView : Window
    {
        public MaintanceView()
        {
            InitializeComponent();
            this.DataContext = new MaintanceViewModel(this);
        }

        public MaintanceView(tblClinicMaintance user)
        {
            InitializeComponent();
            this.DataContext = new MaintanceViewModel(this, user);
        }
    }
}
