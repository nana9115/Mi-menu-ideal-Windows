using Mi_Menu_Ideal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class DeletePage : Page
    {
        public DeletePage()
        {
            this.InitializeComponent();
        }
        private ObservableCollection<ProductItem> prodList;

        public ObservableCollection<ProductItem> ProdList
        {
            get
            {
                if (prodList == null)
                {
                    prodList = new ObservableCollection<ProductItem>();

                    ProductItem item = new ProductItem() { NameProd = "Pan" };
                    ProductItem item2 = new ProductItem() { NameProd = "Queso" };
                }

                return prodList;
            }
            set { prodList = value; }
        }

        private void deleteProd(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AdminPage));
        }
    }

   


}
