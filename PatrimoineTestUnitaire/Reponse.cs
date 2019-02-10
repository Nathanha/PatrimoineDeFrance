using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class ReponseTest
    {

        string connStr = Utils.GetConn;
        private int idTest;
        [TestMethod]
        public void Load_Reponse()
        {

            idTest = 1;
            Reponse reponse = new Reponse();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Reponse WHERE r_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            reponse.Id = (int)dr["r_id"];
                            reponse.Label = (string)dr["r_texte"];
                        }
                    }
                }

            }
            Assert.AreEqual(reponse.Id, 1);
            Assert.AreEqual(reponse.Label, "300");
            Trace.WriteLine("id: " + reponse.Id + " URL: " + reponse.Label);
        }

    }

}