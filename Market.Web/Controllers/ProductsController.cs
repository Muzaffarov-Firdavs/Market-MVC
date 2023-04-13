using Market.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market.Service.DTOs;
using Market.Service.Services;

namespace Market.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _productService.RetriewAllAsync();
            return View(user);
        }

        //GET: Products/Details/5
        public async Task<IActionResult> Details(long id)
        {
            return View(await _productService.RetriewAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Count,Price")] ProductForUserDto product)
        {
            await _productService.CreateAsync(product);
            return View(product);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            
            return View(await _productService.RetriewAsync(id));
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Count,Price")] ProductForUserDto product)
        {
           
            var updatedProduct = await _productService.ModifyASync(id, product);
            return View(product);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(long id)
        {

            var product = await _productService.RetriewAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.RemoveASync(id);
            
            return RedirectToAction(nameof(Index));
        }

        //private async bool ProductExists(int id)
        //{
        //    return (await _productService.RetriewAllAsync()).Any(p => p.Id == id);
        //}

    }
}
