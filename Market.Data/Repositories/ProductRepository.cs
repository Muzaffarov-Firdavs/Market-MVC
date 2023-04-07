using Market.Data.DbContexts;
using Market.Data.IRepositories;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Market.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext = new AppDbContext();


        public async Task DeleteAsync(long id)
        {
            Product existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            var i = dbContext.Products.Remove(existingProduct);
            dbContext.SaveChanges();
        }

        public async Task<Product> InsertAsync(Product product)
        {
            var insertedUser = await dbContext.Products.AddAsync(product);
            dbContext.SaveChanges();
            return insertedUser.Entity;
        }

        public IQueryable<Product> SelectAll()
            => dbContext.Products.Where(product => true);

        public async Task<Product> SelectAsync(long id)
            => await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Product> UpdateAsync(long id, Product product)
        {
            product.Id = id;
            var updatedProduct = dbContext.Products.Update(product);
            dbContext.SaveChanges();
            return updatedProduct.Entity;
        }
    }
}
