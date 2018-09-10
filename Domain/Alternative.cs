namespace Domain
{
    public class Alternative
    {
        public int Id { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public bool Right { get; set; }
        public int StudentCount { get; set; }
    }
}