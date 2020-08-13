using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateReportViewModel : BaseViewModel
    {
        #region Objects

        CreateReportView reportView;

        #endregion

        #region Constructors

        public CreateReportViewModel(CreateReportView reportViewOpen)
        {
            reportView = reportViewOpen;
            Report = new tblReport();
        }

        public CreateReportViewModel(CreateReportView reportViewOpen, tblClinicMaintance user)
        {
            reportView = reportViewOpen;
            Report = new tblReport();
            User = user;
        }

        #endregion

        #region Properties

        private tblReport report;

        public tblReport Report
        {
            get { return report; }
            set 
            {
                report = value;
                OnPropertyChanged("Report");
            }
        }

        private tblClinicMaintance user;

        public tblClinicMaintance User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
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
                Report.Date = DateTime.Today;
                Report.FKClinicMaintance = User.Id;

                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    db.tblReports.Add(Report);
                    db.SaveChanges();
                }

                MessageBox.Show("Report Added Successfully!");
                reportView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(Report.TotalTime.ToString()) || string.IsNullOrEmpty(Report.Description))
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
            reportView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
