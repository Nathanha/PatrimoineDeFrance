using System;
using System.Collections.Generic;
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
using dll.Metiers;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatrimoineDeFrance
{
    public sealed partial class VueAjouterQuestion : Page
    {
        private Question question;
        private Images images;
        private Reponse reponse;

        public VueAjouterQuestion()
        {
            this.InitializeComponent();
            if (Application.Current.Resources.ContainsKey("question"))
            {
                question = (Question)Application.Current.Resources["question"];
                reponse = Reponse.Load(question.BonneReponseId);
                images = Images.Load(question.ImageId);
                btnEnregistrerQuestion.Content = "Modifier";
                questionInput.Text = question.Label;
                reponseBonneInput.Text = reponse.Label;
                urlInput.Text = images.Url;
            }
        }

        public Images Images
        {
            get => default(Images);
            set
            {
            }
        }

        private void BtnEnregistrerQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (btnEnregistrerQuestion.Content.ToString() == "Modifier")
            {
                //modifier question en bdd
            }
            else
            {
                //ajouter question en bdd
            }
        }
    }
}
