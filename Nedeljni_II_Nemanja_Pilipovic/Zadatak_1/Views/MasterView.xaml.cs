using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MasterView.xaml
    /// </summary>
    public partial class MasterView : Window
    {
        public MasterView()
        {
            InitializeComponent();
            this.DataContext = new MasterViewModel(this);
        }
    }
}
