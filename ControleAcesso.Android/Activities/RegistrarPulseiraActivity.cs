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
using ControleAcesso.Android.Adapter;
using ControleAcesso.Dominio.Entidade;
using ZXing.Mobile;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "RegistrarPulseiraActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class RegistrarPulseiraActivity : Activity
    {
        Button btnBuscarUsuarioRegistroPulseira;

        protected List<Usuario> _lstUsuario;
        protected ListView _usuarioListView = null;
        protected UsuarioAdapter _usuarioAdp;

        private static bool telaCriada = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (!telaCriada)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.RegistrarPulseira);

                btnBuscarUsuarioRegistroPulseira = FindViewById<Button>(Resource.Id.btnBuscarUsuarioRegistroPulseira);
                _usuarioListView = FindViewById<ListView>(Resource.Id.lstUsuario);


                if (_usuarioListView != null)
                {
                    _usuarioListView.ItemClick += async (object sender, AdapterView.ItemClickEventArgs e) =>
                    {

                        var scanner = new MobileBarcodeScanner();
                        var result = await scanner.Scan();

                        if (result != null)
                        {
                            ValidarPulseira(result.Text);
                        }
                    };
                }


                if (btnBuscarUsuarioRegistroPulseira != null)
                {
                    btnBuscarUsuarioRegistroPulseira.Click += (sender, e) =>
                   {
                       Atualizar();
                   };
                }
            }
        }

        private void Atualizar()
        {
            _lstUsuario = ListaDemo();

            _usuarioAdp = new UsuarioAdapter(this, _lstUsuario);
            _usuarioListView.Adapter = _usuarioAdp;
        }

        private List<Usuario> ListaDemo()
        {
            List<Usuario> result = new List<Usuario>();
            result.Add(new Usuario() { Id = 1, Nome = "Fagner Muniz", CPF = 23073732845, Email="fun@betacwb.com.br", DataNascimento = new DateTime(1988,04,02) });

            return result;
        }

        public void ValidarPulseira(string novaPulseira)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Este usuario possui outra pulseira vinculada, tem certeza que deseja desativa-la, para registrar a nova ?");
            alert.SetPositiveButton("Sim", (sender, args) => {

                RunOnUiThread(() => Toast.MakeText(this, novaPulseira, ToastLength.Short).Show());
                Finish();
            });
            alert.SetNegativeButton("Não", (sender, args) => { return; });
            alert.Show();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            telaCriada = false;
        }
    }
}