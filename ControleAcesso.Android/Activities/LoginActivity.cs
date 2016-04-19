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
using Android.Speech;
using Android.Content.PM;

namespace ControleAcesso.Android.Activities
{

    [Activity(Label = "Beta CWB", Theme = "@android:style/Theme.Light.NoTitleBar.Fullscreen", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        private const int VOICE_RECOGNITION_REQUEST_CODE = 1234;

        // COMPONENTES DE TELA
        protected EditText _edtUsuarioLogin = null;
        protected EditText _edtSenhaLogin = null;
        protected Button _btnLogarLogin = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

           // string folder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "base.db3");
            //UsuarioServico controler = new UsuarioServico(new UsuarioRepositorio(folder, new SQLitePlatformAndroid()));

            _edtUsuarioLogin = FindViewById<EditText>(Resource.Id.edtUsuarioLogin);
            _edtSenhaLogin = FindViewById<EditText>(Resource.Id.edtSenhaLogin);
            _btnLogarLogin = FindViewById<Button>(Resource.Id.btnLogarLogin);

            if (_btnLogarLogin != null)
            {
                _btnLogarLogin.Click += (sender, e) => {
                    Login();
                };
            }

            //EVENTO ENTER EDIT SENHA
            if (_edtSenhaLogin != null)
            {
                _edtSenhaLogin.KeyPress += (object sender, View.KeyEventArgs e) => {
                    e.Handled = false;
                    if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                    {
                        Login();
                        e.Handled = true;
                    }
                };
            }

            ImageButton buttonLoginVoz = FindViewById<ImageButton>(Resource.Id.btnVozLogin);
            buttonLoginVoz.Click += delegate (object sender, EventArgs e)
            {
                //Controle de voz
                PackageManager pm = PackageManager;
                IList<ResolveInfo> activities = pm.QueryIntentActivities(new Intent(RecognizerIntent.ActionRecognizeSpeech), 0);

                if (activities.Count != 0)
                {
                    StartVoiceRecognitionActivity();
                }
                else {
                    RunOnUiThread(() => Toast.MakeText(this, "O DISPOSITIVO NÃO POSSUI NENHUM RECURSO DE VOZ", ToastLength.Short).Show());
                }
            };
        }
        
        private void Login()
        {
            if (_edtUsuarioLogin.Text == "beta" && _edtSenhaLogin.Text == "123")
            {
                _edtSenhaLogin.Text = "";
                AbrirMenu();
            }
            else {
                RunOnUiThread(() => Toast.MakeText(this, "Login Inválido", ToastLength.Short).Show()); ;
            }
         }

        private void AbrirMenu()
        {
            StartActivity(new Intent(this, typeof(MenuAcessoActivity)));
        }

        /// <summary>
		/// Intent de reconhecimento de voz
		/// </summary>
		private void StartVoiceRecognitionActivity()
        {
            Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            intent.PutExtra(RecognizerIntent.ExtraCallingPackage, PackageName);
            intent.PutExtra(RecognizerIntent.ExtraPrompt, "Leitura do usuario por voz");
            intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            intent.PutExtra(RecognizerIntent.ExtraMaxResults, 5);
            StartActivityForResult(intent, VOICE_RECOGNITION_REQUEST_CODE);
        }

        /// <param name="requestCode">The integer request code originally supplied to
        ///  startActivityForResult(), allowing you to identify who this
        ///  result came from.</param>
        /// <param name="resultCode">The integer result code returned by the child activity
        ///  through its setResult().</param>
        /// <param name="data">An Intent, which can return result data to the caller
        ///  (various data can be attached to Intent "extras").</param>
        /// <summary>
        /// Called when an activity you launched exits, giving you the requestCode
        ///  you started it with, the resultCode it returned, and any additional
        ///  data from it.
        /// </summary>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == VOICE_RECOGNITION_REQUEST_CODE && resultCode == Result.Ok)
            {
                // Fill the list view with the strings the recognizer thought it could have heard
                IList<String> matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                string voz = matches[0];
                _edtUsuarioLogin.Text = voz.ToLower();
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }

        /// <summary>
        /// Tratamento para quando um usuário clicar na seta 'voltar' na tela de Login
        /// O que o levará a sair do sistema
        /// </summary>
        public override void OnBackPressed()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Atenção");
            alert.SetMessage("Deseja realmente sair do sistema ?");
            alert.SetPositiveButton("Sim", (sender, args) => {
                Process.KillProcess(Process.MyPid());
            });
            alert.SetNegativeButton("Não", (sender, args) => { return; });
            alert.Show();
        }
    }
}