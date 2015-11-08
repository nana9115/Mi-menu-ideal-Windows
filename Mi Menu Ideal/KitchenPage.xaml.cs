using Parse;
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
    public sealed partial class KitchenPage : Page
    {
        Frame rootFrame;
        public KitchenPage()
        {
            listarComida();

            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;



            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

            //podemos ver los metodos
            SystemNavigationManager.GetForCurrentView().BackRequested += KitchenPage_BackRequested;
        }

        private async void listarComida()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Comida");
            IEnumerable<ParseObject> results = await query.FindAsync();

            ParseObject listObject;

            int sizeResult = results.Count();
            string mau = "";
            for (int i = 0; i < sizeResult; i++)
            {
                listObject = results.ElementAt<ParseObject>(i);

                mau +="Nuevo producto:"+ "\n" + listObject.Get<string>("Nombre") + "\n\n" + "Pertence a la categoria:"+ "\n" + listObject.Get<string>("Categoria")+ "\n\n";
                    
            }
            listaComidas.Text = mau;
        }

        private void KitchenPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
    }
}
