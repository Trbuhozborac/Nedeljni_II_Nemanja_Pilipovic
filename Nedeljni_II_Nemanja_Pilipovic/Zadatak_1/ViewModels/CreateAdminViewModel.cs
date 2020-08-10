using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateAdminViewModel : BaseViewModel
    {
        #region Objects

        CreateAdminView adminView;

        #endregion

        #region Constructors

        public CreateAdminViewModel(CreateAdminView adminViewOpen)
        {
            adminView = adminViewOpen;
            Admin = new tblClinicAdmin();
            Genders = GetBothGender();
        }

        #endregion

        #region Properties

        private tblClinicAdmin admin;

        public tblClinicAdmin Admin
        {
            get { return admin; }
            set 
            {
                admin = value;
                OnPropertyChanged("Admin");
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

         private void SaveExecute()
        {
            try
            {
                Admin.Gender = Gender;
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities()) 
                {
                    db.tblClinicAdmins.Add(Admin);
                    db.SaveChanges();
                }
                MessageBox.Show("Admin Created Successfully!");
                adminView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Admin.Name) || String.IsNullOrEmpty(Admin.Surname) || String.IsNullOrEmpty(Admin.IDNumber.ToString())
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(Admin.DateOfBirth.ToString()) 
                || String.IsNullOrEmpty(Admin.Citizenship)
                || String.IsNullOrEmpty(Admin.Username) || String.IsNullOrEmpty(Admin.Password))
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
            adminView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private List<string> GetBothGender()
        {
            List<string> genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            return genders;
        }

        #endregion
    }
}
