using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2024.Models;

namespace MVC2024.Controllers
{
	public class MarcaController : Controller
	{
	//-------------------------------------------------------------
		public Contexto Contexto { get; }

		//añadimos metodo constructor para inyectar el contexto
		public MarcaController(Contexto contexto)
        {
			Contexto = contexto;
		}
	//-------------------------------------------------------------
        // GET: MarcaController
        public ActionResult Index()
		{

			/*Esta es otra manera de hacerlo solo que en return podnriamos listaMarcas
			 			List<MarcaModelo> listaMarcas = new List<MarcaModelo>();
			*/
			//devolvemos la lista de marcas ya que Marcas es un dbset y por tanto es una lista de objetos de tipo MarcaModelo
			return View(Contexto.Marcas);
		}
	//-------------------------------------------------------------

		// GET: MarcaController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: MarcaController/Create
		public ActionResult Create()
		{
			
			return View();
		}

	//-------------------------------------------------------------
		//Este metodo lo modificamos para que reciba un objeto de tipo MarcaModelo	
		// POST: MarcaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(MarcaModelo marca)
		{
			Contexto.Marcas.Add(marca);
			Contexto.Database.EnsureCreated();
			Contexto.SaveChanges();

			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	//-------------------------------------------------------------
	public ActionResult Desplegable()
		{
			//ViewBag es un CONTENEDOR DE DATOS que se puede utilizar para pasar datos entre el controlador y la vista
			ViewBag.Marcas = new SelectList(Contexto.Marcas, "ID", "NomMarca");

			//Este es otro metodo para pasar datos a la vista
			ViewBag.Marcas2 = Contexto.Marcas;
			return View();
		}
		
	//-------------------------------------------------------------
		// GET: MarcaController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: MarcaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: MarcaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: MarcaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
