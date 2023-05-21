using G6FinalProjectPostly.DependencyServices;
using G6FinalProjectPostly.Models;
using G6FinalProjectPostly.Pages.Mailbox;
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
	public partial class SentLetter : ContentPage
	{
        public SentLetter()
        {
            InitializeComponent();
            UpdateAlternativeContentVisibility();
        }

        public SentLetter (string to, string subject, string date, string letter)
		{
            DataRepository.letterList.Add(new LetterModel() { id = DataRepository.letterList.Count, to = to, subject = subject, date=date, letter=letter, isRead = false });
            InitializeComponent ();
            UpdateAlternativeContentVisibility();
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            // Get the instance of PostlyTabbedPage (replace "App.Current.MainPage" with your actual instance)
            var navigationPage = App.Current.MainPage as NavigationPage;
            var tabbedPage = navigationPage.RootPage as PostlyTabbedPage;

            // Find the desired page within the TabbedPage
            var targetPage = tabbedPage.Children.FirstOrDefault(page => page is ComposePage);

            // Set the active page to the desired page
            if (targetPage != null)
            {
                tabbedPage.CurrentPage = targetPage;
            }
        }


        async private void viewLetter_Tapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var grid = (Grid)label.Parent;
            grid.BackgroundColor = Color.FromHex("#F2F6FC");

            Label txt = sender as Label;
            LetterModel letter = new LetterModel();
            foreach (var indx in DataRepository.letterList)
            {
                if (indx.id == Convert.ToInt32(txt.ClassId))
                    indx.isRead = true;
                    letter = indx;
            }

            await Navigation.PushModalAsync(new ViewLetter(letter));
        }

        private async void editLetter_Tapped(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            LetterModel letter = new LetterModel();
            foreach (var indx in DataRepository.letterList)
            {
                if (indx.id == Convert.ToInt32(txt.ClassId))
                letter = indx;
            }

            await Navigation.PushAsync(new EditLetter(letter));
        }

        private async void deleteLetter_Tapped(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            bool response = await DisplayAlert("Delete Letter", "Are you sure you want to delete this sent letter?", "Yes", "No");
            if (response)
            {
                LetterModel letter = new LetterModel();
                foreach (var indx in DataRepository.letterList)
                {
                    if (indx.id == Convert.ToInt32(txt.ClassId))
                        letter = indx;
                }
                DataRepository.letterList.Remove(letter);
             
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IToast>().Show("Letter Deleted!");
            }
            UpdateAlternativeContentVisibility();
        }

        private void change_Clicked(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            foreach (var indx in DataRepository.letterList)
            {
                if (indx.id == Convert.ToInt32(txt.ClassId))
                {
                    if (indx.isRead == true)
                    {
                        var label = (Label)sender;
                        var grid = (Grid)label.Parent;
                        grid.BackgroundColor = Color.White;
                        indx.isRead = false;
                        if (Device.RuntimePlatform == Device.Android)
                            DependencyService.Get<IToast>().Show("Marked as unread!");
                    }                  
                }
            }
        }

        private void UpdateAlternativeContentVisibility()
        {
            if (letterListView.ItemsSource == null || !letterListView.ItemsSource.Cast<object>().Any())
            {
                listContainer.IsVisible = false;
                altContainer.IsVisible = true;
            }
            else
            {
                listContainer.IsVisible = true;
                altContainer.IsVisible = false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            letterListView.ItemsSource = DataRepository.letterList;
            UpdateAlternativeContentVisibility();
        }


    }
}