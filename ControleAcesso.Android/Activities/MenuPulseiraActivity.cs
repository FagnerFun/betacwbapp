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
using ZXing.Mobile;
using ControleAcesso.Dominio.Entidade;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "Pulseira", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class MenuPulseiraActivity : Activity
    {
        protected List<Dominio.Entidade.Menu> _lstMenu;
        protected ListView _menuListView = null;
        protected MenuAdapter _menusAdp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.Menu);


            _lstMenu = new List<Dominio.Entidade.Menu>();
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 1, Descricao = "Realizar venda a um usuario e associar pulseira com ingresso", Titulo = "Venda", Imagem = "money" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 2, Descricao = "Disponibilizar nova pulseira a um usuario", Titulo = "Vincular", Imagem = "linknew" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 3, Descricao = "Registrar usuario no evento", Titulo = "Entrada", Imagem = "entradanew" });
            _lstMenu.Add(new Dominio.Entidade.Menu() { Id = 4, Descricao = "Gerenciar controle de produtos na pulseira", Titulo = "Pedido", Imagem = "permissaousuario" });

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
                            StartActivity(new Intent(this, typeof(EventosActivity)));
                            break;
                        case 1:
                            StartActivity(new Intent(this, typeof(RegistrarPulseiraActivity)));
                            break;
                        case 2:
                            StartActivity(new Intent(this, typeof(EntradaEventoActivity)));
                            break;
                        case 3:
                            StartActivity(new Intent(this, typeof(MenuPedidoActivity)));
                            break;
                    }
                };
            }
        }
        
    }
}