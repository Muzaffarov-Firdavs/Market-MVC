using Market.Domain.Entities;

namespace Market.Data.IRepositories
{
    public interface IProductRepository
    {
        public Task<Product> InsertAsync(Product product);
        public Task<Product> UpdateAsync(long id, Product product);
        public Task DeleteAsync(long id);
        public Task<Product> SelectAsync(long id);
        IQueryable<Product> SelectAll();
    }
}
