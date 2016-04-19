using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace ControleAcesso.Android.Adapter
{
    public class ProdutoAdapter : BaseAdapter<Dominio.Entidade.Produto>
    {
        List<Dominio.Entidade.Produto> items;
        Activity context;
        bool TelaResumo;

        public ProdutoAdapter(Activity context, List<Dominio.Entidade.Produto> items, bool TelaResumo)
        {
            this.items = items;
            this.context = context;
            this.TelaResumo = TelaResumo;
        }

        public override Dominio.Entidade.Produto this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Dominio.Entidade.Produto item = items[position];
            View view = convertView;
            if (TelaResumo)
                view = context.LayoutInflater.Inflate(Resource.Layout.ProdutoListResumo, null);
            else
                view = context.LayoutInflater.Inflate(Resource.Layout.ProdutoList, null);

            view.FindViewById<TextView>(Resource.Id.txtDescricaoProdutoList).Text = item.Descricao;
            view.FindViewById<TextView>(Resource.Id.txtValorBetaProdutoList).Text = item.ValorBeta.ToString();
            view.FindViewById<TextView>(Resource.Id.txtValorProdutoList).Text = item.Valor.ToString();
            view.FindViewById<TextView>(Resource.Id.txtQuantidadeProdutoList).Text = item.Quantidade.ToString();
            return view;
        }
    }
}