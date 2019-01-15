using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Images
    {
        private int id;
        private string url;

        public string Url { get => url; set => url = value; }
        public int Id { get => id; set => id = value; }

        public static Images Load(int id)
        {
            return ImagesManager.Load(id);
        }
    }
}
