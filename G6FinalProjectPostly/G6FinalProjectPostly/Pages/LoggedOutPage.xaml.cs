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
    public partial class LoggedOutPage : ContentPage
    {
        public LoggedOutPage()
        {
            InitializeComponent();
        }

        private async void RedirectLoginBtn_Clicked(object sender, EventArgs e)
        {
            var navigationStack = new List<Page>(Navigation.NavigationStack);
            foreach (var page in navigationStack.Skip(1))
            {
                Navigation.RemovePage(page);
            }

            await Navigation.PushAsync(new MainPage());
        }

        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}