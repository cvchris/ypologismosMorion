
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ypologismosMorion;
using ypologismosMorion.Droid;

[assembly: ExportRenderer(typeof(ypolEntry), typeof(ypolEntryRenderer))]
namespace ypologismosMorion.Droid
{
    class ypolEntryRenderer : EntryRenderer
    {
        public ypolEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null) return;

            Control.KeyListener = DigitsKeyListener.GetInstance("1234567890,.");
        }

    }
}