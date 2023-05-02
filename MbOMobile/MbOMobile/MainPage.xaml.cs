using MbOMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MbOMobile
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listaMenu.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as FlyoutItemPage; 
            if (item != null) 
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.PaginaAlvo));
                flyout.listaMenu.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
