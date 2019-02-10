using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class CoursTest
    {

        private static string connStr = "server=137.74.114.61;user=PatrimoineProjet;database=PatrimoineProjet;port=3306;password=mny2018";
        private int idTest;
        [TestMethod]
        public void Load_Reponse()
        {
            string connStr = Utils.GetConn;
            idTest = 1;
            Cours cours = new Cours();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Cours WHERE c_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cours.Id = (int)dr["c_id"];
                            cours.Titre = (string)dr["c_titre"];
                            cours.Texte = (string)dr["c_texte"];
                            cours.ImageId = (int)dr["c_imageId"];
                        }
                    }
                }

            }
            Assert.AreEqual(cours.Id, 1);
            Assert.AreEqual(cours.ImageId, 4);
            Trace.WriteLine("id: " + cours.Id + " Titre: " + cours.Titre+" Text: "+cours.Texte+" Image id: "+cours.ImageId);
        }

    }

}