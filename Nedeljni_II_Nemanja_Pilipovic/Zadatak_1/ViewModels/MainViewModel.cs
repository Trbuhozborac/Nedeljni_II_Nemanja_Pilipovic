using System.Collections.Generic;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Objects

        MainWindow main;

        #endregion

        #region Constructors

        public MainViewModel(MainWindow mainOpen)
        {
            main = mainOpen;           
        }

        #endregion

        #region Properties

       
        #endregion

        #region Commands

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecuteExecute(), param => CanRegisterExecuteExecute());
                }
                return register;
            }
        }

        #endregion

        #region Functions

        private void RegisterExecuteExecute()
        {
            RegisterPatientView view = new RegisterPatientView();
            view.ShowDialog();
        }

        private bool CanRegisterExecuteExecute()
        {
            return true;
        }

        #endregion
    }
}
