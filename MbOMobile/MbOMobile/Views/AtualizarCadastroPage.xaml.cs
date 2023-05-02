using MbOMobile.Models;
using MbOMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MbOMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AtualizarCadastroPage : ContentPage
	{
        public Usuario usuarioAlterado { get; set; }

		public AtualizarCadastroPage ()
		{
			InitializeComponent ();

            Entry nomeAlteravel = this.FindByName<Entry>("nomeAlteravel");
            nomeAlteravel.Text = $"{TransportadorDados.usuario.Nome}";

            Entry emailAlteravel = this.FindByName<Entry>("emailAlteravel");
            emailAlteravel.Text = $"{TransportadorDados.usuario.Email}";
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            bool confirmacao = await DisplayAlert("Confirmação:", "Confirmar alteração?", "Sim", "Não");

            if (confirmacao)
            {

                var client = new HttpClient();
                string uri = "http://10.0.2.2:5203/api/usuario/EditarUsuario";

                usuarioAlterado = TransportadorDados.usuario;
                usuarioAlterado.Nome = nomeAlteravel.Text;
                usuarioAlterado.Email = emailAlteravel.Text;


                var data = JsonConvert.SerializeObject(usuarioAlterado);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    TransportadorDados.usuario = usuarioAlterado;
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Ocorreu um erro", "OK");
                }
            }
            else
            {

            }
                
        }
    }
}