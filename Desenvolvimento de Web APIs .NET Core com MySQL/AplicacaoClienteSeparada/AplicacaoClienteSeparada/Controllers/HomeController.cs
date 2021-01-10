using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AplicacaoClienteSeparada.Models;
using AplicacaoClienteSeparada.Services;

namespace AplicacaoClienteSeparada.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var service = new ClienteService();

                ViewBag.ListarTodosClientes = service.ListarTodosClientes();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            var service = new ClienteService();
            if (id != null)
            {
                ViewBag.ClientePorId = service.ListarClientePorId(id);
            }
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Registrar(ClienteModel cliente)
        {
            var service = new ClienteService();
            if (cliente.id <= 0)
            {
                service.Inserircliente(cliente);
            }
            else
            {
                service.EditarCliente(cliente);
            }
            
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
