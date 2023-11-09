using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations
{
    public class UserHttpClient : IUserService
    {
        private readonly HttpClient client;

        public UserHttpClient(HttpClient client)
        {
            this.client = client;
            // this.client.BaseAddress = new Uri("https://localhost:7107");
        }

        public async Task<User> Create(UserCreationDto dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            User user = JsonSerializer.Deserialize<User>(result)!;
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers(string? usernameContains = null, string? passwordContains = null)
        {
            string uri = "/users";
            if (!string.IsNullOrEmpty(usernameContains))
            {
                uri += $"?userName={usernameContains}";
            }
            if (!string.IsNullOrEmpty(passwordContains))
            {
                uri += $"&password={passwordContains}";
            }

            HttpResponseMessage response = await client.GetAsync(uri);

            // Log the response content for debugging
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {result}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to retrieve users. Status code: {response.StatusCode}. Error: {result}");
            }

            IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return users;
        }
    }
}
