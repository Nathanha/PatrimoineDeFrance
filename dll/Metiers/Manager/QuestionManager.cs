using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers.Manager
{
    internal static class QuestionManager
    {

        internal static List<Question> ListQuestions()
        {
            List<Question> mesQuestions = new List<Question>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Question";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Question uneQuestion = new Question();
                            fill(uneQuestion, dr);
                            mesQuestions.Add(uneQuestion);
                        }
                    }
                }

            }
            return mesQuestions;
        }

        internal static List<Question> ListQuestions(NiveauIds niveau)
        {
            List<Question> mesQuestions = new List<Question>();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Question where q_niveau = @niveau";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@niveau", niveau));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Question uneQuestion = new Question();
                            fill(uneQuestion, dr);
                            mesQuestions.Add(uneQuestion);
                        }
                    }
                }

            }
            return mesQuestions;
        }

        internal static Question Load(int id)
        {
            Question uneQuestion = new Question();
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM Question WHERE q_id = @id";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            fill(uneQuestion, dr);
                        }
                    }
                }

            }
            return uneQuestion;
        }

        internal static void DeleteQuestion(int id)
        {
            string connStr = Utils.GetConn;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM Question WHERE q_id = @id";
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

        private static void fill(Question item, MySqlDataReader dr)
        {
            item.Id = (int)dr["q_id"];
            item.Label = (string)dr["q_texte"];
            item.Niveau = (NiveauIds)dr["q_niveau"];
            item.BonneReponseId = (int)dr["q_reponseId"];
            item.ImageId = (int)dr["q_imageId"];
        }
    }
}
