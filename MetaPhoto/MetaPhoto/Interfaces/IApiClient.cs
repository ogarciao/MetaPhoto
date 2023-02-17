namespace MetaPhoto.Interfaces
{
    public interface IApiClient<T>
    {
        Task<List<T>> GetAll(string uri);
        Task<T> Get(string uri, int id);
    }
}
