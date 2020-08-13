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
    class UpdateManagerViewModel : BaseViewModel
    {
        #region Objects

        UpdateManagerView managerView;

        #endregion

        #region Constructors

        public UpdateManagerViewModel(UpdateManagerView managerViewOpen)
        {
            managerView = managerViewOpen;
        }

        public UpdateManagerViewModel(UpdateManagerView managerViewOpen, tblClinicManager manager)
        {
            managerView = managerViewOpen;
            Manager = manager;
            Genders = GetBothGender();
        }

        #endregion

        #region Properties

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

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private List<string> genders;

        public List<string> Genders
        {
            get { return genders; }
            set
            {
                genders = value;
                OnPropertyChanged("Genders");
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

        private List<string> GetBothGender()
        {
            List<string> genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            return genders;
        }

        private void SaveExecute()
        {
            try
            {
                tblClinicManager updateManager = new tblClinicManager();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    updateManager = db.tblClinicManagers.Where(m => m.Id == Manager.Id).FirstOrDefault();

                    updateManager.Name = Manager.Name;
                    updateManager.Surname = Manager.Surname;
                    updateManager.IDNumber = Manager.IDNumber;
                    updateManager.Gender = Manager.Gender;
                    updateManager.DateOfBirth = Manager.DateOfBirth;
                    updateManager.Citizenship = Manager.Citizenship;
                    updateManager.Username = Manager.Password;
                    updateManager.Floor = Manager.Floor;
                    updateManager.MaxDoctorNumber = Manager.MaxDoctorNumber;
                    updateManager.MaxPatientNumber = Manager.MaxPatientNumber;

                    db.SaveChanges();
                }
                MessageBox.Show("Manager Updated Successfully!");
                managerView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Manager.Name) || String.IsNullOrEmpty(Manager.Surname)
                || String.IsNullOrEmpty(Manager.IDNumber.ToString())
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(Manager.DateOfBirth.ToString())
                || String.IsNullOrEmpty(Manager.Citizenship)
                || String.IsNullOrEmpty(Manager.Username) || String.IsNullOrEmpty(Manager.Password)
                || String.IsNullOrEmpty(Manager.MaxDoctorNumber.ToString())
                || String.IsNullOrEmpty(Manager.MaxPatientNumber.ToString()))
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
            managerView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
