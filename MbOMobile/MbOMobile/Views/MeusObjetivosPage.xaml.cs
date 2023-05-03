using MbOMobile.Models;
using MbOMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MbOMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusObjetivosPage : ContentPage
    {
        public MeusObjetivosPage()
        {
            InitializeComponent();
            listViewObjetivos.ItemsSource = TransportadorDados.objetivos;
            listViewObjetivosComuns.ItemsSource = TransportadorDados.objetivosComuns;
        }

        private void listViewObjetivos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Coleção sincronizável com o ListView
            //ObservableCollection<Objetivo> objetivos = new ObservableCollection<Objetivo>(dados);
            //ObservableCollection<Usuario> usuarioInfo = new ObservableCollection<Usuario>(dados);

        }

        private void listViewObjetivosComuns_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}