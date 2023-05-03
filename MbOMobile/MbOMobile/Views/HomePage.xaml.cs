using MbOMobile.Models;
using MbOMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MbOMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public Objetivo objetivo { get; set; }

        public Usuario usuario { get; set; }

        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            NavigationPage.SetHasNavigationBar(this, true);

            //Label saudacaoLabel = this.FindByName<Label>("saudacaoLbl");

            //saudacaoLabel.Text = $"Bem vindo {usuario}!";

            CarregarUsuario(TransportadorDados.Email);

            
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //}

        protected async void CarregarUsuario(string email)
        {
            ActivityIndicator activityIndicator = new ActivityIndicator { Color = Color.Orange };
            activityIndicator.IsRunning = true;

            string uri = $"http://10.0.2.2:5203/api/usuario/GetUsuariosByEmail/{email}";

            var client = new HttpClient();
            var json = await client.GetStringAsync(uri);
            var dados = JsonConvert.DeserializeObject<Usuario>(json);
            TransportadorDados.usuario = dados;

            // Coleção sincronizável com o ListView
            //ObservableCollection<Objetivo> objetivos = new ObservableCollection<Objetivo>(dados);
            //ObservableCollection<Usuario> usuarioInfo = new ObservableCollection<Usuario>(dados);

            //listViewObjetivos.ItemsSource = objetivos;
            //listViewObjetivos.ItemsSource = usuarioInfo;

            Label lblSaudacao = this.FindByName<Label>("lblSaudacao");
            int index = dados.Nome.IndexOf(' ');
            string nomeUsuario = dados.Nome.Substring(0, index);
            lblSaudacao.Text = $"Bem vindo {nomeUsuario}!";

            //uri = $"http://10.0.2.2:5203/api/usuario/GetUsuariosByEmail/{email}";
            //client = new HttpClient();
            //json = await client.GetStringAsync(uri);
            //dados = JsonConvert.DeserializeObject<Usuario>(json);

            uri = $"http://10.0.2.2:5203/api/Objetivo/GetObjetivoByIdUsuario/{dados.Id}";
            client = new HttpClient();
            json = await client.GetStringAsync(uri);
            var dadosObj = JsonConvert.DeserializeObject<Objetivo[]>(json);
            List<Objetivo> listaObjetivos = new List<Objetivo>();


            foreach (var obj in dadosObj)
            {
                listaObjetivos.Add(obj);
            }

            TransportadorDados.objetivos = listaObjetivos;

            uri = "http://10.0.2.2:5203/api/ObjetivoComum/GetObjetivosComuns/";
            client = new HttpClient();
            json = await client.GetStringAsync(uri);
            var dadosObjComum = JsonConvert.DeserializeObject<ObjetivoComum[]>(json);
            List<ObjetivoComum> listaObjComuns = new List<ObjetivoComum>();

            foreach (var objCom in dadosObjComum)
            {
                listaObjComuns.Add(objCom);
            }

            TransportadorDados.objetivosComuns = listaObjComuns;

            activityIndicator.IsRunning = false;
        }

        private void listViewObjetivos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}