
using Xunit;
using Moq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using HackerNewsAPI.Models;
using HackerNewsAPI.Services;
using Castle.Components.DictionaryAdapter.Xml;

namespace HackerNewsAPI.Tests
{
    public class GetBestNewsStoriesRequestHandlerTests
    {
        [Fact]
        public async Task Test_ReturnsStoriesHandler_Successfully()
        {
            // Arrange
            var hackerNewsServiceMock = new Mock<HackerNewsService>();
            hackerNewsServiceMock.Setup(service => service.GetBestStoriesAsync(It.IsAny<int>()))
                                 .ReturnsAsync(new List<IStory>
                                 {
                                     new Story { Title = "HackerNews Test Story 1" },
                                     new Story { Title = "HackerNews Test Story 2" }
                                 });

            var handler = new GetBestNewsStoriesRequestHandler(hackerNewsServiceMock.Object);
            var request = new GetBestNewsStoriesRequest(2);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<IStory>>(result);
            Assert.Collection(result,
                story => Assert.Equal("HackerNews Test Story 1", story.Title),
                story => Assert.Equal("HackerNews Test Story 2", story.Title));
        }
    }
}
