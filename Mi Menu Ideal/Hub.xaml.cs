using System;
using System.Collections.Generic;
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
    public sealed partial class Hub : Page
    {
        Frame rootFrame;

        public Hub()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            rootFrame = Window.Current.Content as Frame;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

            //podemos ver los metodos
            SystemNavigationManager.GetForCurrentView().BackRequested += Hub_BackRequested;
        }

        private void Hub_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
    }
}
