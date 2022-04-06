namespace TweetAPI.Model
{
    public class Tweet
    {
        public Tweet(int id, string title, string message)
        {
            Id = id;
            Title = title;
            Message = message;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
    }
}
