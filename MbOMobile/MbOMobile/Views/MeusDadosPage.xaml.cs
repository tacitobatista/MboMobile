using MbOMobile.Models;
using MbOMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MbOMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusDadosPage : ContentPage
    {
        public MeusDadosPage()
        {
            InitializeComponent();

            Label nomeAtual = this.FindByName<Label>("nomeAtual");
            nomeAtual.Text = $"Nome: {TransportadorDados.usuario.Nome}";

            Label emailAtual = this.FindByName<Label>("emailAtual");
            emailAtual.Text = $"E-mail: {TransportadorDados.usuario.Email}";
        }

        private async void btnAtualizarCadastro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtualizarCadastroPage());
        }

        private async void btnAlterarSenha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlterarSenhaPage());
        }
    }
}