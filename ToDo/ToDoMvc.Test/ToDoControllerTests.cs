using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ToDoMvc;
using ToDoMvc.Models;

namespace ToDoMvc.IntegrationTests
{
    public class ToDoControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        
        /**
         * Nice idea but not working?
         */
        /*
        private readonly HttpClient _client;

        public ToDoControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithListOfToDos()
        {
            var response = await _client.GetAsync("/api/todo");
            response.EnsureSuccessStatusCode();

            var todos = await response.Content.ReadFromJsonAsync<Models.ToDo[]>();
            Assert.NotNull(todos);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/todo/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var todo = await response.Content.ReadFromJsonAsync<Models.ToDo>();
            Assert.NotNull(todo);
            Assert.Equal(1, todo.Id);
        }

        [Fact]
        public async Task Create_ValidToDo_ReturnsCreated()
        {
            var newTodo = new Models.ToDo { Id = 99, ToDoName = "New Task", ToDoDescription = "Desc", IsComplete = false, DateCompleted = DateTime.Now.AddDays(7) };
            var response = await _client.PostAsJsonAsync("/api/todo", newTodo);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var createdTodo = await response.Content.ReadFromJsonAsync<Models.ToDo>();
            Assert.NotNull(createdTodo);
            Assert.Equal("New Task", createdTodo.ToDoName);
            Assert.Equal("Desc", createdTodo.ToDoDescription);
            Assert.False(createdTodo.IsComplete);
            Assert.True(createdTodo.DateCompleted > DateTime.Now);

        }

        [Fact]
        public async Task Update_ExistingId_ReturnsNoContent()
        {
            var updatedTodo = new Models.ToDo { Id = 1, ToDoName = "Updated Task" };
            var response = await _client.PutAsJsonAsync("/api/todo/1", updatedTodo);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsNoContent()
        {
            var response = await _client.DeleteAsync("/api/todo/1");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
    */
    }
}