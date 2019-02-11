using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class ImagesManager
    {
        internal static Images Load(int id)
        {
            Images img = new Images();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Image WHERE img_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(img, dr);
                        }
                    }
                }
            }

            return img;
        }

        internal static Images Save(Images image)
        {
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "INSERT INTO Image VALUES (@id, @url)";
                if (image.Id != 0)
                {
                    sql = "UPDATE Image SET img_url = @url WHERE img_id = @id";
                }

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", image.Id));
                    cmd.Parameters.Add(new MySqlParameter("@url", image.Url));

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(image, dr);
                        }
                    }
                }
            }

            return image;
        }

        private static void fill(Images item, MySqlDataReader dr)
        {
            item.Id = (int)dr["img_id"];
            item.Url = (string)dr["img_url"];
        }
    }
}
