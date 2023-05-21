using G6FinalProjectPostly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6FinalProjectPostly.Pages.Mailbox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLetter : ContentPage
    {
        LetterModel letterExist;
        public EditLetter()
        {
            InitializeComponent();
        }

        public EditLetter(LetterModel letter)

        {
            InitializeComponent();
            letterExist = letter;
            ToEntry.Text = letter.to;
            SubjectEntry.Text = letter.subject;
            inputLetter.Text = letter.letter;
        }

        private void updateLetter(object sender, EventArgs e)
        {
            string to, subject, inputLett;
            int currID = letterExist.id;
            if (!string.IsNullOrEmpty(ToEntry.Text) && !string.IsNullOrEmpty(SubjectEntry.Text) && !string.IsNullOrEmpty(inputLetter.Text))
            {
                to = ToEntry.Text;
                subject = SubjectEntry.Text;
                inputLett = inputLetter.Text;

                foreach (var indx in DataRepository.letterList)
                {
                    if (indx.id == currID)
                    {
                        indx.to = to;
                        indx.subject = subject;
                        indx.letter = inputLett;
                    }
                }
                ToEntry.Text = SubjectEntry.Text = inputLetter.Text = string.Empty;
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error!", "Cannot update letter with empty fields. Please fill in all the fields!", "OK");
            }
        }

        async private void back_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}