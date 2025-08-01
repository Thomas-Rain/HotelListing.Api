using HotelListing.Api.Models;
using HotelListing.Api.Models;

namespace HotelListing.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<T>> GetAllAsync();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task UpdateAsync(T entity);

        Task<T> GetAsync(int? id);
        //Task<TResult> GetAsync<TResult>(int? id);
        //Task<List<TResult>> GetAllAsync<TResult>();
    }
}