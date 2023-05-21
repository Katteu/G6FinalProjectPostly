using G6FinalProjectPostly.Assets;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6FinalProjectPostly.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void LoginBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string userName = user_name.Text;
            string userEmail = user_email.Text;
            string userPass = user_pass.Text;

            if(string.IsNullOrEmpty(user_name.Text) || string.IsNullOrEmpty(user_email.Text) || string.IsNullOrEmpty(user_pass.Text)) {
                await DisplayAlert("Alert", "One of the fields is missing!", "Ok");
            }
            else
            {
                if (user_pass.Text == user_confpass.Text)
                {
                    Users new_user = new Users(userName, userEmail, userPass);
                    Users.AddToUserList(new_user);
                    await DisplayAlert("Register", "You have successfully registered", "Ok");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Alert", "Confirmation Password does not match!", "Ok");
                }
            }
        }
    }
}