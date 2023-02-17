using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class PhotoService : IService<Photo>
    {
        private readonly IApiClient<Photo> _apiClient;
        private readonly IService<Album> _albumService;
        private readonly IService<User> _userService;
        private readonly string _uri;

        public PhotoService(IApiClient<Photo> apiClient, IService<Album> albumService, IService<User> userService, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _albumService = albumService;
            _userService = userService;
            _uri = $"{configuration.GetValue<string>("apiRoot")}/photos";
        }

        public Photo Get(int id)
        {
            Photo photo = _apiClient.Get(_uri, id).Result;
            Album album = _albumService.Get(photo.AlbumId);
            User user = _userService.Get(album.UserId);

            album.User = user;
            photo.Album = album;

            return photo;
        }

        public async Task<List<Photo>> GetAll()
        {
            Task<List<Photo>> photosTask = _apiClient.GetAll(_uri);
            Task<List<Album>> albumsTask = _albumService.GetAll();
            Task<List<User>> usersTask = _userService.GetAll();

            List<Photo> photos = await photosTask;

            List<Album> albums = await albumsTask;
            List<User> users = await usersTask;

            foreach (var album in albums)
            {
                album.User = users.SingleOrDefault(u => u.Id == album.UserId);
            }

            foreach (var photo in photos)
            {
                photo.Album = albums.SingleOrDefault(a => a.Id == photo.AlbumId);
            }

            return photos;
        }
    }
}
