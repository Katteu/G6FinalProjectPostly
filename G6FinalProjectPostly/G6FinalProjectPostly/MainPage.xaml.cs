using G6FinalProjectPostly.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Regular.ttf", Alias ="Monsterrat")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Bold-Monsterrat")]
[assembly: ExportFont("Montserrat-ExtraBold.ttf", Alias = "ExtraBold-Monsterrat")]
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
            if (usrEmail.Text != null && usrPass.Text != null)
            {
                Navigation.PushAsync(new LoggedOutPage());
            }
            else
            {
                DisplayAlert("Alert", "You have entered the incorrect Email or Password!", "Ok");
            }
        }

        private void SignUpBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ForgotPassButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountsPage());
        }
    }
}
