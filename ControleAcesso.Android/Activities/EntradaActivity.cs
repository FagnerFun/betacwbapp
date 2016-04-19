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
using ZXing.Mobile;
using ControleAcesso.Dominio.Entidade;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "EntradaActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class EntradaActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Aguarde);

            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            string pulseira = "";
            if (result != null)
            {
                pulseira = result.Text;
                Usuario u = UserDemo(pulseira);
                ValidarPulseira(u);
            }
            else
                Finish();
        }


        private Usuario UserDemo(string pulseira)
        {
            return new Usuario() { Id = 1, Nome = "Fagner Muniz", CPF = 23073732845, Email = "fun@betacwb.com.br", DataNascimento = new DateTime(1988, 04, 02), Documento = "RG 41.886.313-1" };
        }


        public void ValidarPulseira(Usuario user)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Usuario Registrado \n" + user.Nome + "\r\n" + "documento: " + user.Documento + "\r\nIdade:28 anos ");
            alert.SetPositiveButton("OK", (sender, args) => {
                Finish();
            });
            alert.Show();
        }
    }
}