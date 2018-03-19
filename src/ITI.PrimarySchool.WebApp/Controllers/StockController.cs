using ITI.PrimarySchool.WebApp.Models.StockViewModels;
using ITI.PrimarySchool.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route("Stock")]
    public class StockController : Controller
    {
        readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_stockService.Products);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(Guid id)
        {
            var product = _stockService.Products.SingleOrDefault(x => x.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost("{id}")]
        public IActionResult Edit(ProductViewModel model)
        {
            _stockService.Update(model);
            return Redirect("/Stock");
        }
    }
}
