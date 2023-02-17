using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class PhotoServiceFilter : IServiceThreeFilter<Photo>
    {
        public IEnumerable<Photo> FilterByTitleAlbumAndEmail(IEnumerable<Photo> items, string? title, string? albumTitle, string? email)
        {
            PhotoTitleSpecification? photoTitleSpecification = string.IsNullOrEmpty(title) ? null : new PhotoTitleSpecification(title);
            AlbumTitleSpecification? albumTitleSpecification = string.IsNullOrEmpty(albumTitle) ? null : new AlbumTitleSpecification(albumTitle);
            UserEmailSpecification? userEmailSpecification = string.IsNullOrEmpty(email) ? null : new UserEmailSpecification(email);

            AndSpecification<Photo> specification = new AndSpecification<Photo>(photoTitleSpecification, albumTitleSpecification, userEmailSpecification);

            PhotoFilter photoFilter = new PhotoFilter();

            items = photoFilter.Filter(items, specification).ToList();

            return items;
        }
    }
}
