using Microsoft.AspNetCore.Mvc;
using MVC2024.Service;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC2024.Controllers
{
    public class ClienteController : Controller
    {
        public HttpClient _httpClient;
        public ClienteService clienteService;

        public ClienteController(HttpClient httpClient, ClienteService clienteService)
        {

            _httpClient = httpClient;
            this.clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            // URL de tu API
            string apiUrl = "https://localhost:44353/api/alumno";
            string jsonData = await _httpClient.GetStringAsync(apiUrl);
            var clientes = clienteService.ParseJson(jsonData);
            return View(clientes);
        }
    }
}
