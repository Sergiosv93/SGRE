using System.Web.Mvc;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;

namespace SGRE.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _clienteService.ObtenerTodos();
            return View(clientes);
        }

        // GET: Cliente/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Cliente/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            _clienteService.Crear(cliente);
            TempData["Mensaje"] = "Cliente registrado correctamente";
            return RedirectToAction("Index");
        }

        // GET: Cliente/Editar/5
        public ActionResult Editar(int id)
        {
            var cliente = _clienteService.ObtenerPorId(id);
            return View(cliente);
        }

        // POST: Cliente/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            _clienteService.Actualizar(cliente);
            TempData["Mensaje"] = "Cliente actualizado correctamente";
            return RedirectToAction("Index");
        }
    }
}