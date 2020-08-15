using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class PatientViewModel : BaseViewModel 
    {
        #region Objects

        PatientView patientView;

        #endregion

        #region Constructors

        public PatientViewModel(PatientView patientViewOpen)
        {
            patientView = patientViewOpen;
        }

        public PatientViewModel(PatientView patientViewOpen, tblClinicPatient user)
        {
            patientView = patientViewOpen;
            Patient = user;

          
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

        private string requestText;

        public string RequestText
        {
            get { return requestText; }
            set 
            {
                requestText = value;
                OnPropertyChanged("RequestText");
            }
        }


        #endregion

        #region Commands

        private ICommand requestExamination;
        public ICommand RequestExamination
        {
            get
            {
                if (requestExamination == null)
                {
                    requestExamination = new RelayCommand(param => RequestExaminationeExecute(), param => CanRequestExaminationeExecute());
                }
                return requestExamination;
            }
        }

        #endregion

        #region Functions

        private void RequestExaminationeExecute()
        {
            try
            {
                tblExamination examination = new tblExamination();
                examination.FKPatient = Patient.Id;
                examination.FKDoctor = Patient.FKDoctor;

                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    db.tblExaminations.Add(examination);
                    db.SaveChanges();
                }

                MessageBox.Show("Examination Requested Successfully!");
                RequestText = "*Doctor is reviewing your Request.";
               

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanRequestExaminationeExecute()
        {
            return true;
            //TODO ovdece ici proveravanjke jle moze opet da posalje
        }

        #endregion
    }
}
