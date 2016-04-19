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
using ControleAcesso.Dominio.Entidade;
using ControleAcesso.Android.Adapter;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "BuscaUsuario", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class BuscaUsuarioActivity : Activity
    {
        Button btnBuscarUsuarioRegistroPulseira;

        protected List<Usuario> _lstUsuario;
        protected ListView _usuarioListView = null;
        protected UsuarioAdapter _usuarioAdp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BuscarUsuario);

            btnBuscarUsuarioRegistroPulseira = FindViewById<Button>(Resource.Id.btnBuscarUsuarioRegistroPulseira);
            _usuarioListView = FindViewById<ListView>(Resource.Id.lstUsuario);


            if (_usuarioListView != null)
            {
                _usuarioListView.ItemClick +=  (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    UsuarioCadActivity.usuarioBusca = _usuarioAdp[e.Position];
                    Finish();
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

        private void Atualizar()
        {
            _lstUsuario = ListaDemo();

            _usuarioAdp = new UsuarioAdapter(this, _lstUsuario);
            _usuarioListView.Adapter = _usuarioAdp;
        }

        private List<Usuario> ListaDemo()
        {
            List<Usuario> result = new List<Usuario>();
            result.Add(new Usuario() { Id = 1, Nome = "Fagner Muniz", CPF = 23073732845, Email = "fun@betacwb.com.br", DataNascimento = new DateTime(1988, 04, 02) });

            return result;
        }
    }
}