using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class PhotoFilter : IFilter<Photo>
    {
        public IEnumerable<Photo> Filter(IEnumerable<Photo> items, ISpecification<Photo> specification)
        {
            return items
                .Where(i => specification.IsSatisfiedBy(i));
        }
    }
}
