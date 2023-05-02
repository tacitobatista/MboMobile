using MbOMobile.Models;
using MbOMobile.Services;
using MbOMobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MbOMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public Usuario usuarioInfo { get; set; }


        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this,false);

        }

        private async void btnConectar_Clicked(object sender, EventArgs e)
        {
            //efetuar call da api de login

            ActivityIndicator activityIndicator = new ActivityIndicator { Color = Color.Orange };
            activityIndicator.IsRunning = true;

            string usuarioTemp = usuario.Text;

            var usuarioContent = JsonConvert.SerializeObject(usuarioInfo);
            var buffer = System.Text.Encoding.UTF8.GetBytes(usuarioContent);
            var byteContent = new ByteArrayContent(buffer);

            var uri = $"http://10.0.2.2:5203/api/Autenticacao/GetAutenticacao/{usuario.Text}/{senha.Text}";

            var client = new HttpClient();

            //HttpResponseMessage response = await client.GetStringAsync(uri).Result;

            HttpResponseMessage reposta = await client.PostAsync(uri, byteContent);

            //var json = await client.GetStringAsync(uri);

            if (reposta.IsSuccessStatusCode)
            {
                activityIndicator.IsRunning = false;
                TransportadorDados.Email = usuario.Text;
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                activityIndicator.IsRunning = false;
                TransportadorDados.Email = "";
                await DisplayAlert("Ops...", "Usuário ou senha incorretos!", "Ok");
            }


            //if (usuario.Text=="Teste1" && senha.Text=="123")
            //{
            //    await Navigation.PushAsync(new HomePage(usuarioTemp));
            //}
            //else
            //{
            //    await DisplayAlert("Ops...","Usuário ou senha incorretos!","Ok");
            //}
        }
    }
}