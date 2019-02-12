using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class NiveauManager
    {
        public Niveau Niveau
        {
            get => default(Niveau);
            set
            {
            }
        }

        internal static List<Niveau> ListNiveau()
        {
            List<Niveau> listNiveau = new List<Niveau>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Niveau";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Niveau niveau = new Niveau();
                            fill(niveau, dr);
                            listNiveau.Add(niveau);
                        }
                    }
                }
            }

            return listNiveau;
        }

        private static void fill(Niveau item, MySqlDataReader dr)
        {
            item.Id = (NiveauIds)dr["n_id"];
            item.Label = (string)dr["n_label"];
        }
    }
}
