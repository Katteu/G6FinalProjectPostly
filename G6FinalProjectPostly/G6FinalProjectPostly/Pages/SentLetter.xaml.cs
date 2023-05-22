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
        string name, email;
        public SentLetter()
        {
            InitializeComponent();
            UpdateAlternativeContentVisibility();
        }

        public SentLetter (string to, string subject, string date, string letter)
		{
            DataRepository.letterList.Add(new LetterModel() { id = DataRepository.letterList.Count, to = to, subject = subject, date = date, letter = letter, isRead = false });
            InitializeComponent ();
            letterListView.ItemsSource = DataRepository.letterList;
            UpdateAlternativeContentVisibility();
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            var postlyTabbedPage = App.TabbedPage;

            int targetPageIndex = 1;

            var targetPage = postlyTabbedPage.Children[targetPageIndex];

            postlyTabbedPage.CurrentPage = targetPage;

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

            await Navigation.PushModalAsync(new ViewLetter(letter,name,email));
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
            if (DataRepository.letterList.Count==0)
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
            if (Application.Current.Properties.ContainsKey("name"))
            {
                name = Application.Current.Properties["name"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("email"))
            {
                email = Application.Current.Properties["email"].ToString();
            }
            letterListView.ItemsSource = DataRepository.letterList;
            UpdateAlternativeContentVisibility();
        }


    }
}