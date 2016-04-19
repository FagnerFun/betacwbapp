
using Android.App;
using Android.OS;
using Android.Widget;
using ControleAcesso.Android.Adapter;
using ControleAcesso.Dominio.Entidade;
using System.Collections.Generic;
using ZXing.Mobile;
using Android.Text;
using Android.Content.PM;
using Android.Content;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "PedidoEntradaActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PedidoEntradaActivity : Activity
    {
        protected List<Produto> _lstProduto;
        protected ListView _produtoListView = null;
        protected PedidoEntradaAdapter _produtoAdp;
        protected Button btnCarrinhoPedidoEntrada;
        private static bool telaCriada = false;
        public static bool FinalizarTela = false;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            if (!telaCriada)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.PedidoEntrada);
                
                _produtoListView = FindViewById<ListView>(Resource.Id.lstProdutosEntradaPedido);
                btnCarrinhoPedidoEntrada = FindViewById<Button>(Resource.Id.btnCarrinhoPedidoEntrada);

                _lstProduto = ListaDemo();

                if (_produtoListView != null)
                {
                    _produtoListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                    {
                        Produto p = _lstProduto[e.Position];
                        string qtd = ExibirDialogQtd(e.Position);
                    };
                }

                if(btnCarrinhoPedidoEntrada != null)
                {
                    btnCarrinhoPedidoEntrada.Click += (object sender, System.EventArgs e) =>
                    {
                        StartActivity(new Intent(this, typeof(CarrinhoActivity)));
                    };
                }

                telaCriada = true;
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
            if (FinalizarTela)
                Finish();
            base.OnResume();
            
            _produtoAdp = new PedidoEntradaAdapter(this, _lstProduto);
            _produtoListView.Adapter = _produtoAdp;

        }

        private string ExibirDialogQtd(int prod)
        {
            string result = "";
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Quantidade");
            alert.SetMessage("informe a quantidade de " + _lstProduto[prod].Descricao);

            EditText t = new EditText(this);
            t.InputType = InputTypes.NumberFlagDecimal;
            LinearLayout.LayoutParams parametros = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            parametros.SetMargins(10,10,10,10);
            t.LayoutParameters = parametros;

            alert.SetView(t);
            alert.SetPositiveButton("Confirmar", (sender, args) => {

                string valor = FindViewById<TextView>(Resource.Id.txtValorCarrinho).Text.Replace("R$", "").Trim();
                double valorReal = double.Parse(valor);

                _lstProduto[prod].Quantidade -= int.Parse(t.Text);
                valorReal += (int.Parse(t.Text) * _lstProduto[prod].ValorBeta);
                FindViewById<TextView>(Resource.Id.txtValorCarrinho).Text = "R$ " + valorReal.ToString("#0.00");
                result = t.Text;
                OnResume();
            });
            alert.SetNegativeButton("Cancelar", (sender, args) => { return; });
            alert.Show();


            return result;
        }

        private List<Produto> ListaDemo()
        {
            List<Produto> result = new List<Produto>();
            result.Add(new Produto() { Id = 1, Descricao = "Combo Absolut Vodka + 6 energetico", Valor = 300.00, ValorBeta = 245.50, Quantidade = 87 });
            result.Add(new Produto() { Id = 2, Descricao = "Cerveja long neck budweiser 350ml", Valor = 5.00, ValorBeta = 4.00, Quantidade = 400 });
            result.Add(new Produto() { Id = 3, Descricao = "Champagne Veuve Clicquot Brut 750ml", Valor = 530.00, ValorBeta = 415.00, Quantidade = 15 });
            result.Add(new Produto() { Id = 4, Descricao = "Água Mineral sem gás 500ml Crystal", Valor = 2.50, ValorBeta = 1.90, Quantidade = 200 });

            return result;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            telaCriada = false;
        }
    }
}