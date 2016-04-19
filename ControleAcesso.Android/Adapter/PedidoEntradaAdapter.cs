using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace ControleAcesso.Android.Adapter
{
    public class PedidoEntradaAdapter : BaseAdapter<Dominio.Entidade.Produto>
    {
        List<Dominio.Entidade.Produto> items;
        Activity context;

        public PedidoEntradaAdapter(Activity context, List<Dominio.Entidade.Produto> items)
        {
            this.items = items;
            this.context = context;
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

            view = context.LayoutInflater.Inflate(Resource.Layout.PedidoEntradaList, null);

            view.FindViewById<TextView>(Resource.Id.txtDescricaoProdutoList).Text = item.Descricao;
            view.FindViewById<TextView>(Resource.Id.txtValorProdutoList).Text = item.Valor.ToString();
            return view;
        }
    }
}