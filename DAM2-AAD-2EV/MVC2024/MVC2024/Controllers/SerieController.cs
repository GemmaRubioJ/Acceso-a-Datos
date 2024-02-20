using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			return View(Contexto.Series);
		}
	//-------------------------------------------------------------
		// GET: SerieController/Details/5
		public ActionResult Details(int id)
		{
			return View();
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
