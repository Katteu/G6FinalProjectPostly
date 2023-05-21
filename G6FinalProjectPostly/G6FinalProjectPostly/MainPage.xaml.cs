using G6FinalProjectPostly.Assets;
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
            List<Users> accountlist = Users.UserList;
            string userEmail = usrEmail.Text;
            string userPass = usrPass.Text;

            if (usrEmail.Text != null && usrPass.Text != null)
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

                            DisplayAlert(usr.Name(), usr.Email(), usr.Password());
                            Navigation.PushAsync(new AccountsPage());
                        }
                        else
                        {
                            DisplayAlert("Alert", "Your account cannot be found, please create an account.", "Close");
                        }
                    }
                }
                else
                {
                    DisplayAlert("Alert", "There are no accounts in the database!", "Close");
                }
                
                
            }
            else
            {
                Console.WriteLine("No input found!");
                DisplayAlert("Alert", "You have entered the incorrect Email or Password!", "Ok");
            }
        }

        private void SignUpBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());

        }

        private void ForgotPassButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoggedOutPage());
        }
        //Use Session for user Login
    }
}
