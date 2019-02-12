using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public enum NiveauIds
    {
        Niveau1 = 1,
        Niveau2 = 2,
        Niveau3 = 3,
        Niveau4 = 4,
        Niveau5 = 5
    }

    public class Niveau
    {
        private NiveauIds id;
        private string label;

        public string Label { get => label; set => label = value; }
        public NiveauIds Id { get => id; set => id = value; }

        public NiveauIds NiveauIds
        {
            get => default(NiveauIds);
            set
            {
            }
        }

        public static List<Niveau> ListNiveau()
        {
            return NiveauManager.ListNiveau();
        }
    }
}
