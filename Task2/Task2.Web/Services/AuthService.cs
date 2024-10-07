using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Task2.Web.Models;
using Task2.Web.StateProvider;

namespace Task2.Web.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly CustomStateProvider _customStateProvider;

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, CustomStateProvider customStateProvider)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _customStateProvider = customStateProvider;
        }

        public async Task<RegisterResponse> RegisterAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account/register", new { email, password });
            RegisterResponse registerResponse = new RegisterResponse();
            if (response.IsSuccessStatusCode)
            {
                registerResponse.IsSucceeded = response.IsSuccessStatusCode;
                return registerResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorDetails = await HandleBadRequestResponse(response);

                registerResponse.IsSucceeded = response.IsSuccessStatusCode;
                registerResponse.Errors = errorDetails;
                return registerResponse;
            }
            return registerResponse;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account/login", new { email, password });
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                await _customStateProvider.MarkUserAsAuthenticated(result.Token);
                return true;
            }
            return response.IsSuccessStatusCode;
        }

        public async Task LogoutAsync()
        {
            await _customStateProvider.MarkUserAsLoggedOut();
        }

        public async Task<List<ErrorDetail>> HandleBadRequestResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var errors = JsonSerializer.Deserialize<List<ErrorDetail>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return errors;
            }
            return null;
        }
    }

}
