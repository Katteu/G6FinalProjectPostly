using G6FinalProjectPostly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6FinalProjectPostly.Pages.Mailbox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLetter : ContentPage
    {
        LetterModel letterNew;
        public ViewLetter()
        {
            InitializeComponent();
        }

        public ViewLetter(LetterModel letter)
        {
            InitializeComponent();
            letterNew = letter;
            toLabel.Text = "To " + letter.to;
            subjLabel.Text = letter.subject;
            dateLabel.Text = letter.date;
            letterLabel.Text = letter.letter;
        }

        async private void back_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}