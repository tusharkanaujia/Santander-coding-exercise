// Story.cs


namespace HackerNewsAPI.Models
{
    public interface IStory
    {
        int CommentCount { get; set; }
        string PostedBy { get; set; }
        int Score { get; set; }
        DateTimeOffset Time { get; set; }
        string Title { get; set; }
        string Uri { get; set; }
    }
}