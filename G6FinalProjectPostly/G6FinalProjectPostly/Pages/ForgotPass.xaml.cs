using G6FinalProjectPostly.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6FinalProjectPostly.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPass : ContentPage
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private async void SendNewPassRequestBtn_Clicked(object sender, EventArgs e)
        {
            var usrEmail = user_email.Text;
            List<Users> emailList = Users.UserList;
            bool emailFound = false;

            if(usrEmail != null ) 
            {
                if (usrEmail.ToLower().Contains('@') && usrEmail.ToLower().Contains('.'))
                {
                    foreach (var email in emailList)
                    {
                        if (email.Email() == usrEmail)
                        {
                            emailFound = true;
                        }

                    }
                    if (emailFound == true)
                    {
                        await DisplayAlert("Success", "Your recovery email will be sent shortly.", "Ok");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Fail", "The email does not exist!", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Please use an email format for the entry.", "Close");
                }

            }
            else
            {
                await DisplayAlert("Alert", "Please do not leave the email field empty.", "Close");
            }
        }
    }
}