using Market.Service.DTOs;

namespace Market.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductForUserDto> CreateAsync(ProductForUserDto product);
        Task<bool> RemoveASync(long id);
        Task<ProductForUserDto> ModifyASync(long id, ProductForUserDto product);
        Task<ProductForUserDto> RetriewAsync(long id);
        Task<List<ProductForUserDto>> RetriewAllAsync();


    }
}
