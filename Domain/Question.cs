using System.Collections.Generic;

namespace Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<Alternative> Alternatives { get; set; }
        public ICollection<HistoricAnswerQuiz> Historics { get; set; }

        public Question()
        {
            Historics = new List<HistoricAnswerQuiz>();
            Alternatives = new List<Alternative>();
        }
    }
}