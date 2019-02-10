using dll.Metiers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Metiers
{
    public class Question
    {
        private int id;
        private string label;
        private NiveauIds niveau;
        private int bonneReponseId;
        private int imageId;

        public Question() { }

        public Question(int id, string label, NiveauIds niveau, int bonneReponseId, int imageId)
        {
            this.id = id;
            this.label = label;
            this.niveau = niveau;
            this.bonneReponseId = bonneReponseId;
            this.imageId = imageId;
        }

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public NiveauIds Niveau { get => niveau; set => niveau = value; }
        public int BonneReponseId { get => bonneReponseId; set => bonneReponseId = value; }
        public int ImageId { get => imageId; set => imageId = value; }

        public static Question Load(int id)
        {
            return QuestionManager.Load(id);
        }

        public static List<Question> ListQuestions()
        {
            return QuestionManager.ListQuestions();
        }

        public static List<Question> ListQuestions(NiveauIds niveau)
        {
            return QuestionManager.ListQuestions(niveau);
        }

        public static void DeleteQuestion(int id)
        {
            QuestionManager.DeleteQuestion(id);
        }
    }
}
