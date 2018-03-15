using ITI.PrimarySchool.WebApp.Models.MathViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    public class MathController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AddNumberViewModel());
        }

        [HttpPost]
        public IActionResult Index(AddNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Total = model.Number1 + model.Number2;
            }

            return View(model);
        }
    }
}
