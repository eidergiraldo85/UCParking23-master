using System;
using System.ComponentModel.DataAnnotations;
namespace UCP.App.Dominio
{
    public class Persona
    {
        public int id {get;set;}
        [Required]
        public string nombre {get;set;}

        public string apellidos {get;set;}

        public int identificacion {get;set;}

        public string telefono {get;set;}

        public string correo {get;set;}

        public Vehiculo vehiculo_1{get; set;}

        public Vehiculo vehiculo_2{get; set;}
    }


    
}