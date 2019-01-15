using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Reponse
    {
        private int id;
        private string label;

        public Reponse() { }

        public Reponse(int id, string label)
        {
            this.id = id;
            this.label = label;
        }

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }

        public static Reponse Load(int id)
        {
            return ReponseManager.Load(id);
        }

        public static List<Reponse> ListMauvaiseReponse(int id, NiveauIds niveau)
        {
            return ReponseManager.ListMauvaiseReponse(id, niveau);
        }
    }
}
