using G6FinalProjectPostly.DependencyServices;
using G6FinalProjectPostly.Models;
using G6FinalProjectPostly.Pages.Mailbox;
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
	public partial class InboxLetter : ContentPage
	{
        private bool isLoaded = false;
        public static bool isDeleted = false;
        public InboxLetter ()
		{
			InitializeComponent ();

            if (!isLoaded && !isDeleted && DataRepository.staticList.Count == 0)
            {
            string to = "Postly";
            string subject = "Welcome to Postly!";
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string letter = "Dear Member, We are glad to see that you have joined this community! Hoping that you would enjoy your experience and connect with others as our words unite";
            DataRepository.staticList.Add(new LetterModel() { id = DataRepository.staticList.Count, to = to, subject = subject, date = date, letter = letter, isRead = false });
                isLoaded = true;
            }

            UpdateAlternativeContentVisibility();
        }

        async private void viewLetter_Tapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var grid = (Grid)label.Parent;
            grid.BackgroundColor = Color.FromHex("#F2F6FC");

            Label txt = sender as Label;
            LetterModel letter = new LetterModel();
            foreach (var indx in DataRepository.staticList)
            {
                if (indx.id == Convert.ToInt32(txt.ClassId))
                    indx.isRead = true;
                letter = indx;
            }

            await Navigation.PushModalAsync(new ViewInbox(letter));
        }

        private async void deleteLetter_Tapped(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            bool response = await DisplayAlert("Delete Letter", "Are you sure you want to delete this sent letter?", "Yes", "No");
            if (response)
            {
                LetterModel letter = new LetterModel();
                foreach (var indx in DataRepository.staticList)
                {
                    if (indx.id == Convert.ToInt32(txt.ClassId))
                        letter = indx;
                }
                DataRepository.staticList.Remove(letter);
                isDeleted= true;
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IToast>().Show("Task Deleted!");
            }
            UpdateAlternativeContentVisibility();
        }

        private void change_Clicked(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            foreach (var indx in DataRepository.staticList)
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
                letterContainer.IsVisible = false;
                altContainer.IsVisible = true;
            }
            else
            {
                letterContainer.IsVisible = true;
                altContainer.IsVisible = false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            letterListView.ItemsSource = DataRepository.staticList;
            UpdateAlternativeContentVisibility();
        }
    }
}