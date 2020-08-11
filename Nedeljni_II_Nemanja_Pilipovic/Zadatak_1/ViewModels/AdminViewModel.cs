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

        private ICommand updateHospital;
        public ICommand UpdateHospital
        {
            get
            {
                if (updateHospital == null)
                {
                    updateHospital = new RelayCommand(param => UpdateHospitalExecute(), param => CanUpdateHospitalExecute());
                }
                return updateHospital;
            }
        }

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

        private void UpdateHospitalExecute()
        {
            tblMedicalInstitution institution = new tblMedicalInstitution();
            try
            {
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    institution = db.tblMedicalInstitutions.Where(i => i.Id > 0).FirstOrDefault();
                }
                UpdateHospitalView view = new UpdateHospitalView(institution);
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanUpdateHospitalExecute()
        {
            return true;
        }

        #endregion
    }
}
