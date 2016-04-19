using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "Cadastro de Evento", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class EventoCadActivity : Activity
    {
        Button btnCadastrar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CadastroEvento);

            btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrarEvento);

            if (btnCadastrar != null)
            {
                btnCadastrar.Click += (sender, e) =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Evento cadastrado com sucesso", ToastLength.Short).Show());
                    Finish();
                };
            }
        }
    }
}