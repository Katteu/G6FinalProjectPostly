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
    public partial class AccountsPage : ContentPage
    {
        public AccountsPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("email"))
            {
                var email = Application.Current.Properties["email"].ToString();
                user_emailprof.Text = email;
                
            }
            if(Application.Current.Properties.ContainsKey("name")) 
            {
                var name = Application.Current.Properties["name"].ToString();
                user_nameprof.Text = name;
            }
        }

        private void SentLetterBtn_Clicked(object sender, EventArgs e)
        {
            //Butang imong code diri kath ahak
        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoggedOutPage());
        }
    }
}