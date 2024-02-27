
using Xunit;
using Moq;
using HackerNewsAPI.Controllers;
using HackerNewsAPI.Models;
using HackerNewsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace HackerNewsAPI.Tests
{
    public class StoriesControllerTests
    {
        [Fact]
        public async Task GetBestStories_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(mediator => mediator.Send(It.IsAny<GetBestNewsStoriesRequest>(), default))
                        .ReturnsAsync(new List<Story>());

            var controller = new StoriesController(mediatorMock.Object);

            // Act
            var result = await controller.GetBestStories(5);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
