using Market.Data.IRepositories;
using Market.Data.Repositories;

IProductRepository repository = new ProductRepository();


/*
var res = await repository.InsertAsync(new Market.Domain.Entities.Product()
{
    Name = "banana",
    Count = 10,
    Price = 25000,

});

var sel = await repository.SelectAsync(2);


var upd = await repository.UpdateAsync(2, new Market.Domain.Entities.Product()
{
    Name = "banana",
    Count = 20,
    Price = 30000,
});

*/

var all = repository.SelectAll();

var updSel = await repository.SelectAsync(1);


