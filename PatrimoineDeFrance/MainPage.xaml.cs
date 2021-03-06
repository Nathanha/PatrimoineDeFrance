﻿using dll.Metiers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PatrimoineDeFrance
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Question> listQuestion = Question.ListQuestions();
        private Utilisateur utilisateur;
        private Professeur professeur;
        bool stateUser;
        bool connected;
        bool isProfessor;
        // Question uneQuestion = new Question();

        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Test");
            stateUser = false;
            isProfessor = false;
            if (Application.Current.Resources.ContainsKey("connected"))
            {
                connected = (bool)Application.Current.Resources["connected"];
                inputName.Visibility = Visibility.Collapsed;
                inputMdp.Visibility = Visibility.Collapsed;
                btnValidation.Visibility = Visibility.Collapsed;
                gridMain.Visibility = Visibility.Visible;
                if (Application.Current.Resources.ContainsKey("isProfessor"))
                {
                    isProfessor = (bool)Application.Current.Resources["isProfessor"];
                }
            }
            else
            {
                connected = false;
                inputName.Visibility = Visibility.Visible;
                inputMdp.Visibility = Visibility.Visible;
                btnValidation.Visibility = Visibility.Visible;
                gridMain.Visibility = Visibility.Collapsed;
            }

            Application.Current.Resources.Remove("eleve");
            Application.Current.Resources.Remove("cours");
            Application.Current.Resources.Remove("quizz");
        }

        public VueCours VueCours
        {
            get => default(VueCours);
            set
            {
            }
        }

        public VueQuiz VueQuiz
        {
            get => default(VueQuiz);
            set
            {
            }
        }

        public VueProf VueProf
        {
            get => default(VueProf);
            set
            {
            }
        }

        public VueCompte VueCompte
        {
            get => default(VueCompte);
            set
            {
            }
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

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            utilisateur = Utilisateur.GetUser(nomInput.Text);
            if (utilisateur.MotDePasse == mdpInput.Password)
            {
                isProfessor = false;
                Application.Current.Resources["connected"] = true;
                Application.Current.Resources["utilisateur"] = utilisateur;
                Application.Current.Resources["isProfessor"] = false;
                inputName.Visibility = Visibility.Collapsed;
                inputMdp.Visibility = Visibility.Collapsed;
                btnValidation.Visibility = Visibility.Collapsed;
                txtError.Text = "";
                mdpInput.Password = "";
                nomInput.Text = "";
                gridMain.Visibility = Visibility.Visible;
            }
            else
            {
                professeur = Professeur.GetProfesseur(nomInput.Text);
                if (professeur.MotDePasse == mdpInput.Password)
                {
                    isProfessor = true;
                    Application.Current.Resources["connected"] = true;
                    Application.Current.Resources["professeur"] = professeur;
                    Application.Current.Resources["isProfessor"] = true;
                    inputName.Visibility = Visibility.Collapsed;
                    inputMdp.Visibility = Visibility.Collapsed;
                    btnValidation.Visibility = Visibility.Collapsed;
                    txtError.Text = "";
                    mdpInput.Password = "";
                    nomInput.Text = "";
                    gridMain.Visibility = Visibility.Visible;
                }
                else
                {
                    txtError.Text = "Mot de passe incorect";
                }
            }

        }

        private void btnCours_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueCours));
        }

        private void btnQuizz_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueQuiz));
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            if (stateUser)
            {
                AnimatedUserReverse.Begin();
                AnimatedBtn1Reverse.Begin();
                AnimatedBtn2Reverse.Begin();
                stateUser = false;
            }
            else
            {
                AnimatedUser.Begin();
                AnimatedBtn1.Begin();
                AnimatedBtn2.Begin();
                stateUser = true;
            }
        }

        private void BtnCompte_Click(object sender, RoutedEventArgs e)
        {
            if (isProfessor)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(VueProf));
            }else
            { 
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(VueCompte));
            }
        }

        private void BtnDeco_Click(object sender, RoutedEventArgs e)
        {
            //Frame rootFrame = Window.Current.Content as Frame;
            //rootFrame.Navigate(typeof(VueAjouterEleve));
            connected = false;
            inputName.Visibility = Visibility.Visible;
            inputMdp.Visibility = Visibility.Visible;
            btnValidation.Visibility = Visibility.Visible;
            gridMain.Visibility = Visibility.Collapsed;
        }
    }
}
