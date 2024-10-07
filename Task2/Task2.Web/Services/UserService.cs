using Microsoft.JSInterop;
using System.Net.Http.Json;
using Task2.Web.Models;
using Task2.Web.StateProvider;

namespace Task2.Web.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly CustomStateProvider _customStateProvider;

        public UserService(HttpClient httpClient, IJSRuntime jsRuntime, CustomStateProvider customStateProvider)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _customStateProvider = customStateProvider;
        }

        public async Task<List<TodoUsers>> GetUsers()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TodoUsers>>("api/users/get");
            return response;
        }

    }

}
