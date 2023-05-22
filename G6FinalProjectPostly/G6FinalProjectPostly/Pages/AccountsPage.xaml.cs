using G6FinalProjectPostly.Models;
using G6FinalProjectPostly.Pages.Navigation;
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
            //user_emailprof.Text = App.publicName;
            //user_nameprof.Text = App.publicEmail;
            //if (Application.Current.Properties.ContainsKey("email"))
            //{
            //    var email = Application.Current.Properties["email"].ToString();
            //    user_emailprof.Text = email;

            //}
            //if (Application.Current.Properties.ContainsKey("name"))
            //{
            //    var name = Application.Current.Properties["name"].ToString();
            //    user_nameprof.Text = name;
            //}

            //if(App.publicEmail!=string.Empty && App.publicName != string.Empty)
            //{
            //    user_emailprof.Text = App.publicEmail;
            //    user_nameprof.Text = App.publicName;
            //}
        }

        private void SentLetterBtn_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = (TabbedPage)Parent;

            var targetPage = tabbedPage.Children.FirstOrDefault(page => page is MainFlyoutPage);

            tabbedPage.CurrentPage = targetPage;

            if (targetPage is MainFlyoutPage mainFlyoutPage)
            {
                mainFlyoutPage.Detail = new NavigationPage(new SentLetter());
            }
        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("email");
            Application.Current.Properties.Remove("name");
            Navigation.PushAsync(new LoggedOutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            user_emailprof.Text = App.publicEmail; 
            user_nameprof.Text = App.publicName;
        }
    }
}