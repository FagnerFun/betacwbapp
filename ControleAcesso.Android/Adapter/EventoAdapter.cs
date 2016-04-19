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
    public class EventoAdapter : BaseAdapter<Dominio.Entidade.Evento>
    {
        List<Dominio.Entidade.Evento> items;
        Activity context;

        public EventoAdapter(Activity context, List<Dominio.Entidade.Evento> items)
        {
            this.items = items;
            this.context = context;
        }

        public override Dominio.Entidade.Evento this[int position]
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
            Dominio.Entidade.Evento item = items[position];
            View view = convertView;
            view = context.LayoutInflater.Inflate(Resource.Layout.EventoList, null);

            view.FindViewById<TextView>(Resource.Id.txtDescricaoEventoList).Text = item.Descricao;
            view.FindViewById<TextView>(Resource.Id.txtLocalEventoList).Text = item.Local;
            view.FindViewById<TextView>(Resource.Id.txtDataEventoList).Text = item.Data.ToString("dd/MM/yyyy");
            return view;
        }
    }
}