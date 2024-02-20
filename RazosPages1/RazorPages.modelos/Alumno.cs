using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.modelos
{
    public class Alumno             // Aunque no tenga un contructor instanciado lo tiene de por sí. Y al declarar instanciar objetos
                                    // de tipo alumno se autocompletará dato por dato para construir el ojeto.
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe contener mínimo 3 caracteres")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Formato de Email no válido")]
        public string Email { get; set; }
        public string? Foto { get; set; }
        public Curso? CursoId { get; set; }

    }
}
