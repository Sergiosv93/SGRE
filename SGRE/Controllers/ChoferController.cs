using System.Web.Mvc;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;

namespace SGRE.Web.Controllers
{
    public class ChoferController : Controller
    {
        private readonly IChoferService _choferService;

        public ChoferController(IChoferService choferService)
        {
            _choferService = choferService;
        }

        public ActionResult Index()
        {
            var choferes = _choferService.ObtenerTodos();
            return View(choferes);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Chofer chofer)
        {
            if (!ModelState.IsValid)
                return View(chofer);

            _choferService.Crear(chofer);
            TempData["Mensaje"] = "Chofer registrado correctamente";
            return RedirectToAction("Index");
        }
    }
}