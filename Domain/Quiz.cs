using System.Collections.Generic;

namespace Domain
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
        }
    }
}