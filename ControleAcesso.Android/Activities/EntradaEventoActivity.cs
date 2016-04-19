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

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "Activity1", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class EntradaEventoActivity : Activity
    {
        protected List<Dominio.Entidade.Evento> _lstEvento;
        protected ListView _eventosListView = null;
        protected EventoAdapter _menusAdp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.Evento);

            _lstEvento = new List<Dominio.Entidade.Evento>();
            _lstEvento.Add(new Dominio.Entidade.Evento() { Id = 1, Data = new DateTime(2016, 07, 09), Local = "Chacará do Sol", Descricao = "Festa de Seleção I" });
            _lstEvento.Add(new Dominio.Entidade.Evento() { Id = 2, Data = new DateTime(2017, 02, 15), Local = "Purple Hills", Descricao = "Festa de Seleção II" });
            _lstEvento.Add(new Dominio.Entidade.Evento() { Id = 3, Data = new DateTime(2017, 06, 27), Local = "Av: Sete de Setembro, 4995", Descricao = "Primeira Cervejada Beta" });

            _eventosListView = FindViewById<ListView>(Resource.Id.lstEventos);
            _menusAdp = new EventoAdapter(this, _lstEvento);
            _eventosListView.Adapter = _menusAdp;

            if (_eventosListView != null)
            {
                _eventosListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    var itens = new Intent(this, typeof(EntradaActivity));
                    Dominio.Entidade.Evento item = _menusAdp[e.Position];
                    itens.PutExtra("idEvento", item.Id);
                    StartActivity(itens);
                };
            }
        }
    }
}