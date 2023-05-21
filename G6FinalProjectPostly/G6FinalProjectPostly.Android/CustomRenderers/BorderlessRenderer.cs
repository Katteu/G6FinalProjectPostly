using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using G6FinalProjectPostly.CustomRenderers;
using G6FinalProjectPostly.Droid.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ExportRenderer(typeof(BorderlessEntry),typeof(BorderlessRenderer))]
namespace G6FinalProjectPostly.Droid.CustomRenderers
{
    public class BorderlessRenderer:EntryRenderer
    {
        public BorderlessRenderer(Context context): base(context) {
          
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);

                this.Control.SetBackground(null);

                Control.SetPadding(0, 0, 0, 0);

                this.Control.InputType = InputTypes.TextVariationVisiblePassword;
                //IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                //IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                //JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor);
            }
        }
    }
}