namespace Domain
{
    public class HistoricAnswerQuiz
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public bool Right { get; set; }

    }
}