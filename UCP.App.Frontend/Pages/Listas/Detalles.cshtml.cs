using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
namespace UCP.App.Frontend.Pages
{
    public class DetallesModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        
        public Profesor profesor{get; set;}

        public IActionResult OnGet(int profesorId)
        {
            profesor =_repoProfesor.GetProfesor(profesorId);
            //Console.WriteLine(profesor.vehiculo_1);//pendiente
            if(profesor==null)
            {
                return RedirectToPage("./Personas");
            }else
            return Page();        
        }
    }
}
