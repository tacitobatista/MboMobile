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
	public partial class AlterarSenhaPage : ContentPage
	{
		public Usuario usuarioSenhaAlterada { get; set; }

		public AlterarSenhaPage ()
		{
			InitializeComponent ();
		}

        private async void btnAlterar_Clicked(object sender, EventArgs e)
        {

            bool confirmacao = await DisplayAlert("Confirmação:", "Confirmar alteração?", "Sim", "Não");

            if (confirmacao)
            {
                Entry senhaAtual = this.FindByName<Entry>("senhaAtual");
                Entry senhaNova = this.FindByName<Entry>("senhaNova");
                Entry confirmacaoSenhaNova = this.FindByName<Entry>("confirmacaoSenhaNova");

                if (senhaAtual.Text == TransportadorDados.usuario.Senha)
                {
                    if (senhaNova.Text == confirmacaoSenhaNova.Text)
                    {
                        var client = new HttpClient();
                        string uri = "http://10.0.2.2:5203/api/usuario/EditarUsuario";

                        usuarioSenhaAlterada = TransportadorDados.usuario;
                        usuarioSenhaAlterada.Senha = senhaNova.Text;


                        var data = JsonConvert.SerializeObject(usuarioSenhaAlterada);
                        var content = new StringContent(data, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(uri, content);

                        if (response.IsSuccessStatusCode)
                        {
                            TransportadorDados.usuario = usuarioSenhaAlterada;
                            await DisplayAlert("Sucesso", "Senha alterada!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Erro", "Ocorreu um erro", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Erro", "A confirmação precisa ser igual a nova senha.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Erro", "Senha atual incorreta.", "OK");
                }
            }
            else
            {

            }

        }
    }
}