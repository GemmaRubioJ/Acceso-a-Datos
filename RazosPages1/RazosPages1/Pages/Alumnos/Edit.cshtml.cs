using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.modelos;
using RazorPages.service;
using RazorPages.services;

namespace RazorPages1.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        private readonly IWebHostEnvironment WebHostEnviroment;

        [BindProperty]
        public Alumno alumno { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public EditModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment webHostEnviroment)
        {
            this.alumnoRepositorio = alumnoRepositorio;
            WebHostEnviroment = webHostEnviroment;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                alumno = alumnoRepositorio.GetAlumno(id.Value);
            }
            else
            {
                alumno = new Alumno();
            }
            return Page();
        }

        public IActionResult OnPost(Alumno alumno, IFormFile Photo)
        {
            if (alumno.Foto == null) alumno.Foto = Photo.FileName;
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    if (alumno.Foto != null)
                    {
                        string filePath = Path.Combine(WebHostEnviroment.WebRootPath, "images", alumno.Foto);
                        System.IO.File.Delete(filePath);
                    }
                    alumno.Foto = ProcessUploadedFile(Photo);
                }

                if (alumno.Id > 0)
                {
                    alumnoRepositorio.Update(alumno);
                }
                else
                {
                    alumnoRepositorio.Add(alumno);
                }

                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
         
        }

        private String ProcessUploadedFile(IFormFile Photo)
        {
            string uploadsFolder = Path.Combine(WebHostEnviroment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, Photo.FileName); // así concatenamos toda la ruta entera con el nombre del archivo
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;
        }
    }
}
