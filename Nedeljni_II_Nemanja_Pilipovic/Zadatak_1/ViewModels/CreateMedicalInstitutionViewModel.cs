using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateMedicalInstitutionViewModel : BaseViewModel
    {
        #region Objects

        CreateMedicalInstitutionView medicalView;

        #endregion

        #region Constructors

        public CreateMedicalInstitutionViewModel(CreateMedicalInstitutionView medicalViewOpen)
        {
            medicalView = medicalViewOpen;
            Institution = new tblMedicalInstitution();
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
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    db.tblMedicalInstitutions.Add(Institution);
                    db.SaveChanges();
                }

                MessageBox.Show("Medical Institution Created Successfully!");
                medicalView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Institution.Name) || String.IsNullOrEmpty(Institution.ConstructionDate.ToString())
                || String.IsNullOrEmpty(Institution.Owner) || String.IsNullOrEmpty(Institution.Address)
                || String.IsNullOrEmpty(Institution.FloorsNumber.ToString())
                || String.IsNullOrEmpty(Institution.PersonsPerFloor.ToString())
                || String.IsNullOrEmpty(Institution.AmbulanceAccessPointNumber.ToString())
                || String.IsNullOrEmpty(Institution.DisabledPatitentAccessPointNumber.ToString()))
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
            medicalView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }


        #endregion
    }
}
