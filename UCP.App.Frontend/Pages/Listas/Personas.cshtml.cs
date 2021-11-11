using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Dominio;
using UCP.App.Persistencia;
namespace UCP.App.Frontend.Pages
{
    public class PersonasModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        
        public IEnumerable<Profesor> Profesores{get;set;}

        public IActionResult OnGet()
        {
            Console.WriteLine("Retorno a esta página");
            
            
            Profesores = _repoProfesor.GetAllProfesores();
            /*foreach (var profesor in Profesores)
            {
                Console.WriteLine(profesor.apellidos);
            }*/
            return Page();
        }
    }
}
