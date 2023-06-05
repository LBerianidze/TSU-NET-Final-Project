using DecorationMarket.Domain.DBModel;
using DecorationMarket.Domain.ViewModels;
using DecorationMarket.Core.Interface;
using DecorationMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DecorationMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        [Route("/{page?}")]
        [Route("/category/{code?}/{page?}")]
        public async Task<IActionResult> Index(string code, int page=1)
        {
            var viewModel = new IndexViewModel();

            viewModel.Categories = await categoryService.GetCategoriesAsync();
            viewModel.Products = await productService.GetProducts(code,page);
            return View(viewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}