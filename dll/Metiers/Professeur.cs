using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    class Professeur
    {
        private int id;
        private string nom;
        private string prenom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public static Professeur Load(int id)
        {
            return ProfesseurManager.Load(id);
        }
    }
}
