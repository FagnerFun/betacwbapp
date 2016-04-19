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
    [Activity(Label = "ProdutoActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class ProdutoActivity : Activity
    {
        protected List<Produto> _lstProduto;
        protected ListView _produtoListView = null;
        protected ProdutoAdapter _produtoAdp;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Produto);

            _produtoListView = FindViewById<ListView>(Resource.Id.lstProdutos);

            _lstProduto = ListaDemo();
            _produtoAdp = new ProdutoAdapter(this, _lstProduto, false);
            _produtoListView.Adapter = _produtoAdp;

        }
        private List<Produto> ListaDemo()
        {
            List<Produto> result = new List<Produto>();
            result.Add(new Produto() { Id = 1, Descricao = "Combo Absolut Vodka + 6 energetico", Valor = 300.00, ValorBeta = 245.50, Quantidade = 100 });
            result.Add(new Produto() { Id = 2, Descricao = "Cerveja long neck budweiser 350ml", Valor = 5.00, ValorBeta = 4.00, Quantidade = 500 });
            result.Add(new Produto() { Id = 3, Descricao = "Champagne Veuve Clicquot Brut 750ml", Valor = 530.00, ValorBeta = 415.00, Quantidade = 15 });

            return result;
        }
    }
}