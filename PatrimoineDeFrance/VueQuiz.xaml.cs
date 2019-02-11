using dll;
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
    public sealed partial class VueQuiz : Page
    {
        private List<Question> listQuestions;
        private List<Niveau> listNiveau = Niveau.ListNiveau();
        private int index = 0;
        Utilisateur utilisateur = null;

        public VueQuiz()
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

            //Chargement des préférences utilisateurs
            if (Application.Current.Resources.ContainsKey("idUser"))
                utilisateur = Utilisateur.Load((int)Application.Current.Resources["idUser"]);
            else if (!Application.Current.Resources.ContainsKey("niveau"))
                utilisateur = new Utilisateur()
                {
                    Niveau = NiveauIds.Niveau1,
                    Nom = "Non connecté"
                };
            else
                utilisateur = new Utilisateur()
                {
                    Niveau = (NiveauIds)Application.Current.Resources["niveau"]
                };
            //Chargement des niveaux
            lstBoxNiveau.ItemsSource = listNiveau;

            //Chargement de la première question et du premier niveau
            showQuestions(NiveauIds.Niveau1);
        }

        public Images Images
        {
            get => default(Images);
            set
            {
            }
        }

        public Question Question
        {
            get => default(Question);
            set
            {
            }
        }

        public Reponse Reponse
        {
            get => default(Reponse);
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private void btnCourPage_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueCours));
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueCompte));
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            //Vérification de la réponse
            if ((bool)radioReponse1.IsChecked || (bool)radioReponse2.IsChecked || (bool)radioReponse3.IsChecked || (bool)radioReponse4.IsChecked)
            {
                RadioButton rb = null;
                if ((bool)radioReponse1.IsChecked)
                {
                    rb = radioReponse1;
                    radioReponse1.IsChecked = false;
                }
                else if ((bool)radioReponse2.IsChecked)
                {
                    rb = radioReponse2;
                    radioReponse2.IsChecked = false;
                }
                else if ((bool)radioReponse3.IsChecked)
                {
                    rb = radioReponse3;
                    radioReponse3.IsChecked = false;
                }
                else
                {
                    rb = radioReponse4;
                    radioReponse4.IsChecked = false;
                }

                if (Reponse.Load(listQuestions[index].BonneReponseId).Label == (string)rb.Content)
                {
                    if (Application.Current.Resources.ContainsKey("score"))
                    {
                        Application.Current.Resources["score"] = (int)Application.Current.Resources["score"] + 1;
                    }
                    else
                    {
                        Application.Current.Resources["score"] = 1;
                    }

                }

                //Question suivante
                if (listQuestions.Count > index + 1)
                {
                    index++;
                    showQuestions(next: true);
                }
                else
                {
                    if (Application.Current.Resources.ContainsKey("score"))
                    {
                        if ((int)Application.Current.Resources["score"] > 3)
                        {
                            Utils.ShowDialog("Niveau terminé", "Bravo tu as terminé ce niveau ! Score: " + Application.Current.Resources["score"]);
                            Application.Current.Resources["score"] = 0;
                            utilisateur.Niveau += 1;
                            Application.Current.Resources["niveau"] = utilisateur.Niveau;
                        }
                        else
                            Utils.ShowDialog("Recommence", "Tu n'as pas atteint le minimum de point ! Score: " + Application.Current.Resources["score"]);

                    }
                    else
                    {
                        Utils.ShowDialog("Recommence", "Tu n'as pas atteint le minimum de point ! Score: 0");
                    }

                }
            }
            else
            {
                Utils.ShowDialog("Un problème est survenu", "Merci de sélectionner une réponse");
            }


        }

        private void lstBoxNiveau_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Niveau niveau = (Niveau)lstBoxNiveau.SelectedItem;
            if (utilisateur != null && utilisateur.Niveau >= niveau.Id || niveau.Id == NiveauIds.Niveau1)
            {
                this.index = 0;
                showQuestions(niveau.Id);
            }
            else
            {
                Utils.ShowDialog("Un problème est survenu", "Vous n'avez pas encore débloqué ce niveau");
            }


        }

        private void showQuestions(NiveauIds niveau = 0, bool next = false)
        {
            if (!next)
                listQuestions = Question.ListQuestions(niveau);
            if (listQuestions.Count > 0)
            {
                questionTextBlock.Text = listQuestions[index].Label;
                imgQuiz.Source = new BitmapImage(new Uri(Images.Load(listQuestions[index].ImageId).Url));
                List<RadioButton> listRadioButton = new List<RadioButton>();
                listRadioButton.Add(radioReponse1);
                listRadioButton.Add(radioReponse2);
                listRadioButton.Add(radioReponse3);
                listRadioButton.Add(radioReponse4);
                Random rnd = new Random();
                RadioButton bonneReponseRadioButton = listRadioButton.OrderBy(x => rnd.Next()).ToArray()[0];
                listRadioButton.Remove(bonneReponseRadioButton);

                Reponse reponse = Reponse.Load(listQuestions[index].BonneReponseId);
                List<Reponse> mauvaiseReponses = Reponse.ListMauvaiseReponse(reponse.Id, listQuestions[index].Niveau);
                bonneReponseRadioButton.Content = reponse.Label;
                foreach (RadioButton radioAutreReponse in listRadioButton)
                {
                    try
                    {
                        Reponse mauvaiseReponse = mauvaiseReponses.OrderBy(x => rnd.Next()).ToArray().First();
                        radioAutreReponse.Content = mauvaiseReponse.Label;
                        mauvaiseReponses.Remove(mauvaiseReponse);
                    }
                    catch
                    {
                        radioAutreReponse.Content = "Pas assez de réponse";
                    }

                }
            }
            else
            {
                Utils.ShowDialog("Un problème est survenu", "Niveau non disponible !");
            }
        }
    }
}
