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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatrimoineDeFrance
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class VueUtilisateur : Page
    {
        bool value;
        public VueUtilisateur()
        {
            this.InitializeComponent();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigated += OnRetour;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            value = (bool)Application.Current.Resources["state"];
            if (value)
            {
                btnConnexion.Background = new SolidColorBrush(GetSolidColorBrush("#FF84CE80").Color);
                btnInscription.Background = new SolidColorBrush(GetSolidColorBrush("#FFCCCCCC").Color);
                inputReMdp.Visibility = Visibility.Collapsed;
                btnValidation.Content = "Connexion";
            }
            else
            {
                btnConnexion.Background = new SolidColorBrush(GetSolidColorBrush("#FFCCCCCC").Color);
                btnInscription.Background = new SolidColorBrush(GetSolidColorBrush("#FF84CE80").Color);
                inputReMdp.Visibility = Visibility.Visible;
                btnValidation.Content = "Inscription";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        void OnRetour(Object sender, NavigationEventArgs e)
        {
            if (((Frame)sender).CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack) { e.Handled = true; rootFrame.GoBack(); }
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            value = true;
            btnConnexion.Background = new SolidColorBrush(GetSolidColorBrush("#FF84CE80").Color);
            btnInscription.Background = new SolidColorBrush(GetSolidColorBrush("#FFCCCCCC").Color);
            inputReMdp.Visibility = Visibility.Collapsed;
            btnValidation.Content = "Connexion";
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {
            value = false;
            btnConnexion.Background = new SolidColorBrush(GetSolidColorBrush("#FFCCCCCC").Color);
            btnInscription.Background = new SolidColorBrush(GetSolidColorBrush("#FF84CE80").Color);
            inputReMdp.Visibility = Visibility.Visible;
            btnValidation.Content = "Inscription";
        }

        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["connected"] = true;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
