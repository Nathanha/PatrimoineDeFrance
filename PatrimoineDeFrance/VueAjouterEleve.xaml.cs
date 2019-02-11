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
using dll;
using System.Diagnostics;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PatrimoineDeFrance
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class VueAjouterEleve : Page
    {
        private Utilisateur utilisateur;

        public VueAjouterEleve()
        {
            this.InitializeComponent();
            if (Application.Current.Resources.ContainsKey("eleve"))
            {
                utilisateur = (Utilisateur)Application.Current.Resources["eleve"];
                btnEnregistrerEleve.Content = "Modifier";
                nomInput.Text = utilisateur.Nom;
                prenomInput.Text = utilisateur.Prenom;
                mdpInput.Text = utilisateur.MotDePasse;
                classeInput.Text = utilisateur.Classe.ToString();
            } else
            {
                btnEnregistrerEleve.Content = "Enregistrer";
            }
        }

        private void BtnEnregistrerEleve_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ENREGISTRER");
            if (btnEnregistrerEleve.Content.ToString() == "Modifier")
            {
                //modifier eleve en bdd
                utilisateur.Nom = nomInput.Text;
                utilisateur.Prenom = prenomInput.Text;
                utilisateur.MotDePasse = mdpInput.Text;
                utilisateur.Classe = Convert.ToInt32(classeInput.Text);
                utilisateur.Save();
                Utils.ShowDialog("Insertion", "Utilisateur modifié");
            }
            else
            {
                //ajouter eleve en bdd
                utilisateur = new Utilisateur();
                utilisateur.MotDePasse = mdpInput.Text;
                utilisateur.NiveauId = 1;
                utilisateur.Role = 0;
                utilisateur.Nom = nomInput.Text;
                utilisateur.Prenom = prenomInput.Text;
                utilisateur.Classe = Convert.ToInt32(classeInput.Text);
                utilisateur.Save();

                Utils.ShowDialog("Insertion", "Utilisateur inséré");
            }
        }
    }
}
