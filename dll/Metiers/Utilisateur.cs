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
        private string motdepasse;
        private NiveauIds niveau;
        private int niveauId;
        private int classe;
        private int role;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string MotDePasse { get => motdepasse; set => motdepasse = value; }
        public NiveauIds Niveau { get => niveau; set => niveau = value; }
        public int NiveauId { get => niveauId; set => niveauId = value; }
        public int Classe { get => classe; set => classe = value; }
        public int Role { get => role; set => role = value; }

        public static Utilisateur Load(int id)
        {
            return UtilisateurManager.Load(id);
        }

        public static List<Utilisateur> ListClasse(int classe)
        {
            return UtilisateurManager.ListClasse(classe);
        }

        public static Utilisateur GetUser(string nom)
        {
            return UtilisateurManager.GetUser(nom);
        }

        public static void Delete(int id)
        {
            UtilisateurManager.Delete(id);
        }
    }
}
