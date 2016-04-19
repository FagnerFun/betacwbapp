
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using ControleAcesso.Dominio.Entidade;
using ZXing.Mobile;

namespace ControleAcesso.Android.Activities
{
    [Activity(Label = "UsuarioCadActivity", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen")]
    public class UsuarioCadActivity : Activity
    {
        Button btnCadastrar;
        Button btnBuscaUsuario;

        EditText edtNomeCadUsuario;
        EditText edtDataCadUsuario;
        EditText edtTelefoneCadUsuario;
        EditText edtCPFCadUsuario;
        EditText edtEmailCadUsuario;

        public static Usuario usuarioBusca;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CadastroUsuario);


            btnCadastrar = FindViewById<Button>(Resource.Id.btnProximoPasso2);
            btnBuscaUsuario = FindViewById<Button>(Resource.Id.btnBuscarCadUsuario);


            edtNomeCadUsuario = FindViewById<EditText>(Resource.Id.edtNomeCadUsuario);
            edtDataCadUsuario = FindViewById<EditText>(Resource.Id.edtDataCadUsuario);
            edtTelefoneCadUsuario = FindViewById<EditText>(Resource.Id.edtTelefoneCadUsuario);
            edtCPFCadUsuario = FindViewById<EditText>(Resource.Id.edtCPFCadUsuario);
            edtEmailCadUsuario = FindViewById<EditText>(Resource.Id.edtEmailCadUsuario);

            if (btnBuscaUsuario != null)
            {
                btnBuscaUsuario.Click += (sender, e) =>
                {
                    StartActivity(new Intent(this, typeof(BuscaUsuarioActivity)));
                };
            }

            if (btnCadastrar != null)
            {
                btnCadastrar.Click += async (sender, e) =>
                {
                    var scanner = new MobileBarcodeScanner();
                    var result = await scanner.Scan();

                    if (result != null)
                    {
                        RunOnUiThread(() => Toast.MakeText(this, result.Text, ToastLength.Short).Show());
                        usuarioBusca = null;
                        Finish();
                    }
                };
            }

        }

        protected override void OnResume()
        {
            base.OnResume();

            if (usuarioBusca != null)
            {
                edtNomeCadUsuario.Text = usuarioBusca.Nome;
                edtDataCadUsuario.Text = usuarioBusca.DataNascimento.ToString("dd/MM/yyyy");
                edtTelefoneCadUsuario.Text = usuarioBusca.Telefone;
                edtCPFCadUsuario.Text = usuarioBusca.CPF.ToString();
                edtEmailCadUsuario.Text = usuarioBusca.Email;
            }
        }
    }
}