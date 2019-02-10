using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using dll;

namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class ImageTest
    {

        string connStr = Utils.GetConn;
        private int idTest;
        private int imageTableId;
        [TestMethod]
        public void Load_Image()
        {
           
            idTest = 1;
            Images image = new Images();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Image WHERE img_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", idTest));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            image.Id = (int)dr["img_id"];
                            image.Url = (string)dr["img_url"];
                        }
                    }
                }

            }
            Assert.AreEqual(image.Id, 1);
            Assert.AreEqual(image.Url, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Tour_eiffel_juin_2017.jpg/220px-Tour_eiffel_juin_2017.jpg");
            Trace.WriteLine("id: " + image.Id + " URL: " + image.Url);
        }

    }

}