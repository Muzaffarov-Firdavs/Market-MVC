using Market.Data.IRepositories;
using Market.Data.Repositories;
using Market.Domain.Entities;
using Market.Service.DTOs;
using Market.Service.Exceptions;
using Market.Service.Interfaces;

namespace Market.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepostiry;

        public ProductService(IProductRepository productRepostiry)
        {
            this.productRepostiry = productRepostiry;
        }

        public async Task<ProductForUserDto> CreateAsync(ProductForUserDto product)
        {
            // checking for exist
            var exsistingProducts = productRepostiry.SelectAll()
                .Where(p => p.Name == product.Name).Take(1).ToList();
            if (exsistingProducts.Any())
                throw new SpecialExeption(400, "Product already exists");

            // mapping 
            Product mappedProduct = new Product()
            {
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                CreatedAt = DateTime.UtcNow,
            };

            var addedProduct = await productRepostiry.InsertAsync(mappedProduct);

            ProductForUserDto resultProduct = new ProductForUserDto()
            {
                Id = addedProduct.Id,
                Name = addedProduct.Name,
                Count = addedProduct.Count,
                Price = addedProduct.Price,
            };

            return resultProduct;
        }

        public async Task<ProductForUserDto> ModifyASync(long id, ProductForUserDto product)
        {
            var existingProduct = await productRepostiry.SelectAsync(id);

            if (existingProduct is null)
                throw new SpecialExeption(404, "Product is not found");

            
            existingProduct.Name = product.Name;
            existingProduct.Count = product.Count;
            existingProduct.Price = product.Price;



            var updatedProduct = await productRepostiry.UpdateAsync(id, existingProduct);

            ProductForUserDto resultProduct = new ProductForUserDto()
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Count = updatedProduct.Count,
                Price = updatedProduct.Price,
            };

            return resultProduct;
        }

        public async Task<bool> RemoveASync(long id)
        {
            var product = await productRepostiry.SelectAsync(id);

            if (product is null)
                throw new SpecialExeption(404, "Product is not found");

            await productRepostiry.DeleteAsync(id);

            return true;
        }

        public async Task<List<ProductForUserDto>> RetriewAllAsync()
        {
            var products = productRepostiry.SelectAll();

            var mappingProducts = new List<ProductForUserDto>();
            
            foreach (var product in products)
            {
                mappingProducts.Add(new ProductForUserDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Count = product.Count,
                    Price = product.Price
                });
            }

            return  mappingProducts;
        }

        public async Task<ProductForUserDto> RetriewAsync(long id)
        {
            var product = await productRepostiry.SelectAsync(id);

            if (product is null)
                throw new SpecialExeption(404, "Product is not found");

            ProductForUserDto resultProduct = new ProductForUserDto()
            {Id = product.Id,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
            };

            return resultProduct;
        }
    }
}
