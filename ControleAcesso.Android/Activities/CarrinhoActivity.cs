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
    [Activity(Label = "CarrinhoActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class CarrinhoActivity : Activity
    {
        protected List<Produto> _lstProduto;
        protected ListView _produtoListView = null;
        protected ProdutoAdapter _produtoAdp;
        protected Button btnFinalizarCompraCarrinho;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Carrinho);

            _produtoListView = FindViewById<ListView>(Resource.Id.lstProdutosEntradaPedido);
            btnFinalizarCompraCarrinho = FindViewById<Button>(Resource.Id.btnFinalizarCompraCarrinho);


            if (_produtoListView != null)
            {
                _produtoListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    RemoverProduto(e.Position);
                };
            }

            if (btnFinalizarCompraCarrinho != null)
            {
                btnFinalizarCompraCarrinho.Click += (object sender, System.EventArgs e) =>
                {
                    ExibirConfirmacao();
                };
            }

            _lstProduto = ListaDemo();
        }
        protected override void OnResume()
        {
            base.OnResume();

            _produtoAdp = new ProdutoAdapter(this, _lstProduto,true);
            _produtoListView.Adapter = _produtoAdp;

        }

        private void RemoverProduto(int produto)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Remover este item do carrinho?");
            alert.SetPositiveButton("Sim", (sender, args) => {
                _lstProduto.RemoveAt(produto);
                OnResume();
            });
            alert.SetNegativeButton("Não", (sender, args) => { return; });
            alert.Show();
        }

        private void ExibirConfirmacao()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Deseja realmente finalizar a compra ?");
            alert.SetPositiveButton("Sim", (sender, args) => {
                PedidoEntradaActivity.FinalizarTela = true;
                Finish();
            });
            alert.SetNegativeButton("Não", (sender, args) => { return; });
            alert.Show();
        }

        private List<Produto> ListaDemo()
        {
            List<Produto> result = new List<Produto>();
            result.Add(new Produto() { Id = 1, Descricao = "Combo Absolut Vodka + 6 energetico", Valor = 300.00, ValorBeta = 245.50, Quantidade = 1 });
            result.Add(new Produto() { Id = 2, Descricao = "Cerveja long neck budweiser 350ml", Valor = 5.00, ValorBeta = 4.00, Quantidade = 6 });
            result.Add(new Produto() { Id = 3, Descricao = "Champagne Veuve Clicquot Brut 750ml", Valor = 530.00, ValorBeta = 415.00, Quantidade = 1 });

            return result;
        }
    }
}