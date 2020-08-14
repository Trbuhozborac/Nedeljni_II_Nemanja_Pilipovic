using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateDoctorViewModel : BaseViewModel
    {
        #region Objects

        CreateDoctorView doctorView;

        #endregion

        #region Constructors

        public CreateDoctorViewModel(CreateDoctorView doctorViewOpen)
        {
            doctorView = doctorViewOpen;
        }

        public CreateDoctorViewModel(CreateDoctorView doctorViewOpen, tblClinicManager manager)
        {
            doctorView = doctorViewOpen;
            User = manager;
            Genders = GetBothGender();
            Doctor = new tblClinicDoctor();
            Shifts = GetAllShifts();
        }

        #endregion

        #region Properties

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

        private void SaveExecute()
        {
            if (!CheckForManagerMaxDoctorNumber() || !CheckForNumberOfOmissions())
            {
                MessageBox.Show("Cant Add Doctor. Manager Have Max Nunmber of Patients or more than 5 Omissions.");
            }
            else
            {
                try
                {
                    Doctor.Gender = Gender;
                    Doctor.Shift = Shift;
                    Doctor.FKManager = User.Id;


                    using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                    {
                        db.tblClinicDoctors.Add(Doctor);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Doctor Added Successfully!");
                    doctorView.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
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
            else if(Doctor.UniqueNumber.ToString().Length != 5)
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

        private List<string> GetAllShifts()
        {
            List<string> shifts = new List<string>();
            shifts.Add("Morning");
            shifts.Add("Afternoon");
            shifts.Add("Night");
            shifts.Add("24h");
            return shifts;
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
                        if(doctor.FKManager == User.Id)
                        {
                            counter++;
                        }
                    }
                }

                if(counter >= User.MaxDoctorNumber)
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
            if(User.OmissionNumber > 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
