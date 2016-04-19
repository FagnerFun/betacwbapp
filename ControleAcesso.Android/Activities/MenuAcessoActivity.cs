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
using System.Threading;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "MenuAcesso", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class MenuAcessoActivity : Activity
    {
        protected List<Dominio.Entidade.Menu> _lstMenu;
        protected ListView _menuListView = null;
        protected MenuAdapter _menusAdp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.Menu);


            _lstMenu = new List<Dominio.Entidade.Menu>();
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 1, Descricao = "Gerenciar acesso de usuario a eventos", Titulo = "Pulseira", Imagem = "ticketbranca" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 2, Descricao = "Cadastro de eventos", Titulo = "Evento", Imagem = "evento" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 3, Descricao = "Gerenciar  permissão de usuarios", Titulo = "Usuário", Imagem = "usuarios" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 4, Descricao = "Gerenciar produtos disponiveis para compra", Titulo = "Produto", Imagem = "garrafa" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 0, Descricao = "Enviar e receber dados do servidor", Titulo = "Sincronizar", Imagem = "syncbranca" });

            _menuListView = FindViewById<ListView>(Resource.Id.lstMenu);
            _menusAdp = new MenuAdapter(this, _lstMenu);
            _menuListView.Adapter = _menusAdp;

            
            if (_menuListView != null)
            {
                _menuListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    switch (e.Position)
                    {
                        case 0:
                            StartActivity(new Intent(this, typeof(MenuPulseiraActivity)));
                            break;
                        case 1:
                            StartActivity(new Intent(this, typeof(EventoCadActivity)));
                            break;
                        case 2:
                            StartActivity(new Intent(this, typeof(MenuUsuarioActivity)));
                            break;
                        case 3:
                            StartActivity(new Intent(this, typeof(MenuProdutoActivity)));
                            break;
                        case 4:
                            ProgressDialog progressDialog;
                            progressDialog = ProgressDialog.Show(this, "Aguarde...", "Sincronizando dados...", true);
                            new Thread(new ThreadStart(delegate {
                                Thread.Sleep(3000);	
                                if (progressDialog != null)
                                {
                                    RunOnUiThread(() => progressDialog.Hide());
                                }

                                RunOnUiThread(() => Toast.MakeText(this, "Dados Sincronizados com sucesso", ToastLength.Short).Show());

                            })).Start();
                            break;
                    }
                };
            }
        }
    }
}