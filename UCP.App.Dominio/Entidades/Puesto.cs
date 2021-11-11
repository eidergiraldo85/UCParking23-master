using System;

namespace UCP.App.Dominio

{
    public class Puesto
    {
        public int id {get;set;}

        public TipoVehiculo tipoVehiculo{get;set;}

        public int numeroParquadero {get;set;}

        public Estado estado{get;set;}//Enum

        public Vehiculo vehiculo{get;set;}
    }
}