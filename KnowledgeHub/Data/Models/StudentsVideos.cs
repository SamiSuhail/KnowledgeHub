namespace KnowledgeHub.Data.Models
{
    public class StudentsVideos
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}
