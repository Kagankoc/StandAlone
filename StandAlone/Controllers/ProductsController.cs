using Microsoft.AspNetCore.Mvc;
using StandAlone.Models;

namespace StandAlone.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Products);
        }
    }
}