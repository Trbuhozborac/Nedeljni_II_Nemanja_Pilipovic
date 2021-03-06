﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;
using Zadatak_1.Views;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;
        private string _password;
        private bool _logged = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            GetMasterCredentials();
            if(_username == txtUsername.Text && _password == txtPassword.Password)
            {
                _logged = true;
                MasterView view = new MasterView();
                view.ShowDialog();
                ClearCredentials();
                return;
            }
            else
            {
                try
                {
                    List<IUser> users = new List<IUser>();
                    using(MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                    {
                        foreach (tblClinicAdmin admin in db.tblClinicAdmins)
                        {
                            users.Add(admin as IUser);
                        }
                        foreach (tblClinicMaintance maintance in db.tblClinicMaintances)
                        {
                            users.Add(maintance as IUser);
                        }
                        foreach (tblClinicManager manager in db.tblClinicManagers)
                        {
                            users.Add(manager as IUser);
                        }
                        foreach (tblClinicDoctor doctor in db.tblClinicDoctors)
                        {
                            users.Add(doctor as IUser);
                        }
                        foreach (tblClinicPatient patient in db.tblClinicPatients)
                        {
                            users.Add(patient as IUser);
                        }
                    }

                    foreach (IUser user in users)
                    {
                        if(user.Username == txtUsername.Text && user.Password == txtPassword.Password)
                        {
                            if(user is tblClinicAdmin)
                            {
                                _logged = true;
                                if (IsThereHospital())
                                {
                                    AdminView view = new AdminView();
                                    view.ShowDialog();
                                    ClearCredentials();
                                    return;
                                }
                                else
                                {
                                    CreateMedicalInstitutionView view = new CreateMedicalInstitutionView();
                                    view.ShowDialog();
                                    return;
                                }
                                
                            }
                            else if(user is tblClinicMaintance)
                            {
                                _logged = true;
                                MaintanceView view = new MaintanceView(user as tblClinicMaintance);
                                view.ShowDialog();
                                ClearCredentials();
                                return;
                            }
                            else if(user is tblClinicManager)
                            {
                                _logged = true;
                                ManagerView view = new ManagerView(user as tblClinicManager);
                                view.ShowDialog();
                                ClearCredentials();
                                return;
                            }
                            else if (user is tblClinicDoctor)
                            {
                                _logged = true;
                                DoctorView view = new DoctorView(user as tblClinicDoctor);
                                view.ShowDialog();
                                ClearCredentials();
                                return;
                            }
                            else
                            {
                                _logged = true;
                                PatientView view = new PatientView(user as tblClinicPatient);
                                view.ShowDialog();
                                ClearCredentials();
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);                   
                }
            }

            if(_logged == false)
            {
                MessageBox.Show("Username or Password Incorrect.");
                ClearCredentials();
            }
            
        }

        private void GetMasterCredentials()
        {
            string _location = @"~\..\..\..\ClientAccess.txt";
            if (File.Exists(_location))
            {
                string[] usernameAndPassword = File.ReadAllLines(_location);
                string[] usernameSplited = usernameAndPassword[0].Split(':');
                _username = usernameSplited[1];

                string[] passwrodSplited = usernameAndPassword[1].Split(':');
                _password = passwrodSplited[1];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File not found...");
            }
        }

        private void ClearCredentials()
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

        private bool IsThereHospital()
        {
            try
            {
                using (MedicalInstitutionDbEntities db = new MedicalInstitutionDbEntities())
                {
                    if (db.tblMedicalInstitutions.Any())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Validate that User input are just letters
        /// </summary>
        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Validate that User input is just letters and digits
        /// </summary>
        private void LetterAndNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Validate that User input is just numbers
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
