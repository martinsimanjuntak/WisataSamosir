using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisataSamosir.Base.Controllers;
using WisataSamosir.Repository.Data;

namespace WisataSamosir.Controllers
{
    public class TouristAttractionsController : BaseController<TouristAttraction, TouristAttractionRepository, int>
    {
        private readonly TouristAttractionRepository touristAttractionRepository;

        public TouristAttractionsController(TouristAttractionRepository repository) : base(repository)
        {
            this.touristAttractionRepository = repository;
        }   

        public IActionResult Index()
        {
            return View();
        }
    }
}
