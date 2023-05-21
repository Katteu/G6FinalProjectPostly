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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Appearing += HomePage_Appearing;
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            // Get the parent TabbedPage
            var tabbedPage = (TabbedPage)Parent;

            // Find the desired page within the TabbedPage
            var targetPage = tabbedPage.Children.FirstOrDefault(page => page is ComposePage);

            // Set the active page to the desired page
            tabbedPage.CurrentPage = targetPage;
        }

        private async void HomePage_Appearing(object sender, System.EventArgs e)
        {
            await Task.WhenAll(
                label1.ScaleTo(1.5, 2000),
                label2.ScaleTo(1.5, 2000),
                label3.ScaleTo(1.5, 2000)
            );

            await Task.WhenAll(
              label1.ScaleTo(1),
              label2.ScaleTo(1),
              label3.ScaleTo(1)
            );


            // Rotate labels
            await Task.WhenAll(
                label1.RotateTo(-33, 400),
                label2.RotateTo(-33, 400),
                label3.RotateTo(-33, 400)
            );


            // Rotate labels
            await Task.WhenAll(
                label1.RotateTo(0),
                label2.RotateTo(0),
                label3.RotateTo(0)
            );
        }
    }
}