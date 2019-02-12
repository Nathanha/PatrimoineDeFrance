using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class ReponseManager
    {
        public Reponse Reponse
        {
            get => default(Reponse);
            set
            {
            }
        }

        internal static Reponse Load(int id)
        {
            Reponse reponse = new Reponse();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Reponse WHERE r_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(reponse, dr);
                        }
                    }
                }

            }
            return reponse;
        }

        internal static List<Reponse> ListMauvaiseReponse(int id, NiveauIds niveau)
        {
            List<Reponse> listReponse = new List<Reponse>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Reponse WHERE r_id != @id and r_niveau = @niveau";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    cmd.Parameters.Add(new MySqlParameter("@niveau", niveau));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Reponse reponse = new Reponse();
                            fill(reponse, dr);
                            listReponse.Add(reponse);
                        }
                    }
                }

            }
            return listReponse;
        }


        private static void fill(Reponse item, MySqlDataReader dr)
        {
            item.Id = (int)dr["r_id"];
            item.Label = (string)dr["r_texte"];
        }
    }
}
