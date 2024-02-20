using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
	public class SerieController : Controller
	{
	//-------------------------------------------------------------
		public Contexto Contexto { get; }

		//añadimos metodo constructor para inyectar el contexto
		public SerieController(Contexto contexto)
		{
			Contexto = contexto;
		}
	//-------------------------------------------------------------

		// GET: SerieController
		public ActionResult Index()
		{
			/*Otra forma de pasar el Index 
			List<SerieModelo> lista = Contexto.Series.Include(x => x.Marca).ToList());
			return (lista); */
			return View(Contexto.Series.Include(x => x.Marca).ToList());
		}
	//-------------------------------------------------------------
		// GET: SerieController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}
    //-------------------------------------------------------------
        // GET: SerieController/Details/5
        public ActionResult Listado(int id)
        {
			MarcaModelo marca = Contexto.Marcas.Include(m => m.LasSeries).FirstOrDefault(m => m.ID == id);
            return View(marca);
        }

        // GET: SerieController/Create
        public ActionResult Create()
		{
			ViewBag.MarcaId = new SelectList(Contexto.Marcas, "ID", "NomMarca");
			return View();
		}
		//-------------------------------------------------------------
		// POST: SerieController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SerieModelo serie)
		{
			Contexto.Series.Add(serie);
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
		// GET: SerieController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SerieController/Edit/5
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

		// GET: SerieController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SerieController/Delete/5
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
