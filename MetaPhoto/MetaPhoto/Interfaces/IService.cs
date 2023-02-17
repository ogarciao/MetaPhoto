namespace MetaPhoto.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        T Get(int id);
    }

    public interface IServiceThreeFilter<T>
    {
        IEnumerable<T> FilterByTitleAlbumAndEmail(IEnumerable<T> items, string? firstFilter, string? secondFilter, string? thirdFilter);
    }

    public interface IServicePagination<T>
    {
        IEnumerable<T> Page(IEnumerable<T> items);
    }
}
