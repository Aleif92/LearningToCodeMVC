using LearningToCodeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LearningToCodeMVC.Controllers
{
    public class HelloWorldController : Controller
    {



        private static List<DogViewModel> dogs = new List<DogViewModel>();
        public IActionResult Index()
        {
            
            return View(dogs);
        }

        

        public IActionResult Create()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        [HttpPost]
        public IActionResult CreateDog(DogViewModel dogViewModel)
        {
            if (dogViewModel == null || string.IsNullOrEmpty(dogViewModel.Name))
            {
                ModelState.AddModelError("", "Dog name is required.");
                return View("Create", dogViewModel);
            }

            dogs.Add(dogViewModel);
            return RedirectToAction(nameof(Index));
        }


        public string Hello()
        {
            return "whos there?";
        }
    }
}
