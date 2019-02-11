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
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class VueAjouterCours : Page
    {
        private Cours cours;
        private Images image;

        public VueAjouterCours()
        {
            this.InitializeComponent();
            if (Application.Current.Resources.ContainsKey("cours"))
            {
                cours = (Cours)Application.Current.Resources["cours"];
                image = Images.Load(cours.ImageId);
                btnAjouterCours.Content = "Modifier";
                txtInput.Text = cours.Texte;
                titreInput.Text = cours.Titre;
                urlInput.Text = image.Url;
            }
        }

        public Images Images
        {
            get => default(Images);
            set
            {
            }
        }

        private void BtnAjouterCours_Click(object sender, RoutedEventArgs e)
        {
            if (btnAjouterCours.Content.ToString() == "Modifier")
            {
                //modifier cours en bdd
            }
            else
            {
                //ajouter cours en bdd
            }
        }
    }
}
