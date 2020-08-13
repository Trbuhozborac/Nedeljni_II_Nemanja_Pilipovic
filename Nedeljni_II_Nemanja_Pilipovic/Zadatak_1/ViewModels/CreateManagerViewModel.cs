using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateManagerViewModel : BaseViewModel
    {
        #region Objects

        CreateManagerView managerView;

        #endregion

        #region Constructors

        public CreateManagerViewModel(CreateManagerView managerViewOpen)
        {
            managerView = managerViewOpen;
            Manager = new tblClinicManager();
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
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    Manager.Gender = Gender;
                    db.tblClinicManagers.Add(Manager);
                    db.SaveChanges();
                }

                MessageBox.Show("Clinic Manager Created Succesffully!");
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
