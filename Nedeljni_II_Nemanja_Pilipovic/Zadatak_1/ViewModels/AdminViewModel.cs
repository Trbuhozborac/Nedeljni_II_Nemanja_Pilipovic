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
            AllManagers = GetAllManagers();
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

        private tblClinicManager manager;

        public tblClinicManager Manager
        {
            get { return manager; }
            set 
            { 
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<tblClinicManager> allManagers;

        public List<tblClinicManager> AllManagers
        {
            get { return allManagers; }
            set 
            {
                allManagers = value;
                OnPropertyChanged("AllManagers");
            }
        }


        #endregion

        #region Commands

        private ICommand createManager;
        public ICommand CreateManager
        {
            get
            {
                if (createManager == null)
                {
                    createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return createManager;
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

        private ICommand updateManager;
        public ICommand UpdateManager
        {
            get
            {
                if (updateManager == null)
                {
                    updateManager = new RelayCommand(param => UpdateManagerExecute(), param => CanUpdateManagerExecute());
                }
                return updateManager;
            }
        }

        private ICommand deleteManager;
        public ICommand DeleteManager
        {
            get
            {
                if (deleteManager == null)
                {
                    deleteManager = new RelayCommand(param => DeleteManagerExecute(), param => CanDeleteManagerExecute());
                }
                return deleteManager;
            }
        }

        #endregion

        #region Functions

        private void CreateMaintanceExecute()
        {
            CreateMaintanceView view = new CreateMaintanceView();
            view.ShowDialog();
            AllMaintances = GetAllMaintances();
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

        private void CreateManagerExecute()
        {
            CreateManagerView view = new CreateManagerView();
            view.ShowDialog();
            AllManagers = GetAllManagers();
        }

        private bool CanCreateManagerExecute()
        {
            return true;
        }

        private List<tblClinicManager> GetAllManagers()
        {
            List<tblClinicManager> managers = new List<tblClinicManager>();

            try
            {
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    managers = db.tblClinicManagers.Where(m => m.Id > 0).ToList();
                    return managers;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void UpdateManagerExecute()
        {
            UpdateManagerView view = new UpdateManagerView(Manager);
            view.ShowDialog();
            AllManagers = GetAllManagers();
        }

        private bool CanUpdateManagerExecute()
        {
            return true;
        }

        private void DeleteManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you Sure?", "Confirm Deleting", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                        {
                            tblClinicManager manager = db.tblClinicManagers.Where(m => m.Id == Manager.Id).First();
                            db.tblClinicManagers.Remove(manager);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Manager Deleted.");
                        AllManagers = GetAllManagers();
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

        private bool CanDeleteManagerExecute()
        {
            return true;
        }

        #endregion
    }
}
