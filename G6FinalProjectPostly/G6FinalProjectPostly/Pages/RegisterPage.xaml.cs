using G6FinalProjectPostly.CustomRenderers;
using G6FinalProjectPostly.Models;
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
            Navigation.PopAsync();
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string userName = user_name.Text;
            string userEmail = user_email.Text;
            string userPass = user_pass.Text;

            if (string.IsNullOrEmpty(user_name.Text) || string.IsNullOrEmpty(user_email.Text) || string.IsNullOrEmpty(user_pass.Text))
            {
                await DisplayAlert("Alert", "One of the fields is missing!", "OK");
            }
            else if(!(userEmail.ToLower().Contains('@')) || !(userEmail.ToLower().Contains('.'))){
                await DisplayAlert("Error!", "Input correct email format.", "OK");
            }
            else
            {
                if (user_pass.Text == user_confpass.Text)
                {
                    Users new_user = new Users(userName, userEmail, userPass);
                    Users.AddToUserList(new_user);
                    await DisplayAlert("Successful!", "You have successfully registered.", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", "Confirmation Password does not match!", "OK");
                }
            }
        }
    }
}