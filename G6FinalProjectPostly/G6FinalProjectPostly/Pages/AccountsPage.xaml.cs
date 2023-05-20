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
        }

        private void SentLetterBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoggedOutPage());
        }
    }
}