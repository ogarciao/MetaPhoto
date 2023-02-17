using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class ApiClient<T> : IApiClient<T>
    {
        public async Task<T> Get(string uri, int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{uri}/{id}");
            response.EnsureSuccessStatusCode();
            return HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content).Result;
        }

        public async Task<List<T>> GetAll(string uri)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return HttpContentJsonExtensions.ReadFromJsonAsync<List<T>>(response.Content).Result;
        }
    }
}
