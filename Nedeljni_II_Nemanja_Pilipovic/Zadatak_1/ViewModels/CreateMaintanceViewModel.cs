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
    class CreateMaintanceViewModel : BaseViewModel
    {
        #region Objects

        CreateMaintanceView createMaintance;

        #endregion

        #region Constructors

        public CreateMaintanceViewModel(CreateMaintanceView createMaintanceOpen)
        {
            createMaintance = createMaintanceOpen;
            Maintance = new tblClinicMaintance();
            Genders = GetBothGender();
        }

        #endregion

        #region Properties

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
            Queue<tblClinicMaintance> maintances = new Queue<tblClinicMaintance>();

            try
            {
                Maintance.Gender = Gender;
                if (Maintance.InChargeOfDisabledPatientAccess == true)
                {
                    Maintance.InChargeOfAmbulanceAccess = false;
                }
                else
                {
                    Maintance.InChargeOfAmbulanceAccess = true;
                }

                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    foreach (tblClinicMaintance maintance in db.tblClinicMaintances)
                    {
                        maintances.Enqueue(maintance);
                    }

                    if (maintances.Count < 3)
                    {
                        db.tblClinicMaintances.Add(Maintance);
                        db.SaveChanges();
                    }
                    else
                    {
                        tblClinicMaintance m =  maintances.Dequeue();
                        foreach (tblReport report in db.tblReports)
                        {
                            if(report.FKClinicMaintance == m.Id)
                            {
                                db.tblReports.Remove(report);
                            }
                        }
                        db.tblClinicMaintances.Remove(m);
                        db.tblClinicMaintances.Add(Maintance);
                        db.SaveChanges();
                    }
                }
               
                MessageBox.Show("Clinic Maintance added Successfully!");
                createMaintance.Close();
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
            createMaintance.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

  

        #endregion
    }
}
