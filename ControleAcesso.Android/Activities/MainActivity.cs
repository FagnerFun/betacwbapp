using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing;
using ZXing.Mobile;

namespace ControleAcesso.Android
{
    [Activity(Label = "ControleAcesso.Android", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            MobileBarcodeScanner.Initialize(Application);
            
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += async delegate
            {
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                    RunOnUiThread(() => Toast.MakeText(this, result.Text, ToastLength.Short).Show());
            };
        }
    }
}

