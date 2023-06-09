﻿using G6FinalProjectPostly.CustomRenderers;
using G6FinalProjectPostly.Models;
using G6FinalProjectPostly.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace G6FinalProjectPostly
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            List<Users> accountlist = Users.UserList;
            string userEmail = usrEmail.Text;
            string userPass = usrPass.Text;

            if (usrEmail.Text != string.Empty && usrPass.Text != string.Empty && userEmail!=null && userPass!=null)
            {
                if (accountlist.Count != 0)
                {
                    foreach (Users usr in accountlist)
                    {
                        if (userEmail == usr.Email() && userPass == usr.Password())
                        {
                            Xamarin.Forms.Application.Current.Properties["name"] = usr.Name();
                            Xamarin.Forms.Application.Current.Properties["email"] = usr.Email();
                            Xamarin.Forms.Application.Current.SavePropertiesAsync();

                            usrEmail.Text = usrPass.Text = string.Empty;

                            App.publicEmail = userEmail;
                            App.publicName = usr.Name();

                            Navigation.PushAsync(App.TabbedPage);
                        }
                        else
                        {
                            DisplayAlert("Alert", "Your account cannot be found, please create an account.", "Close");
                        }
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Account not found!", "Close");
                }


            }
            else
            {
                //Console.WriteLine("No input found!");
                DisplayAlert("Alert", "Please fill in all the fields to login.", "Ok");
            }
        }

        private void SignUpBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());

        }

        private void ForgotPassButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPass());
        }
        //Use Session for user Login
    }
}