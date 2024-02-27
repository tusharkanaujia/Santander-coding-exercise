// HackerNewsService.cs

using HackerNewsAPI.Models;

namespace HackerNewsAPI.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<IStory>> GetBestStoriesAsync(int n);
    }
}