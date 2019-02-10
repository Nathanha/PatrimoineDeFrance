using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Cours
    {
        private int id;
        private string titre;
        private string texte;
        private int imageId;

        public Cours() { }

        public int Id { get => id; set => id = value; }
        public string Texte { get => texte; set => texte = value; }
        public int ImageId { get => imageId; set => imageId = value; }
        public string Titre { get => titre; set => titre = value; }

        public static List<Cours> ListCours()
        {
            return CoursManager.ListCours();
        }

        public static void DeleteCours(int id)
        {
            CoursManager.DeleteCours(id);
        }
    }
}
