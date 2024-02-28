// Mediator pattern implementation

// Create a request class to represent the request for best stories
using HackerNewsAPI.Models;
using HackerNewsAPI.Services;
using MediatR;

public class GetBestNewsStoriesRequest : IRequest<IEnumerable<Story>>
{
    public int NumberOfStories { get; }

    public GetBestNewsStoriesRequest(int numberOfStories)
    {
        NumberOfStories = numberOfStories;
    }
}

// Create a handler for the request
public class GetBestNewsStoriesRequestHandler : IRequestHandler<GetBestNewsStoriesRequest, IEnumerable<IStory>>
{
    private readonly HackerNewsService _hackerNewsService;

    public GetBestNewsStoriesRequestHandler(HackerNewsService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService;
    }

    public async Task<IEnumerable<IStory>> Handle(GetBestNewsStoriesRequest request, CancellationToken cancellationToken)
    {
        return await _hackerNewsService.GetBestStoriesAsync(request.NumberOfStories);
    }
}
