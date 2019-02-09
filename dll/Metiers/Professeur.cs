using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Professeur
    {
        private int id;
        private string nom;
        private string prenom;
        private int classe;
        private string motdepasse;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Classe { get => classe; set => classe = value; }
        public string MotDePasse { get => motdepasse; set => motdepasse = value; }

        public static Professeur Load(int id)
        {
            return ProfesseurManager.Load(id);
        }

        public static Professeur GetProfesseur(string nom)
        {
            return ProfesseurManager.GetProfesseur(nom);
        }
    }
}
