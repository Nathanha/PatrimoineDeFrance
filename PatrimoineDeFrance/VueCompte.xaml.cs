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
using dll.Metiers;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatrimoineDeFrance
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class VueCompte : Page
    {
        private Utilisateur utilisateur;

        public VueCompte()
        {
            this.InitializeComponent();
            if (Application.Current.Resources.ContainsKey("utilisateur"))
            {
                utilisateur = (Utilisateur)Application.Current.Resources["utilisateur"];
                txtNom.Text = utilisateur.Nom;
                txtPrenom.Text = utilisateur.Prenom;
                txtClasse.Text = utilisateur.Classe.ToString();
                roundNiveau.Content = utilisateur.NiveauId.ToString();
            }
            
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigated += OnRetour;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        public Utilisateur Utilisateur
        {
            get => default(Utilisateur);
            set
            {
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
    }
}
