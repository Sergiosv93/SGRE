using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;
using System.Web.Mvc;

namespace SGRE.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IEnvioService _envioService;
        private readonly IClienteService _clienteService;
        private readonly IChoferService _choferService;
        private readonly IVehiculoService _vehiculoService;

        // Unity resuelve automáticamente estas 4 dependencias al crear el Controller
        public EnvioController(
            IEnvioService envioService,
            IClienteService clienteService,
            IChoferService choferService,
            IVehiculoService vehiculoService)
        {
            _envioService = envioService;
            _clienteService = clienteService;
            _choferService = choferService;
            _vehiculoService = vehiculoService;
        }

        // GET: Envio
        public ActionResult Index()
        {
            var envios = _envioService.ObtenerTodos();
            return View(envios);
        }

        // GET: Envio/Crear
        public ActionResult Crear()
        {
            CargarListasDesplegables();
            return View();
        }

        // POST: Envio/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Envio envio)
        {
            if (!ModelState.IsValid)
            {
                CargarListasDesplegables();
                return View(envio);
            }

            _envioService.CrearEnvio(envio);
            TempData["Mensaje"] = "Envío registrado correctamente";
            return RedirectToAction("Index");
        }

        // GET: Envio/Detalle/5
        public ActionResult Detalle(int id)
        {
            var envio = _envioService.ObtenerPorId(id);
            return View(envio);
        }

        // POST: Envio/CambiarEstatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarEstatus(int envioId, SGRE.Domain.Enums.EstatusEnvio nuevoEstatus, string comentario)
        {
            _envioService.CambiarEstatus(envioId, nuevoEstatus, comentario);
            TempData["Mensaje"] = "Estatus actualizado correctamente";
            return RedirectToAction("Detalle", new { id = envioId });
        }

        private void CargarListasDesplegables()
        {
            ViewBag.Clientes = new SelectList(_clienteService.ObtenerTodos(), "Id", "Nombre");
            ViewBag.Choferes = new SelectList(_choferService.ObtenerTodos(), "Id", "Nombre");
            ViewBag.Vehiculos = new SelectList(_vehiculoService.ObtenerTodos(), "Id", "Placa");
        }
    }
}