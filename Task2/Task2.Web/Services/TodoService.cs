using Microsoft.JSInterop;
using System.Net.Http.Json;
using Task2.Web.Models;
using Task2.Web.StateProvider;

namespace Task2.Web.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly CustomStateProvider _customStateProvider;

        public TodoService(HttpClient httpClient, IJSRuntime jsRuntime, CustomStateProvider customStateProvider)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _customStateProvider = customStateProvider;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TodoItem>>("api/todo/get");
            return response;
        }

        public async Task AddToDoItem(string description)
        {
            TodoItem todoItem = new TodoItem(){ Description = description };
            var response = await _httpClient.PostAsJsonAsync("api/todo/add", new { todoItem.Id, todoItem.Description, todoItem.IsCompleted });
        }

        public async Task EditToDoItem(int id, string description, bool isCompleted)
        {
            var response = await _httpClient.PutAsJsonAsync("api/todo/edit", new { id, description, isCompleted });
        }

        public async Task DeleteToDoItem(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/todo/delete/{id}");
        }

    }

}
