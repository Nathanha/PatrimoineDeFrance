using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class PrfesseurTest
    {

        string connStr = Utils.GetConn;
        private int idTest;
        private int imageTableId;
        [TestMethod]
        public void Load_Image()
        {

            idTest = 1;
            Professeur professeur = new Professeur();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Professeur WHERE id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            professeur.Id = (int)dr["id"];
                            professeur.Nom = (string)dr["nom"];
                            professeur.Prenom = (string)dr["prenom"];
                            professeur.Classe = (int)dr["classe"];
                            professeur.MotDePasse = (string)dr["motDePasse"];
                        }
                    }
                }
            }

          
            Assert.AreEqual(professeur.Id, idTest);
            Assert.AreEqual(professeur.Nom, "Venezia");
            Assert.AreEqual(professeur.Prenom, "Matthieu");
            Assert.AreEqual(professeur.Classe, 1);
            Assert.AreEqual(professeur.MotDePasse, "1234");
            Trace.WriteLine("id: " + professeur.Id + " Nom: " + professeur.Nom + " Prenom: " + professeur.Prenom + " Classe: " + professeur.Classe + " MotDePasse: " + professeur.MotDePasse);
        }

    }

}