using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class UserService : IService<User>
    {
        private readonly IApiClient<User> _apiClient;
        private readonly string _uri;

        public UserService(IApiClient<User> apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _uri = $"{configuration.GetValue<string>("apiRoot")}/users";
        }

        public User Get(int id)
        {
            return _apiClient.Get(_uri, id).Result;
        }

        public async Task<List<User>> GetAll()
        {
            return await _apiClient.GetAll(_uri);
        }
    }
}
