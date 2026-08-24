using System.Web.Mvc;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;

namespace SGRE.Web.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        public ActionResult Index()
        {
            var vehiculos = _vehiculoService.ObtenerTodos();
            return View(vehiculos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
                return View(vehiculo);

            _vehiculoService.Crear(vehiculo);
            TempData["Mensaje"] = "Vehículo registrado correctamente";
            return RedirectToAction("Index");
        }
    }
}