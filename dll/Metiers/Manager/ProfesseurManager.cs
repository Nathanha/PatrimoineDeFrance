using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
   internal static class ProfesseurManager
    {
        internal static Professeur Load(int id)
        {
            Professeur professeur = new Professeur();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Professeur WHERE id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(professeur, dr);
                        }
                    }
                }
            }

            return professeur;
        }

        internal static Professeur GetProfesseur(string nom)
        {
            Professeur professeur = new Professeur();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Professeur WHERE nom = @nom";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@nom", nom));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(professeur, dr);
                        }
                    }
                }
            }

            return professeur;
        }

        internal static void fill(Professeur item, MySqlDataReader dr)
        {
            item.Id = (int)dr["id"];
            item.Nom = (string)dr["nom"];
            item.Prenom = (string)dr["prenom"];
            item.Classe = (int)dr["classe"];
            item.MotDePasse = (string)dr["motDePasse"];
        }
    }
}
