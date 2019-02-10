using dll.Metiers;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatrimoineDeFrance
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class VueCours : Page
    {
        private List<Cours> listCours = Cours.ListCours();
        private Utilisateur utilisateur;
        //private Donnee mesCours;

        public VueCours()
        {
            this.InitializeComponent();
            //chargement de l'utilisateur connecté
            if (Application.Current.Resources.ContainsKey("utilisateur"))
            {
                utilisateur = (Utilisateur)Application.Current.Resources["utilisateur"];
                txtUser.Text = utilisateur.Prenom;
            }
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigated += OnRetour;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            lstBoxCours.ItemsSource = listCours;


            imgCour.Source = new BitmapImage(new Uri(Images.Load(listCours[0].ImageId).Url));
            txtCourName.Text = listCours[0].Titre;
            txtCour.Text = listCours[0].Texte;
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private void btnQuizzPage_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueQuiz));
        }

        private void lstBoxCours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cours coursSelected = (Cours)lstBoxCours.SelectedItem;
            txtCourName.Text = coursSelected.Titre;
            imgCour.Source = new BitmapImage(new Uri(Images.Load(coursSelected.ImageId).Url));
            txtCour.Text = coursSelected.Texte;
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueCompte));
        }
    }
}
