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

namespace ControleAcesso.Android.Adapter
{
    public class MenuAdapter : BaseAdapter<Dominio.Entidade.Menu>
    {
        List<Dominio.Entidade.Menu> items;
        Activity context;

        public MenuAdapter(Activity context, List<Dominio.Entidade.Menu> items)
        {
            this.items = items;
            this.context = context;
        }

        public override Dominio.Entidade.Menu this[int position]
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
            Dominio.Entidade.Menu item = items[position];
            View view = convertView;
            view = context.LayoutInflater.Inflate(Resource.Layout.MenuList, null);

            view.FindViewById<TextView>(Resource.Id.txtTituloMenuListItem).Text = item.Titulo;
            view.FindViewById<TextView>(Resource.Id.txtDescricaoMenuListItem).Text = item.Descricao;

            if (item.Imagem != "")
            {
                int id_img = context.Resources.GetIdentifier(item.Imagem, "drawable", context.PackageName);
                view.FindViewById<ImageView>(Resource.Id.imgMenuListItem).SetImageResource(id_img);
            }
            return view;
        }
    }
}