using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MaintanceViewModel : BaseViewModel
    {
        #region Objects

        MaintanceView maintanceView;

        #endregion

        #region Constructors

        public MaintanceViewModel(MaintanceView maintanceViewOpen)
        {
            maintanceView = maintanceViewOpen;
        }

        public MaintanceViewModel(MaintanceView maintanceViewOpen, tblClinicMaintance user)
        {
            maintanceView = maintanceViewOpen;
            User = user;
        }

        #endregion

        #region Properties

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

        private ICommand createReport;
        public ICommand CreateReport
        {
            get
            {
                if (createReport == null)
                {
                    createReport = new RelayCommand(param => CreateReportExecute(), param => CanCreateReportExecute());
                }
                return createReport;
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

        private void CreateReportExecute()
        {
            CreateReportView view = new CreateReportView(User);
            view.ShowDialog();
        }

        private bool CanCreateReportExecute()
        {
            try
            {
                List<tblReport> reports = new List<tblReport>();
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblReport report in db.tblReports)
                    {
                        if(report.FKClinicMaintance == User.Id)
                        {
                            reports.Add(report);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
              
                if(reports.Any(r => r.Date == DateTime.Today))
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

        private void LogoutExecute()
        {
            maintanceView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
