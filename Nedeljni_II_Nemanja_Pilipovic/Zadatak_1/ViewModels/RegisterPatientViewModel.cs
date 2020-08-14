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
    class RegisterPatientViewModel : BaseViewModel
    {

        #region Objects

        RegisterPatientView registerView;

        #endregion

        #region Constructors

        public RegisterPatientViewModel(RegisterPatientView registerViewOpen)
        {
            registerView = registerViewOpen;
            Patient = new tblClinicPatient();
            Genders = GetBothGender();
            Doctors = GetAllAvailableDoctors();
        }

        #endregion

        #region Properties

        private tblClinicPatient patient;

        public tblClinicPatient Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        private List<string> doctors;

        public List<string> Doctors
        {
            get { return doctors; }
            set 
            {
                doctors = value;
                OnPropertyChanged("Doctors");
            }
        }

        private string doctor;

        public string Doctor
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

        private List<string> GetAllAvailableDoctors()
        {
            try
            {
                List<string> doctors = new List<string>();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblClinicDoctor doctor in db.tblClinicDoctors)
                    {
                        doctors.Add(doctor.Name + " " + doctor.Surname);
                    }
                }

                return doctors;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void SaveExecute()
        {
            try
            {
                Patient.Gender = Gender;
                string[] splitDoctorNameAndSurname = Doctor.Split(' ');
                string doctorName = splitDoctorNameAndSurname[0];
                string doctorSurname = splitDoctorNameAndSurname[1];

                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    tblClinicDoctor doctor = db.tblClinicDoctors.Where(d => d.Name == doctorName).FirstOrDefault();
                    Patient.FKDoctor = doctor.Id;
                    Patient.DoctorUniqueNumber = doctor.UniqueNumber;

                    db.tblClinicPatients.Add(Patient);
                    db.SaveChanges();
                }
                MessageBox.Show("Regeistration Successfull!");
                registerView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Patient.Name) || String.IsNullOrEmpty(Patient.Surname)
                || String.IsNullOrEmpty(Patient.IDNumber.ToString())
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(Patient.DateOfBirth.ToString())
                || String.IsNullOrEmpty(Patient.Citizenship)
                || String.IsNullOrEmpty(Patient.Username) || String.IsNullOrEmpty(Patient.Password)
                || String.IsNullOrEmpty(Patient.HealthInsuranceNumber.ToString())
                || String.IsNullOrEmpty(Patient.HealthInsuranceExperationDate.ToString())
                || String.IsNullOrEmpty(Patient.HealthInsuranceNumber.ToString())
                || String.IsNullOrEmpty(Patient.HealthInsuranceExperationDate.ToString()) || String.IsNullOrEmpty(Doctor))
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
            registerView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
