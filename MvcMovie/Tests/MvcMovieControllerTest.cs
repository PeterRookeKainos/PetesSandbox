using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


// these here tests don't work, but don't stop the app from running.
// TODO - fix the tests to work with the current codebase!
namespace MvcMovie.Tests
{
    public class MoviesControllerTests
    {
       
        [Fact]
        public async Task Details_ReturnsViewResult_WithMovie()
        {
            var mockContext = new Mock<MvcMovieContext>();
            mockContext.Setup(c => c.Movie.FindAsync(1))
                .ReturnsAsync(new Movie { Id = 1, Title = "Movie 1", ReleaseDate = new DateTime(2020, 1, 1), Genre = "Drama", Price = 9.99M });
            var mockLogger = new Mock<ILogger<MoviesController>>();
            var mockIOptions = new Mock<IOptions<AppOptions>>();
            var controller = new MoviesController(mockContext.Object, mockLogger.Object, mockIOptions.Object);

            var result = await controller.Details(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndex_OnSuccess()
        {
            var mockContext = new Mock<MvcMovieContext>();
            var mockLogger = new Mock<ILogger<MoviesController>>();
            var mockIOptions = new Mock<IOptions<AppOptions>>();
            
            var controller = new MoviesController(mockContext.Object, mockLogger.Object, null);
            var newMovie = new Movie { Id = 1, Title = "New Movie" };

            var result = await controller.Create(newMovie);

            Assert.IsType<RedirectToActionResult>(result);
            mockContext.Verify(c => c.Add(It.IsAny<Movie>()), Times.Once);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenIdMismatch()
        {
            var mockContext = new Mock<MvcMovieContext>();
            var mockLogger = new Mock<ILogger<MoviesController>>();
            var controller = new MoviesController(mockContext.Object, mockLogger.Object, null);
            var movie = new Movie { Id = 2, Title = "Movie 2" };

            var result = await controller.Edit(1, movie);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteConfirmed_RemovesMovie_AndRedirects()
        {
            var mockContext = new Mock<MvcMovieContext>();
            var mockLogger = new Mock<ILogger<MoviesController>>();
            var controller = new MoviesController(mockContext.Object, mockLogger.Object, null);

            var result = await controller.DeleteConfirmed(1);

            Assert.IsType<RedirectToActionResult>(result);
            mockContext.Verify(c => c.Remove(It.IsAny<Movie>()), Times.Once);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}