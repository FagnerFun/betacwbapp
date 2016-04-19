
using Android.App;
using Android.OS;
using Android.Widget;
using ControleAcesso.Android.Adapter;
using ControleAcesso.Dominio.Entidade;
using System.Collections.Generic;
using ZXing.Mobile;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "PedidoSaidaActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class PedidoSaidaActivity : Activity
    {
        protected List<Produto> _lstProduto;
        protected ListView _produtoListView = null;
        protected ProdutoAdapter _produtoAdp;

        private static bool telaCriada = false;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            if (!telaCriada)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Produto);

                _produtoListView = FindViewById<ListView>(Resource.Id.lstProdutos);

                _lstProduto = ListaDemo();

                if (_produtoListView != null)
                {
                    _produtoListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                    {
                        Produto p = _produtoAdp[e.Position];

                        EntregarProduto(p.Descricao, e.Position);
                    };
                }

                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();

                string pulseira = "";
                if (result != null)
                {
                    pulseira = result.Text;
                }
                else
                    Finish();
            }
        }

        protected override void OnResume()
        {
            base.OnResume();


            _produtoAdp = new ProdutoAdapter(this, _lstProduto, true);
            _produtoListView.Adapter = _produtoAdp;

        }


        private List<Produto> ListaDemo()
        {
            List<Produto> result = new List<Produto>();
            result.Add(new Produto() { Id = 1, Descricao = "Combo Absolut Vodka + 6 energetico", Valor = 300.00, ValorBeta = 245.50, Quantidade = 1 });
            result.Add(new Produto() { Id = 2, Descricao = "Cerveja long neck budweiser 350ml", Valor = 5.00, ValorBeta = 4.00, Quantidade = 6 });
            result.Add(new Produto() { Id = 3, Descricao = "Champagne Veuve Clicquot Brut 750ml", Valor = 530.00, ValorBeta = 415.00, Quantidade = 1 });

            return result;
        }

        public void EntregarProduto(string produto, int position)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Deseja entregar " + produto + " ao cliente ?");
            alert.SetPositiveButton("Sim", (sender, args) => {
                _lstProduto.RemoveAt(position);
                OnResume();
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