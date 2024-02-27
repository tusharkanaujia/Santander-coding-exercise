// HackerNewsService.cs

using HackerNewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackerNewsAPI.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://hacker-news.firebaseio.com/v0/";

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<IEnumerable<IStory>> GetBestStoriesAsync(int n)
        {
            var bestStoryIds = await GetBestStoryIdsAsync();
            var stories = new List<Story>();

            for (int i = 0; i < Math.Min(n, bestStoryIds.Length); i++)
            {
                var story = await GetStoryByIdAsync(bestStoryIds[i]);
                if (story != null)
                {
                    stories.Add(story);
                }
            }

            return stories;
        }

        private async Task<int[]> GetBestStoryIdsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/beststories.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int[]>(content);
        }

        private async Task<Story> GetStoryByIdAsync(int storyId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/item/{storyId}.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Story>(content);
        }
    }
}


