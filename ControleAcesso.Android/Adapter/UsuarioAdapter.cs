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
    public class UsuarioAdapter : BaseAdapter<Dominio.Entidade.Usuario>
    {
        List<Dominio.Entidade.Usuario> items;
        Activity context;

        public UsuarioAdapter(Activity context, List<Dominio.Entidade.Usuario> items)
        {
            this.items = items;
            this.context = context;
        }

        public override Dominio.Entidade.Usuario this[int position]
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
            Dominio.Entidade.Usuario item = items[position];
            View view = convertView;
            view = context.LayoutInflater.Inflate(Resource.Layout.UsuarioList, null);

            view.FindViewById<TextView>(Resource.Id.txtNomeUsuarioList).Text = item.Nome;
            view.FindViewById<TextView>(Resource.Id.txtEmailUsuarioList).Text = item.Email;
            view.FindViewById<TextView>(Resource.Id.txtCpfUsuarioList).Text = item.CPF.ToString();

            return view;
        }
    }
}