using dll.Metiers;
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
        bool stateUser;
        bool connected;
        // Question uneQuestion = new Question();

        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Test");
            stateUser = false;
            if (Application.Current.Resources.ContainsKey("connected"))
            {
                connected = (bool)Application.Current.Resources["connected"];
            }
            else
            {
                connected = false;
                inputName.Visibility = Visibility.Visible;
                inputMdp.Visibility = Visibility.Visible;
                btnValidation.Visibility = Visibility.Visible;
                gridMain.Visibility = Visibility.Collapsed;
            }
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            inputName.Visibility = Visibility.Collapsed;
            inputMdp.Visibility = Visibility.Collapsed;
            btnValidation.Visibility = Visibility.Collapsed;
            gridMain.Visibility = Visibility.Visible;
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
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueCompte));
        }

        private void BtnDeco_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VueAjouterQuestion));
        }
    }
}
