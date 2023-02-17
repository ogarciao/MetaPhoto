using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class AlbumService : IService<Album>
    {
        private readonly IApiClient<Album> _apiClient;
        private readonly string _uri;

        public AlbumService(IApiClient<Album> apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _uri = $"{configuration.GetValue<string>("apiRoot")}/albums";
        }

        public Album Get(int id)
        {
            return _apiClient.Get(_uri, id).Result;
        }

        public async Task<List<Album>> GetAll()
        {
            return await _apiClient.GetAll(_uri);
        }
    }
}
