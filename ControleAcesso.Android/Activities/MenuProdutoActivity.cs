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

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "MenuProdutoActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class MenuProdutoActivity : Activity
    {

        protected List<Dominio.Entidade.Menu> _lstMenu;
        protected ListView _menuListView = null;
        protected MenuAdapter _menusAdp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.Menu);


            _lstMenu = new List<Dominio.Entidade.Menu>();
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 1, Descricao = "Listar todos produtos disponiveis", Titulo = "Visualizar", Imagem = "visualizar" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 2, Descricao = "Cadastrar produto", Titulo = "Novo", Imagem = "add" });

            _menuListView = FindViewById<ListView>(Resource.Id.lstMenu);
            _menusAdp = new MenuAdapter(this, _lstMenu);
            _menuListView.Adapter = _menusAdp;


            //// EVENTO CLICK ITEM DA LISTA
            if (_menuListView != null)
            {
                _menuListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    switch (e.Position)
                    {
                        case 0:
                            StartActivity(new Intent(this, typeof(ProdutoActivity)));
                            break;
                        case 1:
                            //StartActivity(new Intent(this, typeof(PedidoSaidaActivity)));
                            break;
                    }
                };
            }
        }
    }
}