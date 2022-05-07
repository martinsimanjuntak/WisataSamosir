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
    public class PortRoutesController : BaseController<PortRoute, PortRouteRepository, int>
    {
        private readonly PortRouteRepository portRouteRepository;
        public PortRoutesController(PortRouteRepository repository) : base(repository)
        {
            this.portRouteRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Schedule(int id)
        {
            ViewBag.id = id;
            return View("Schedule");
        }

        [HttpPost]
        public JsonResult AddPortRoute(PortRouteVM portRouteVM)
        {
            var result = portRouteRepository.AddPortRoute(portRouteVM);
            return Json(result);
        }

    }
}
