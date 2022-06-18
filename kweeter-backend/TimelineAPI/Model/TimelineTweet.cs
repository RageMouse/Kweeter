using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineAPI.Model
{
    public class TimelineTweet
    {
        public TimelineTweet(string message)
        {
            Message = message;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
