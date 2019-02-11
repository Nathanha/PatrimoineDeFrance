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

        internal static void Delete(int id)
        {
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM Utilisateur WHERE u_id = @id";
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

        internal static Utilisateur Save(Utilisateur utilisateur)
        {
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "INSERT INTO Utilisateur VALUES (@id, @nom, @prenom, @mdp, @niveau, @classe, @role)";
                if(utilisateur.Id != 0)
                {
                    sql = "UPDATE Utilisateur SET u_nom = @nom, u_prenom = @prenom, u_motDePasse = @mdp, u_niveau = @niveau, u_classe = @classe, u_role = @role WHERE u_id = @id";
                }
                
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", utilisateur.Id));
                    cmd.Parameters.Add(new MySqlParameter("@nom", utilisateur.Nom));
                    cmd.Parameters.Add(new MySqlParameter("@prenom", utilisateur.Prenom));
                    cmd.Parameters.Add(new MySqlParameter("@mdp", utilisateur.MotDePasse));
                    cmd.Parameters.Add(new MySqlParameter("@niveau", utilisateur.NiveauId));
                    cmd.Parameters.Add(new MySqlParameter("@classe", utilisateur.Classe));
                    cmd.Parameters.Add(new MySqlParameter("@role", utilisateur.Role));

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
            item.Role = (int)dr["u_role"];
        }

    }
}
