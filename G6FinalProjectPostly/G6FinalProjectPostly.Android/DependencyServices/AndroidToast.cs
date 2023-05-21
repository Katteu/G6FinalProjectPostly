using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using G6FinalProjectPostly.Droid;
using G6FinalProjectPostly.Droid.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Text;
using G6FinalProjectPostly.DependencyServices;
using DependencyAttribute = Xamarin.Forms.DependencyAttribute;

[assembly: Dependency(typeof(AndroidToast))]

namespace G6FinalProjectPostly.Droid.DependencyServices
{
    public class AndroidToast : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}