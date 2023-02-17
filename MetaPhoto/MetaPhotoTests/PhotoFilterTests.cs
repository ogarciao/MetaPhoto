using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;
using MetaPhoto.Services;
using Moq;

namespace MetaPhotoTests
{
    public class PhotoFilterTests
    {
        private readonly PhotoFilter _sut;

        private List<Photo> _photos = new List<Photo>()
        {
            new Photo() { Id = 1, Title = "Once upon a time", AlbumId = 1 },
            new Photo() { Id = 2, Title = "Foo", AlbumId = 1 },
            new Photo() { Id = 3, Title = "Bar", AlbumId = 2 },
            new Photo() { Id = 4, Title = "Bounces", AlbumId = 2 },
            new Photo() { Id = 5, Title = "I saw it once", AlbumId= 3 }
        };

        public PhotoFilterTests()
        {
            _sut = new PhotoFilter();
        }

        [Fact]
        public void ShouldReturnPhotosWithTitleOnce()
        {
            // Arrange
            ISpecification<Photo> specification = new PhotoTitleSpecification("once");

            // Act
            var photos = _sut.Filter(_photos, specification).ToList();

            // Assert
            Assert.Equal(2, photos.Count);
        }
    }
}
