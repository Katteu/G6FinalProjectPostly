using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIconsRegular.ttf", Alias = "RegularMaterial")]
[assembly: ExportFont("MaterialIconsTwoTone.ttf", Alias = "TwoToneMaterial")]
[assembly: ExportFont("MaterialIconsOutlined-Regular.otf", Alias = "OutlinedMaterial")]
[assembly: ExportFont("MontserratRegular.ttf", Alias = "MontReg")]
[assembly: ExportFont("MontserratBlack.ttf", Alias = "MontBlack")]
[assembly: ExportFont("MontserratLight.ttf", Alias = "MontLight")]
[assembly: ExportFont("MontserratBold.ttf", Alias = "MontBold")]
[assembly: ExportFont("MontserratSemiBold.ttf", Alias = "MontSemiBold")]
[assembly: ExportFont("MontserratExtraBold.ttf", Alias = "MontExtraBold")]
[assembly: ExportFont("MontserratMedium.ttf", Alias = "MontMed")]
[assembly: ExportFont("MontserratThin.ttf", Alias = "MontThin")]

namespace G6FinalProjectPostly
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new G6FinalProjectPostly.Pages.PostlyTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
