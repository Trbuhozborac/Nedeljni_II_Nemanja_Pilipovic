using System;
using System.Linq;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MasterViewModel : BaseViewModel
    {
        #region Objects

        MasterView master;

        #endregion

        #region Constructors

        public MasterViewModel(MasterView masterOpen)
        {
            master = masterOpen;
        }

        #endregion

        #region Commands

        private ICommand createAdmin;
        public ICommand CreateAdmin
        {
            get
            {
                if (createAdmin == null)
                {
                    createAdmin = new RelayCommand(param => CreateAdminExecute(), param => CanCreateAdminExecute());
                }
                return createAdmin;
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

        private void CreateAdminExecute()
        {
            CreateAdminView view = new CreateAdminView();
            view.ShowDialog();
        }

        private bool CanCreateAdminExecute()
        {
            try
            {
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    if (db.tblClinicAdmins.Any())
                    {
                        return false;
                    }
                    else return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }                       
        }

        private void LogoutExecute()
        {
            master.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
