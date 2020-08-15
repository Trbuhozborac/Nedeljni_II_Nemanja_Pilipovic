using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        #region Objects

        ManagerView managerView;

        #endregion

        #region Constructors

        public ManagerViewModel(ManagerView managerViewOpen)
        {
            managerView = managerViewOpen;
        }

        public ManagerViewModel(ManagerView managerViewOpen, tblClinicManager manager)
        {
            managerView = managerViewOpen;
            User = manager;
            AllDoctors = GetAllDoctorsOfThisManager();
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

        private List<tblClinicDoctor> allDoctors;

        public List<tblClinicDoctor> AllDoctors
        {
            get { return allDoctors; }
            set 
            {
                allDoctors = value;
                OnPropertyChanged("AllDoctors");
            }
        }

        #endregion

        #region Commands

        private ICommand createDoctor;
        public ICommand CreateDoctor
        {
            get
            {
                if (createDoctor == null)
                {
                    createDoctor = new RelayCommand(param => CreateDoctorExecute(), param => CanCreateDoctorExecute());
                }
                return createDoctor;
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

        private ICommand updateDoctor;
        public ICommand UpdateDoctor
        {
            get
            {
                if (updateDoctor == null)
                {
                    updateDoctor = new RelayCommand(param => UpdateDoctorExecute(), param => CanUpdateDoctorExecute());
                }
                return updateDoctor;
            }
        }

        #endregion

        #region Functions

        private void CreateDoctorExecute()
        {
            CreateDoctorView view = new CreateDoctorView(User);
            view.ShowDialog();
            AllDoctors = GetAllDoctorsOfThisManager();
        }

        private bool CanCreateDoctorExecute()
        {
            return true;
        }

        private void LogoutExecute()
        {
            managerView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        private List<tblClinicDoctor> GetAllDoctorsOfThisManager()
        {
            try
            {
                List<tblClinicDoctor> doctors = new List<tblClinicDoctor>();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblClinicDoctor doctor in db.tblClinicDoctors)
                    {
                        if(doctor.FKManager == User.Id)
                        {
                            doctors.Add(doctor);
                        }
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

        private void UpdateDoctorExecute()
        {
            UpdateDoctorView view = new UpdateDoctorView(Doctor);
            view.ShowDialog();
        }

        private bool CanUpdateDoctorExecute()
        {
            return true;
        }

        #endregion
    }
}
