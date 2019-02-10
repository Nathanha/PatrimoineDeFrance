using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class UtilisateurTest
    {

        string connStr = Utils.GetConn; private bool isProfesseur = false;
        private int idTest;
        private string nomTest;
        [TestMethod]
        public void Load_Utilisateur()
        {
       
            Trace.WriteLine("Load_Utilisateur()");
            Utilisateur utilisateur = new Utilisateur();
            idTest = 1;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            utilisateur.Id = (int)dr["u_id"];
                            utilisateur.NiveauId = (int)dr["u_niveau"];
                            utilisateur.Nom = (string)dr["u_nom"];
                            utilisateur.Prenom = (string)dr["u_prenom"];
                            utilisateur.MotDePasse = (string)dr["u_motDePasse"];
                            utilisateur.Role = (int)dr["u_role"];

                        }
                    }
                }
            }
            Assert.AreEqual(utilisateur.Id, 1);
            Assert.AreEqual(utilisateur.Nom, "Varga");
            Assert.AreEqual(utilisateur.Prenom, "Mihaly");
            Trace.WriteLine("Nom: " + utilisateur.Nom + " Prenom: " + utilisateur.Prenom + " Id: " + utilisateur.Id);

        }

        [DataTestMethod]
        public void isProfesseurTest()
        {
            Trace.WriteLine("isProfesseurTest()");
            idTest = 1;
            Utilisateur utilisateur = new Utilisateur();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_id = @num";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@num",idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            utilisateur.Id = (int)dr["u_id"];
                            utilisateur.NiveauId = (int)dr["u_niveau"];
                            utilisateur.Nom = (string)dr["u_nom"];
                            utilisateur.Prenom = (string)dr["u_prenom"];
                            utilisateur.MotDePasse = (string)dr["u_motDePasse"];
                            utilisateur.Role = (int)dr["u_role"];

                        }
                    }
                }
            }
            if(utilisateur.Role == 1)
            {
                isProfesseur = true;
                Assert.IsTrue(isProfesseur, "This is a professeur");
                Trace.WriteLine("This is a prof. ==> Nom: "+utilisateur.Nom+" Prenom: "+utilisateur.Prenom + " Id: "+utilisateur.Id);            }
            else
            {
                Assert.IsFalse(isProfesseur, "This is NOT a prfosseur");
                Trace.WriteLine("This is NOT a prof. ==> Nom: " + utilisateur.Nom + " Prenom: " + utilisateur.Prenom + " Id: " + utilisateur.Id);
            }
        }

        [DataTestMethod]
        public void GetUserTest()
        {
            Trace.WriteLine("GetUserTest()");
            nomTest = "Varga";
            Utilisateur utilisateur = new Utilisateur();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Utilisateur WHERE u_nom = @nom";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@nom", nomTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            utilisateur.Id = (int)dr["u_id"];
                            utilisateur.NiveauId = (int)dr["u_niveau"];
                            utilisateur.Nom = (string)dr["u_nom"];
                            utilisateur.Prenom = (string)dr["u_prenom"];
                            utilisateur.MotDePasse = (string)dr["u_motDePasse"];
                            utilisateur.Role = (int)dr["u_role"];

                        }
                    }
                }
            }
                Assert.AreEqual(utilisateur.Nom, nomTest);
                Trace.WriteLine("utilisateur.Nom: " + utilisateur.Nom+ " nomTest: "+nomTest + " Prenom: " + utilisateur.Prenom + " Id: " + utilisateur.Id);
         
        }
    }
    
    
}
