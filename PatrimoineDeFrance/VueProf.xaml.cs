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
    public sealed partial class VueProf : Page
    {
        private List<Cours> listCours = Cours.ListCours();
        private List<Question> listQuestions = Question.ListQuestions();
        private List<Utilisateur> listUsers;
        private Professeur professeur;

        public VueProf()
        {
            this.InitializeComponent();
            lstBoxCours.ItemsSource = listCours;
            lstBoxQuiz.ItemsSource = listQuestions;
            if (Application.Current.Resources.ContainsKey("professeur"))
            {
                professeur = (Professeur)Application.Current.Resources["professeur"];
                txtNom.Text = professeur.Nom;
                txtPrenom.Text = professeur.Prenom;
                listUsers = Utilisateur.ListClasse(professeur.Classe);
                lstBoxEleve.ItemsSource = listUsers;
            }
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigated += OnRetour;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        public VueAjouterEleve VueAjouterEleve
        {
            get => default(VueAjouterEleve);
            set
            {
            }
        }

        public VueAjouterQuestion VueAjouterQuestion
        {
            get => default(VueAjouterQuestion);
            set
            {
            }
        }

        public VueAjouterCours VueAjouterCours
        {
            get => default(VueAjouterCours);
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

        private void BtnAjouterEleve_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueAjouterEleve));
        }

        private void BtnModifierEleve_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxEleve.SelectedItem != null)
            {
                Application.Current.Resources["eleve"] = (Utilisateur)lstBoxEleve.SelectedItem;
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(VueAjouterEleve));
            }
            else
            {
                //error
            }
        }

        private void BtnSupprimerEleve_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxEleve.SelectedItem != null)
            {
                Utilisateur user = (Utilisateur)lstBoxEleve.SelectedItem;
                Utilisateur.Delete(user.Id);
                listUsers.Remove(user);
            }
            else
            {
                //error
            }
        }

        private void BtnAjouterCours_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueAjouterCours));
        }

        private void BtnModifierCours_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxCours.SelectedItem != null)
            {
                Application.Current.Resources["cours"] = (Cours)lstBoxCours.SelectedItem;
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(VueAjouterCours));
            }
            else
            {
                //error
            }
        }

        private void BtnSupprimerCours_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxCours.SelectedItem != null)
            {
                Cours cours = (Cours)lstBoxCours.SelectedItem;
                Cours.DeleteCours(cours.Id);
                listCours.Remove(cours);
            }
            else
            {
                //error
            }
        }

        private void BtnAjouterQuiz_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueAjouterQuestion));
        }

        private void BtnModifierQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxQuiz.SelectedItem != null)
            {
                Application.Current.Resources["question"] = (Question)lstBoxQuiz.SelectedItem;
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(VueAjouterQuestion));
            }
            else
            {
                //error
            }
        }

        private void BtnSupprimerQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxQuiz.SelectedItem != null)
            {
                Question question = (Question)lstBoxQuiz.SelectedItem;
                Question.DeleteQuestion(question.Id);
                listQuestions.Remove(question);
            }
            else
            {
                //error
            }
        }
    }
}
