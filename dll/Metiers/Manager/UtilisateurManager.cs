using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class UtilisateurManager
    {
        internal static Utilisateur Load(int id)
        {
            Utilisateur utilisateur = new Utilisateur();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(utilisateur, dr);
                        }
                    }
                }
            }

            return utilisateur;
        }

        internal static void fill(Utilisateur item, MySqlDataReader dr)
        {
            item.Id = (int)dr["u_id"];
            item.Niveau = (NiveauIds)dr["u_niveau"];
            item.Nom = (string)dr["u_nom"];
        }
    }
}
