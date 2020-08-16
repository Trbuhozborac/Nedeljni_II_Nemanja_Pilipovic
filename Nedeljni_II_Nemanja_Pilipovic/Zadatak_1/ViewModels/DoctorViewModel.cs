using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class DoctorViewModel : BaseViewModel
    {
        #region Objects

        DoctorView doctorView;

        #endregion

        #region Constructors

        public DoctorViewModel(DoctorView doctorViewOpen, tblClinicDoctor user)
        {
            doctorView = doctorViewOpen;
            Doctor = user;
            Patients = GetAllPatientsOfThisDoctor();

            bgWorker.DoWork += Print;
            bgWorker.ProgressChanged += PopulateProgressBar;
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;

            Visibility = false;

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

        private List<tblClinicPatient> patients;

        public List<tblClinicPatient> Patients
        {
            get { return patients; }
            set 
            {
                patients = value;
                OnPropertyChanged("Patients");
            }
        }

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

        private string proggressBarText;

        public string ProggressBarText
        {
            get { return proggressBarText; }
            set 
            {
                proggressBarText = value;
                OnPropertyChanged("ProggressBarText");
            }
        }



        #endregion

        #region Commands

        private ICommand examine;
        public ICommand Examine
        {
            get
            {
                if (examine == null)
                {
                    examine = new RelayCommand(param => ExamineExecute(), param => CanExamineExecut());
                }
                return examine;
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

        private List<tblClinicPatient> GetAllPatientsOfThisDoctor()
        {
            try
            {
                List<tblClinicPatient> patients = new List<tblClinicPatient>();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    patients = db.tblClinicPatients.Where(p => p.FKDoctor == Doctor.Id).ToList();
                }
                return patients;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void ExamineExecute()
        {
            Visibility = true;
            bgWorker.RunWorkerAsync();
        }

        private bool CanExamineExecut()
        {
            return true;
        }

        private void LogoutExecute()
        {
            doctorView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }



        #endregion

        #region Progress Bar

        BackgroundWorker bgWorker = new BackgroundWorker();


        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Random r = new Random();
            int randomInt = r.Next(0, 2);

            if(randomInt == 0)
            {
                MessageBox.Show("Patient have sympthoms...");
            }
            else
            {
                MessageBox.Show("Patient does not have sympthomps");
            }
        }

        private void Print(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            ProggressBarText = "Examinating...";
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                bgWorker.ReportProgress(progress += 20);
            }
        }

        private void PopulateProgressBar(object o, ProgressChangedEventArgs e)
        {
            ProgressBar = e.ProgressPercentage;
        }

        private int progressBar;

        public int ProgressBar
        {
            get { return progressBar; }
            set
            {
                progressBar = value;
                OnPropertyChanged("ProgressBar");
            }
        }

        private bool visibility;

        public bool Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }


        #endregion
    }
}
