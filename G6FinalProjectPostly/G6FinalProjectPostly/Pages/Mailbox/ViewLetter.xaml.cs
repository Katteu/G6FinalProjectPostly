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
            //if (Application.Current.Properties.ContainsKey("email"))
            //{
            //    var emailz = Application.Current.Properties["email"].ToString();
            //    email.Text = "<"+emailz+">";
            //}
            //if (Application.Current.Properties.ContainsKey("name"))
            //{
            //    var name = Application.Current.Properties["name"].ToString();
            //    from.Text = name;
            //}
        }

        public ViewLetter(LetterModel letter,string name,string emailz)
        {
            InitializeComponent();
            letterNew = letter;
            toLabel.Text = "To " + letter.to;
            subjLabel.Text = letter.subject;
            dateLabel.Text = letter.date;
            letterLabel.Text = letter.letter;
            email.Text = "<" + emailz + ">";
            from.Text = name;
        }

        async private void back_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}