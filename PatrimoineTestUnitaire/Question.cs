using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class QuizzTest
    {

        string connStr = Utils.GetConn;
        private int idTest;
        [TestMethod]
        public void Load_Question()
        {
            Question quizz = new Question();
            idTest = 1;
            Question uneQuestion = new Question();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Question WHERE q_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            uneQuestion.Id = (int)dr["q_id"];
                            uneQuestion.Label = (string)dr["q_texte"];
                            uneQuestion.Niveau = (NiveauIds)dr["q_niveau"];
                            uneQuestion.BonneReponseId = (int)dr["q_reponseId"];
                            uneQuestion.ImageId = (int)dr["q_imageId"];
                        }
                    }
                }

            }
            Assert.AreEqual(uneQuestion.Id, 1);
            Assert.AreEqual(uneQuestion.ImageId, 1);
            Trace.WriteLine("id: " + uneQuestion.Id + " Niveau: " + uneQuestion.Niveau + " bonnerep.: " + uneQuestion.BonneReponseId + "ImageId: " + uneQuestion.ImageId);
        }

    }

}
