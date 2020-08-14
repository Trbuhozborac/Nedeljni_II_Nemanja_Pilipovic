using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        #region Objects

        ManagerView managerView;

        #endregion

        #region Constructors

        public ManagerViewModel(ManagerView managerViewOpen)
        {
            managerView = managerViewOpen;
        }

        public ManagerViewModel(ManagerView managerViewOpen, tblClinicManager manager)
        {
            managerView = managerViewOpen;
            User = manager;
        }

        #endregion

        #region Properties

        private tblClinicManager user;

        public tblClinicManager User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        #endregion

        #region Commands

        private ICommand createDoctor;
        public ICommand CreateDoctor
        {
            get
            {
                if (createDoctor == null)
                {
                    createDoctor = new RelayCommand(param => CreateDoctorExecute(), param => CanCreateDoctorExecute());
                }
                return createDoctor;
            }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        #endregion

        #region Functions

        private void CreateDoctorExecute()
        {
            CreateDoctorView view = new CreateDoctorView(User);
            view.ShowDialog();
        }

        private bool CanCreateDoctorExecute()
        {
            return true;
        }

        private void LogoutExecute()
        {
            managerView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
