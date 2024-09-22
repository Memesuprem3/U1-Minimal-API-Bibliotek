using API_Bibliotek.Models.DTOs;
using API_Bibliotek.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Bibliotek_Web.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(StaticDetails.BibliotekAPiBase); // Använd statisk bas-URL
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var response = await _httpClient.GetAsync("/api/books");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<APIResponse>(jsonData);
                return JsonConvert.DeserializeObject<List<BookDTO>>(apiResponse.Result.ToString());
            }
            return new List<BookDTO>();
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<APIResponse>(jsonData);
                return JsonConvert.DeserializeObject<BookDTO>(apiResponse.Result.ToString());
            }
            return null;
        }

        public async Task<bool> CreateBookAsync(CreateBookDTO bookDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/book", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBookAsync(UpdateBookDTO bookDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/book", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/book/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}