using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            AllMaintances = GetAllMaintances();
            
        }

        #endregion

        #region Properties

        private tblClinicMaintance maintance;

        public tblClinicMaintance Maintance
        {
            get { return maintance; }
            set 
            {
                maintance = value;
                OnPropertyChanged("Maintance");
            }
        }

        private List<tblClinicMaintance> allMaintances;

        public List<tblClinicMaintance> AllMaintances
        {
            get { return allMaintances; }
            set 
            {
                allMaintances = value;
                OnPropertyChanged("AllMaintances");
            }
        }

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

        private ICommand updateMaintance;
        public ICommand UpdateMaintance
        {
            get
            {
                if (updateMaintance == null)
                {
                    updateMaintance = new RelayCommand(param => UpdateMaintanceExecute(), param => CanUpdateMaintanceExecute());
                }
                return updateMaintance;
            }
        }

        private ICommand deleteMaintance;
        public ICommand DeleteMaintance
        {
            get
            {
                if (deleteMaintance == null)
                {
                    deleteMaintance = new RelayCommand(param => DeleteMaintanceExecute(), param => CanDeleteMaintanceExecute());
                }
                return deleteMaintance;
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

        private List<tblClinicMaintance> GetAllMaintances()
        {
            try
            {
                List<tblClinicMaintance> maintances = new List<tblClinicMaintance>();

                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblClinicMaintance maintance in db.tblClinicMaintances)
                    {
                        maintances.Add(maintance);
                    }
                }

                return maintances;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void UpdateMaintanceExecute()
        {
            UpdateMaintanceView view = new UpdateMaintanceView(Maintance);
            view.ShowDialog();
        }

        private bool CanUpdateMaintanceExecute()
        {
            return true;
        }

        private void DeleteMaintanceExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you Sure?", "Confirm Deleting", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                        {
                            tblClinicMaintance maintance = db.tblClinicMaintances.Where(m => m.Id == Maintance.Id).FirstOrDefault();
                            db.tblClinicMaintances.Remove(maintance);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Maintance Deleted.");
                        AllMaintances = GetAllMaintances();
                        break;
                    case MessageBoxResult.No:                        
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanDeleteMaintanceExecute()
        {
            return true;
        }

        private void LogoutExecute()
        {
            adminView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
