using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class CoursManager
    {
        internal static List<Cours> ListCours()
        {
            List<Cours> listCours = new List<Cours>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Cours";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cours unCours = new Cours();
                            fill(unCours, dr);
                            listCours.Add(unCours);
                        }
                    }
                }
            }
            return listCours;
        }

        internal static void DeleteCours(int id)
        {
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM Cours WHERE c_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {

                    }
                }
            }
        }

        private static void fill(Cours item, MySqlDataReader dr)
        {
            item.Id = (int)dr["c_id"];
            item.Titre = (string)dr["c_titre"];
            item.Texte = (string)dr["c_texte"];
            item.ImageId = (int)dr["c_imageId"];
        }
    }
}
