﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6FinalProjectPostly.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoggedOutPage : ContentPage
    {
        public LoggedOutPage()
        {
            InitializeComponent();
        }

        private void RedirectLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        
    }
}