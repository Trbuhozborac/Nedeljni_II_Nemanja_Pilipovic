using System.IO;
using System.Windows;
using Zadatak_1.Views;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;
        private string _password;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            GetMasterCredentials();
            if(_username == txtUsername.Text && _password == txtPassword.Password)
            {
                MasterView view = new MasterView();
                view.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect.");
            }
        }

        private void GetMasterCredentials()
        {
            string _location = @"~\..\..\..\ClientAccess.txt";
            if (File.Exists(_location))
            {
                string[] usernameAndPassword = File.ReadAllLines(_location);
                string[] usernameSplited = usernameAndPassword[0].Split(':');
                _username = usernameSplited[1];

                string[] passwrodSplited = usernameAndPassword[1].Split(':');
                _password = passwrodSplited[1];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File not found...");
            }
        }
    }
}
