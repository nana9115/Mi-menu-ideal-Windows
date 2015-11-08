using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class LoginPage : Page
    {
        ApplicationDataContainer localData;
        const string KEY_USER = "text";

        public LoginPage()
        {
            this.InitializeComponent();
            this.Loaded += LoginPage_Loaded;

            localData = ApplicationData.Current.LocalSettings;
        }

        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (localData.Values.ContainsKey(KEY_USER))
            {
                usern.Text = localData.Values[KEY_USER] as string;
            }
        }

        private async void ingresar(object sender, RoutedEventArgs e)
        {
            localData.Values[KEY_USER] = usern.Text;
            usern.Text = usern.Text;

            try
            {
                await ParseUser.LogInAsync(usern.Text, passw.Password);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(GaleriaPage));
            }
            catch (Exception ev)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(LoginPage));
            }

            
        }

        private void regaqui(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(RegisterPage));
        }
    }
}
