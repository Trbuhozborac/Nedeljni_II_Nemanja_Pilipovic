using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class UpdateHospitalViewModel : BaseViewModel
    {
        #region Objects

        UpdateHospitalView hospitalView;

        #endregion

        #region Constructors

        public UpdateHospitalViewModel(UpdateHospitalView hospitalViewOpen)
        {
            hospitalView = hospitalViewOpen;
        }

        public UpdateHospitalViewModel(UpdateHospitalView hospitalViewOpen, tblMedicalInstitution updateInstitution)
        {
            hospitalView = hospitalViewOpen;
            Institution = updateInstitution;
        }

        #endregion

        #region Properties

        private tblMedicalInstitution institution;

        public tblMedicalInstitution Institution
        {
            get { return institution; }
            set 
            {
                institution = value;
                OnPropertyChanged("Institution");
            }
        }


        #endregion

        #region Commands

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }


        #endregion

        #region Functions

        private void SaveExecute()
        {
            try
            {
                tblMedicalInstitution onlyInstution = new tblMedicalInstitution();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    onlyInstution = db.tblMedicalInstitutions.Where(i => i.Id > 0).FirstOrDefault();

                    onlyInstution.Owner = Institution.Owner;
                    onlyInstution.DisabledPatitentAccessPointNumber = Institution.DisabledPatitentAccessPointNumber;
                    onlyInstution.AmbulanceAccessPointNumber = Institution.AmbulanceAccessPointNumber;

                    db.SaveChanges();
                }
                MessageBox.Show("Medical Institution Updated Successfully!");
                hospitalView.Close();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            tblMedicalInstitution onlyInstution = new tblMedicalInstitution();
            using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
            {
                onlyInstution = db.tblMedicalInstitutions.Where(i => i.Id > 0).FirstOrDefault();
            }

            if (String.IsNullOrEmpty(Institution.Owner)
                || String.IsNullOrEmpty(Institution.DisabledPatitentAccessPointNumber.ToString())
                || String.IsNullOrEmpty(Institution.AmbulanceAccessPointNumber.ToString()))
            {
                return false;
            }
            else if (Institution.DisabledPatitentAccessPointNumber < onlyInstution.DisabledPatitentAccessPointNumber
                     || Institution.AmbulanceAccessPointNumber < onlyInstution.AmbulanceAccessPointNumber)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CloseExecute()
        {
            hospitalView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
