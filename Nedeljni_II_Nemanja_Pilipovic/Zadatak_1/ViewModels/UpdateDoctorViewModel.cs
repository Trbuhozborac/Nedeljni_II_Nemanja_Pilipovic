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
    class UpdateDoctorViewModel : BaseViewModel
    {

        #region Objects

        UpdateDoctorView doctorView;

        #endregion

        #region Constructors

        public UpdateDoctorViewModel(UpdateDoctorView doctorViewOpen)
        {
            doctorView = doctorViewOpen;
        }

        public UpdateDoctorViewModel(UpdateDoctorView doctorViewOpen, tblClinicDoctor doctor)
        {
            doctorView = doctorViewOpen;
            Doctor = doctor;
            User = GetDoctorsManager();
            Genders = GetBothGender();
            Shifts = GetAllShifts();
        }

        #endregion

        #region Properties

        private tblClinicDoctor doctor;

        public tblClinicDoctor Doctor
        {
            get { return doctor; }
            set 
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        private tblClinicManager user;

        public tblClinicManager User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
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

        private List<string> shifts;

        public List<string> Shifts
        {
            get { return shifts; }
            set
            {
                shifts = value;
                OnPropertyChanged("Shifts");
            }
        }

        private string shift;

        public string Shift
        {
            get { return shift; }
            set
            {
                shift = value;
                OnPropertyChanged("Shift");
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

        private List<string> GetAllShifts()
        {
            List<string> shifts = new List<string>();
            shifts.Add("Morning");
            shifts.Add("Afternoon");
            shifts.Add("Night");
            shifts.Add("24h");
            return shifts;
        }

        private void SaveExecute()
        {
            try
            {
                tblClinicDoctor doctor = new tblClinicDoctor();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    doctor = db.tblClinicDoctors.Where(d => d.Id == Doctor.Id).FirstOrDefault();

                    doctor.Name = Doctor.Name;
                    doctor.Surname = Doctor.Surname;
                    doctor.IDNumber = Doctor.IDNumber;
                    doctor.Gender = Doctor.Gender;
                    doctor.DateOfBirth = Doctor.DateOfBirth;
                    doctor.Citizenship = Doctor.Citizenship;
                    doctor.Username = Doctor.Password;
                    doctor.UniqueNumber = Doctor.UniqueNumber;
                    doctor.AccountNumber = Doctor.AccountNumber;
                    doctor.Department = Doctor.Department;
                    doctor.Shift = Doctor.Shift;

                    db.SaveChanges();
                }

                MessageBox.Show("Doctor Updated Succesfulyy!");
                doctorView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Doctor.Name) || String.IsNullOrEmpty(Doctor.Surname)
                || String.IsNullOrEmpty(Doctor.IDNumber.ToString())
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(Doctor.DateOfBirth.ToString())
                || String.IsNullOrEmpty(Doctor.Citizenship)
                || String.IsNullOrEmpty(Doctor.Username) || String.IsNullOrEmpty(Doctor.Password)
                || String.IsNullOrEmpty(Doctor.UniqueNumber.ToString()) || String.IsNullOrEmpty(Doctor.AccountNumber.ToString())
                || String.IsNullOrEmpty(Doctor.Department) || String.IsNullOrEmpty(Shift))
            {
                return false;
            }
            else if (Doctor.UniqueNumber.ToString().Length != 5)
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
            doctorView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private bool CheckForManagerMaxDoctorNumber()
        {
            try
            {
                int counter = 0;
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblClinicDoctor doctor in db.tblClinicDoctors)
                    {
                        if (doctor.FKManager == User.Id)
                        {
                            counter++;
                        }
                    }
                }

                if (counter >= User.MaxDoctorNumber)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CheckForNumberOfOmissions()
        {
            if (User.OmissionNumber > 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private tblClinicManager GetDoctorsManager()
        {
            try
            {
                tblClinicManager manager = new tblClinicManager();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    manager = db.tblClinicManagers.Where(m => m.Id == Doctor.FKManager).FirstOrDefault();
                }
                return manager;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
