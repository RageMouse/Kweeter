namespace TweetAPI.Model
{
    public class Tweet
    {
        public Tweet(int id, string title, DateTime createdDate, string message, bool isDeleted, int userId)
        {
            Id = id;
            Title = title;
            CreatedDate = createdDate;
            Message = message;
            IsDeleted = isDeleted;
            UserId = userId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int UserId { get; set; } = 1;
    }
}
