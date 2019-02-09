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


        internal static List<Utilisateur> ListClasse(int numero)
        {
            List<Utilisateur> laClasse = new List<Utilisateur>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_classe = @numero";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@numero", numero));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Utilisateur unEleve = new Utilisateur();
                            fill(unEleve, dr);
                            laClasse.Add(unEleve);
                        }
                    }
                }

            }
            return laClasse;
        }

        internal static Utilisateur GetUser(string nom)
        {
            Utilisateur utilisateur = new Utilisateur();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_nom = @nom";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@nom", nom));
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
            item.NiveauId = (int)dr["u_niveau"];
            item.Nom = (string)dr["u_nom"];
            item.Prenom = (string)dr["u_prenom"];
            item.MotDePasse = (string)dr["u_motDePasse"];
        }

    }
}
