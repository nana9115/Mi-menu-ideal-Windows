using Mi_Menu_Ideal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Mi_Menu_Ideal
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        public AdminPage()
        {
            this.InitializeComponent();
            //guarda el estado de la pagina
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                = AppViewBackButtonVisibility.Visible;
        }


        private ObservableCollection<MenuItem> menuList;

        public ObservableCollection<MenuItem> MenuList
        {
            get
            {
                if (menuList == null)
                {
                    menuList = new ObservableCollection<MenuItem>();

                    MenuItem item1 = new MenuItem() { Nombre = "Administrador", Icon = "Admin" };
                    MenuItem item2 = new MenuItem() { Nombre = "Mesero", Icon = "People" };
                    MenuItem item3 = new MenuItem() { Nombre = "Cocina", Icon = "MailForward" };

                    menuList.Add(item1);
                    menuList.Add(item2);
                    menuList.Add(item3);

                }
                return menuList;
            }
            set { menuList = value; }
        }

        private ObservableCollection<GaleryItem> galery;

        public ObservableCollection<GaleryItem> Galery
        {
            get
            {
                if (galery == null)
                {
                    galery = new ObservableCollection<GaleryItem>();

                    GaleryItem item1 = new GaleryItem() { NameImg = "Comidas Rapidas", Url = "http://www.publitell.com/system/fotos/43567/perros-calientes.jpg" };
                    GaleryItem item2 = new GaleryItem() { NameImg = "Bebidas", Url = "http://static.imujer.com/sites/default/files/elgrancatador/las-3%20bebidas-alcoholicas-que-dejan-menos-resaca-3.jpg" };
                    GaleryItem item3 = new GaleryItem() { NameImg = "Heladeria", Url = "http://www.recetin.com/wp-content/uploads/2013/07/helado_fresa1.jpg" };
                    GaleryItem item4 = new GaleryItem() { NameImg = "Varios", Url = "http://orsimages.unileversolutions.com/ORS_Images/Knorr_es-CO/Empanadas_de_carne_28_1.3.6_326X580.Jpeg" };

                    galery.Add(item1);
                    galery.Add(item2);
                    galery.Add(item3);
                    galery.Add(item4);

                }
                return galery;
            }
            set { galery = value; }
        }



        private void showMenu(object sender, RoutedEventArgs e)
        {
            if (split.IsPaneOpen)
            {
                split.IsPaneOpen = false;
            }
            else
            {
                split.IsPaneOpen = true;
            }
        }

        private void goToAdd(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof (AddGalery), "hollllllaaaaaaaaaa");

        }

        private void editGalery(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(EditPage), "hollllllaaaaaaaaaa");
        }

        private void openPage(object sender, SelectionChangedEventArgs e)
        {
            if(grid.SelectedIndex != -1)
            { 
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Hub), Galery.ElementAt(grid.SelectedIndex));
            }
        }

        private void putContent(object sender, SelectionChangedEventArgs e)
        {
            Contenido.Navigate(typeof(GaleriaPage));
        }
    }

}
