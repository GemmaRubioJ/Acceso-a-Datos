using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
	public class VehiculoController : Controller
	{
		//Clase dentro de la clase VehiculoModelo para ejecutar la consulta que tenemos en el Management
		public class VehiculoTotal
		{
			public string NomMarca { get; set; }
			public string NomSerie { get; set; }
			public string Matricula { get; set; }
			public string Color { get; set; }
		}




		// CONSTRUCTOR
		//-------------------------------------------------------------
		public Contexto Contexto { get; }
		public VehiculoController(Contexto contexto)
		{
			Contexto = contexto;
		}
		//-------------------------------------------------------------





		// METODOS
		public ActionResult Index()
		{
            var vehiculos = Contexto.Vehiculo
			.Include(v => v.Serie)
			.Include(v => v.Serie.Marca)
			.Include(v => v.ExtraModelo) 
			.ThenInclude(ve => ve.Extra) 
			.ToList();
            return View(vehiculos);
		}

		//Mostrar la Vista SQL
        //--------------------------------------------------------------

        public ActionResult Listado2()
        {
            var lista = Contexto.VistaTotal.FromSql($"SELECT  Marcas.NomMarca, Series.NomSerie, Vehiculo.Matricula, Vehiculo.Color FROM Marcas INNER JOIN  Series ON Marcas.ID = Series.MarcaId INNER JOIN Vehiculo ON Series.ID = Vehiculo.serieId");
			//List<VehiculoTotal> lista = Contexto.VistaTotal.ToList();
            return View(lista);
        }


		//Mostrar el Procedimiento Almacenado SQL getSeriesVehiculos
        //--------------------------------------------------------------

        public ActionResult Listado3()
        {
			var lista = Contexto.VistaTotal.FromSql($" EXECUTE getSeriesVehiculos");
            return View(lista);
        }


        //Mostrar el Procedimiento Almacenado SQL getVehiculosPorColor con parámetro
        //--------------------------------------------------------------

        public ActionResult Listado4(string color="%")
        {
			var elColor = new SqlParameter("@ColorSel", color);
			ViewBag.losColores = new SelectList(Contexto.Vehiculo.Select(v => new {Color = v.Color}).Distinct(), "Color", "Color");
            var lista = Contexto.VistaTotal.FromSql($"EXECUTE getVehiculosPorColor {elColor}");
            return View(lista);
        }
        //--------------------------------------------------------------


        public ActionResult Busqueda(string busca = "")
        {
			//objeto para almacenar la busqueda en el formulario 
			ViewBag.buscar = busca;
			var lista = from x in Contexto.Vehiculo.Include(x => x.Serie) where x.Matricula.Contains(busca) select x;
            return View(lista);
        }

        //--------------------------------------------------------------
        public ActionResult Busqueda2(string busca = "")
        {
            //objeto para almacenar la busqueda en el formulario 
            ViewBag.buscar = new SelectList(Contexto.Vehiculo, "Matricula", "Matricula", busca);     //propiedad VALUE, propiedad TEXT, propiedad SELECTED
            var lista = from x in Contexto.Vehiculo.Include(x => x.Serie) where (x.Matricula.Equals(busca)) select x;
            return View(lista);
        }

        //-------------------------------------------------------------
        // GET: VehiculoController/Details/5
        public ActionResult Details(int id)
		{
            VehiculoModelo vehiculo = Contexto.Vehiculo.Include("Serie.Marca").FirstOrDefault(x => x.Id == id);
            return View(vehiculo);
		}
		//-------------------------------------------------------------
		// GET: VehiculoController/Create
		public ActionResult Create()
		{
			ViewBag.SerieId = new SelectList(Contexto.Series, "ID", "NomSerie");
			ViewBag.losExtras = new SelectList(Contexto.Extras, "Id", "NomExtra");
			return View();
		}
		//-------------------------------------------------------------
		// POST: VehiculoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(VehiculoModelo vehiculo)
		{
			Contexto.Vehiculo.Add(vehiculo);
			Contexto.Database.EnsureCreated();
			Contexto.SaveChanges();

			foreach(var extraID in vehiculo.ExtraSeleccionado)
			{
				var obj = new VehiculoExtraModelo()
				{
					ExtraId = extraID,
					VehiculoId = vehiculo.Id
				};
				Contexto.ExtraModelo.Add(obj);
			}
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
		// GET: VehiculoController/Edit/5
		public ActionResult Edit(int id)
		{
            VehiculoModelo vehiculo = Contexto.Vehiculo.Include(v => v.ExtraModelo).FirstOrDefault(v => v.Id == id);
            ViewBag.SerieId = new SelectList(Contexto.Series, "ID", "NomSerie");
            vehiculo.ExtraSeleccionado = vehiculo.ExtraModelo.Select(ve => ve.ExtraId).ToList();
            var selectedExtras = vehiculo.ExtraModelo.Select(e => e.ExtraId).ToList();
            ViewBag.losExtras = new SelectList(Contexto.Extras, "Id", "NomExtra", selectedExtras);

			return View(vehiculo);
		}

		// POST: VehiculoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, VehiculoModelo cocheDatosNew)
		{
            VehiculoModelo cocheDatosOld = Contexto.Vehiculo.Include(v => v.ExtraModelo).FirstOrDefault(v => v.Id == id);

            if (cocheDatosOld == null)
            {
                // Manejar el caso en que el vehículo no se encuentra
                return NotFound();
            }

            // Actualizar propiedades básicas
            cocheDatosOld.Matricula = cocheDatosNew.Matricula;
            cocheDatosOld.Color = cocheDatosNew.Color;
            cocheDatosOld.serieId = cocheDatosNew.serieId;

            // Procesar los extras seleccionados
            var extrasSeleccionados = cocheDatosNew.ExtraSeleccionado ?? new List<int>();
            var extrasAEliminar = cocheDatosOld.ExtraModelo
                .Where(em => !extrasSeleccionados.Contains(em.ExtraId))
                .ToList();
            foreach (var extra in extrasAEliminar)
            {
                Contexto.ExtraModelo.Remove(extra);
            }

            var extrasActuales = cocheDatosOld.ExtraModelo.Select(em => em.ExtraId).ToList();
            foreach (var extraId in extrasSeleccionados)
            {
                if (!extrasActuales.Contains(extraId))
                {
                    cocheDatosOld.ExtraModelo.Add(new VehiculoExtraModelo { VehiculoId = id, ExtraId = extraId });
                }
            }

            // Guardar los cambios
            Contexto.SaveChanges();

            try
            {
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
            {
                // Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                // Consider logging the error details here
                return View(cocheDatosOld);
            }
		}

		// GET: VehiculoController/Delete/5
		public ActionResult Delete(int id)
		{
            VehiculoModelo vehiculo = Contexto.Vehiculo.Include("Serie.Marca").FirstOrDefault(x => x.Id == id);
            return View(vehiculo);
		}

		// POST: VehiculoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
            VehiculoModelo vehiculo = Contexto.Vehiculo.FirstOrDefault(x => x.Id == id);
            Contexto.Vehiculo.Remove(vehiculo);
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

        public ActionResult Seleccion(int marcaId = 1, int serieId = 0)   // se tiene que llamar con la propiedad id de la vista
        {
            //Este es otro metodo para pasar   (Origen de los datos  "Propiedad Value"   "Propiedad Text"  "Propiedad selected"
			ViewBag.lasMarcas = new SelectList (Contexto.Marcas, "ID", "NomMarca", marcaId );
			ViewBag.lasSeries = new SelectList(Contexto.Series.Where(s => s.MarcaId == marcaId), "ID", "NomSerie", serieId); 
			List<VehiculoModelo> vehiculos = Contexto.Vehiculo.Where(v => v.serieId == serieId).ToList();
            return View(vehiculos);
        }
    }
}
