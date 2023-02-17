using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;

namespace MetaPhoto.Services
{
    public class PhotoServicePagination : IServicePagination<Photo>
    {
        private int limit;
        private int offset;

        public PhotoServicePagination(int? limit, int? offset)
        {
            this.limit = limit ?? 25;
            this.offset = offset ?? 0;
        }

        public IEnumerable<Photo> Page(IEnumerable<Photo> items)
        {
            return items
                .Skip(offset)
                .Take(limit);
        }
    }
}
