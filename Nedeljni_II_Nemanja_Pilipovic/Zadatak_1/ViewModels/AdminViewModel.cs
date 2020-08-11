using System;
using System.Linq;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdminViewModel : BaseViewModel
    {
        #region Objects

        AdminView adminView;

        #endregion

        #region Constructors

        public AdminViewModel(AdminView adminViewOpen)
        {
            adminView = adminViewOpen;
        }

        #endregion

        #region Properties



        #endregion

        #region Commands

        //TODO update klinike da li ce moci vise ili samo jednu

        private ICommand createMaintance;
        public ICommand CreateMaintance
        {
            get
            {
                if (createMaintance == null)
                {
                    createMaintance = new RelayCommand(param => CreateMaintanceExecute(), param => CanCreateMaintanceExecute());
                }
                return createMaintance;
            }
        }


        #endregion

        #region Functions

        private void CreateMaintanceExecute()
        {
            CreateMaintanceView view = new CreateMaintanceView();
            view.ShowDialog();
        }

        private bool CanCreateMaintanceExecute()
        {
            return true;
        }

        #endregion
    }
}
