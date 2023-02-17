using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;
using MetaPhoto.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace MetaPhotoTests
{
    public class PhotoServiceTests
    {
        private readonly string _uri = "mock.com/photos";
        private readonly PhotoService _sut;
        private readonly Mock<IApiClient<Photo>> _photoApiClientMock = new Mock<IApiClient<Photo>>();
        private readonly Mock<IService<Album>> _albumServiceMock = new Mock<IService<Album>>();
        private readonly Mock<IService<User>> _userServiceMock = new Mock<IService<User>>();
        private readonly IConfiguration _configurationMock = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>() { { "apiRoot", "mock.com" } })
            .Build();

        private List<Photo> _photos = new List<Photo>()
        {
            new Photo() { Id = 1, AlbumId = 1 },
            new Photo() { Id = 2, AlbumId = 1 },
            new Photo() { Id = 3, AlbumId = 2 },
            new Photo() { Id = 4, AlbumId = 2 },
            new Photo() { Id = 5, AlbumId= 3 },
        };

        private List<Album> _albums = new List<Album>()
        {
            new Album() { Id = 1, UserId = 1 },
            new Album() { Id = 2, UserId = 1 },
            new Album() { Id = 3, UserId = 2 }
        };

        private List<User> _users = new List<User>()
        {
            new User() { Id = 1 },
            new User() { Id = 2}
        };

        public PhotoServiceTests()
        {
            _sut = new PhotoService(_photoApiClientMock.Object, _albumServiceMock.Object, _userServiceMock.Object, _configurationMock);
        }

        [Fact]
        public void ShouldReturnAPhoto()
        {
            // Arrange
            _photoApiClientMock
                .Setup(x => x.Get(_uri, 1))
                .ReturnsAsync(_photos.First());

            _albumServiceMock
                .Setup(x => x.Get(1))
                .Returns(_albums.First());

            _userServiceMock
                .Setup(x => x.Get(1))
                .Returns(_users.First());

            // Act
            var photo = _sut.Get(1);

            // Assert
            Assert.IsType<Photo>(photo);
            Assert.Equal(1, photo.Id);
            Assert.NotNull(photo.Album);
            Assert.Equal(1, photo.Album!.Id);
            Assert.NotNull(photo.Album!.User);
            Assert.Equal(1, photo.Album!.User!.Id);
        }

        [Fact]
        public async void ShouldReturnListOfPhotos()
        {
            // Arrange
            _photoApiClientMock
                .Setup(x => x.GetAll(_uri))
                .ReturnsAsync(_photos);

            _albumServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(_albums);

            _userServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(_users);

            //Act
            var photos = await _sut.GetAll();

            //Assert
            Assert.IsType<List<Photo>>(photos);
            Assert.Equal(5, photos.Count);
            Assert.Equal(1, photos.First().Id);
            Assert.NotNull(photos.First().Album);
            Assert.Equal(1, photos.First().Album!.Id);
            Assert.NotNull(photos.First().Album!.User);
            Assert.Equal(1, photos.First().Album!.User!.Id);
        }
    }
}