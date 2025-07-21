using Microsoft.AspNetCore.Mvc;
using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcMovie.Tests;

public class MvcMovieControllerTest
{
    /* NOT WORKING
    [Fact]
    public async Task Create_RedirectsToIndex_OnSuccess()
    {
        // Arrange
        var mockContext = new Mock<MvcMovieContext>();
        var mockLogger = new Mock<ILogger<MoviesController>>();
        var controller = new MoviesController(mockContext.Object, mockLogger.Object);
        var newMovie = new Movie { Id = 1, Title = "New Movie" };

        // Act
        var result = await controller.Create(newMovie);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        mockContext.Verify(c => c.Add(It.IsAny<Movie>()), Times.Once);
        mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task Create_ReturnsViewResult_WhenModelStateIsInvalid()
    {
        // Arrange
        var mockContext = new Mock<MvcMovieContext>();
        var mockLogger = new Mock<ILogger<MoviesController>>();
        var controller = new MoviesController(mockContext.Object, mockLogger.Object);
        controller.ModelState.AddModelError("Title", "Required");
        var newMovie = new Movie { Id = 1 };

        // Act
        var result = await controller.Create(newMovie);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(newMovie, viewResult.Model);
        mockContext.Verify(c => c.Add(It.IsAny<Movie>()), Times.Never);
        mockContext.Verify(c => c.SaveChangesAsync(default), Times.Never);
    }
    
    [Fact]
    public async Task Details_ReturnsViewResult_WithMovie()
    {
        // Arrange
        var mockContext = new Mock<MvcMovieContext>();
        mockContext.Setup(c => c.Movie.FindAsync(1))
            .ReturnsAsync(new Movie { Id = 1, Title = "Movie 1" });
        var mockLogger = new Mock<ILogger<MoviesController>>();
        var controller = new MoviesController(mockContext.Object, mockLogger.Object);
    
        // Act
        var result = await controller.Details(1);
    
        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<Movie>(viewResult.Model);
        Assert.Equal(1, model.Id);
    }
    
    [Fact]
    public async Task Details_ReturnsNotFound_WhenMovieDoesNotExist()
    {
        // Arrange
        var mockContext = new Mock<MvcMovieContext>();
        mockContext.Setup(c => c.Movie.FindAsync(1)).ReturnsAsync((Movie)null);
        var mockLogger = new Mock<ILogger<MoviesController>>();
        var controller = new MoviesController(mockContext.Object, mockLogger.Object);
    
        // Act
        var result = await controller.Details(1);
    
        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
 */   
}