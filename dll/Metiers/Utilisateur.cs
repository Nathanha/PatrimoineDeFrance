using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private NiveauIds niveau;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public NiveauIds Niveau { get => niveau; set => niveau = value; }

        public static Utilisateur Load(int id)
        {
            return UtilisateurManager.Load(id);
        }
    }
}
