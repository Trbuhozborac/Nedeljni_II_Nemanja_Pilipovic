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
    class UpdateMaintanceViewModel : BaseViewModel
    {
        #region Objects

        UpdateMaintanceView updateView;

        #endregion

        #region Constructors

        public UpdateMaintanceViewModel(UpdateMaintanceView updateViewOpen)
        {
            updateView = updateViewOpen;
        }

        public UpdateMaintanceViewModel(UpdateMaintanceView updateViewOpen, tblClinicMaintance updateMaintance)
        {
            updateView = updateViewOpen;
            Maintance = updateMaintance;
            Genders = GetBothGender();
        }

        #endregion

        #region Proeprties

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
                tblClinicMaintance updateMaintance = new tblClinicMaintance();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities()) 
                {
                    updateMaintance = db.tblClinicMaintances.Where(m => m.Id == Maintance.Id).FirstOrDefault();

                    updateMaintance.Name = Maintance.Name;
                    updateMaintance.Surname = Maintance.Surname;
                    updateMaintance.IDNumber = Maintance.IDNumber;
                    updateMaintance.Gender = Maintance.Gender;
                    updateMaintance.DateOfBirth = Maintance.DateOfBirth;
                    updateMaintance.Citizenship = Maintance.Citizenship;
                    updateMaintance.Username = Maintance.Password;
                    updateMaintance.ExpendClinicPermission = Maintance.ExpendClinicPermission;
                    updateMaintance.InChargeOfAmbulanceAccess = Maintance.InChargeOfAmbulanceAccess;
                    updateMaintance.InChargeOfDisabledPatientAccess = Maintance.InChargeOfDisabledPatientAccess;

                    db.SaveChanges();
                }
                MessageBox.Show("Maintance Updated Successfully!");
                updateView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Maintance.Name) || String.IsNullOrEmpty(Maintance.Surname) || String.IsNullOrEmpty(Maintance.IDNumber.ToString())
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(Maintance.DateOfBirth.ToString())
                || String.IsNullOrEmpty(Maintance.Citizenship)
                || String.IsNullOrEmpty(Maintance.Username) || String.IsNullOrEmpty(Maintance.Password))
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
            updateView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
