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
    public partial class ComposePage : ContentPage
    {
        public ComposePage()
        {
            InitializeComponent();

        }

        private void sendLetter(object sender, EventArgs e)
        {
            string to, subject,date,letter;
            if (!string.IsNullOrEmpty(ToEntry.Text) && !string.IsNullOrEmpty(SubjectEntry.Text))
            {
                to = ToEntry.Text;
                subject = SubjectEntry.Text;
                date = DateTime.Today.ToString("yyyy-MM-dd");
                letter = inputLetter.Text;
                ToEntry.Text = SubjectEntry.Text = inputLetter.Text=string.Empty;

                SentLetter targetPage = new SentLetter(to, subject, date,letter);

                TabbedPage tabbedPage = (TabbedPage)Parent;

                tabbedPage.CurrentPage = targetPage;

                // Find the desired page within the TabbedPage
                var targetzPage = tabbedPage.Children.FirstOrDefault(page => page is MainFlyoutPage);

                // Set the active page to the desired page
                tabbedPage.CurrentPage = targetzPage;
            }
            else
            {
                DisplayAlert("Error!", "Please fill in all the fields.", "OK");
            }
        }
    }
}