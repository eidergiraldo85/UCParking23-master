using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia

{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        private static AppContext _appContext;
        IEnumerable<Vehiculo> vehiculos;
        public RepositorioVehiculo(AppContext appContext)
        {
            _appContext = appContext;
        }

        public RepositorioVehiculo(IEnumerable<Vehiculo> vehiculos)
        {
            this.vehiculos = vehiculos;
        }
        
        Vehiculo IRepositorioVehiculo.AddVehiculo(Vehiculo vehiculo)
        {
            //var profesorAdicionado = _appContext.vehiculos.AddProfesor(profesor);
            var vehiculoAdicionado = _appContext.Vehiculos.Add(vehiculo);
            _appContext.SaveChanges();
            //return profesorAdicionado;
            return vehiculoAdicionado.Entity;
        }

        Vehiculo IRepositorioVehiculo.UpdateVehiculo(Vehiculo vehiculo)
        {
            //var profesorEncontrado = _appContext.vehiculos.FirstOrDefault(p => p.id = profesor.id);
            var vehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p => p.id == vehiculo.id);
            if (vehiculoEncontrado != null)
            {
                vehiculoEncontrado.marca=vehiculo.marca;
                vehiculoEncontrado.modelo=vehiculo.modelo;
                vehiculoEncontrado.placa=vehiculo.placa;
                vehiculoEncontrado.tipoVehiculo=vehiculo.tipoVehiculo;
                _appContext.SaveChanges();
            }
            return vehiculoEncontrado;
        }

        void IRepositorioVehiculo.DeleteVehiculo (int idVehiculo)
        {
            //var profesorEncontrado = _appContext.vehiculos.FirstOrDefault(p => p.id = idProfesor);
            var vehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p => p.id == idVehiculo);
            if (vehiculoEncontrado == null)
                return;
            _appContext.Vehiculos.Remove(vehiculoEncontrado);
            _appContext.SaveChanges();
        }

        Vehiculo IRepositorioVehiculo.GetVehiculo(int idVehiculo)
        {
            //var profesorEncontrado= _appContext.vehiculos.FirstOrDefault(p => p.id = idProfesor);
            var vehiculoEncontrado= _appContext.Vehiculos.FirstOrDefault(p => p.id == idVehiculo);
            return vehiculoEncontrado;
        }

        IEnumerable<Vehiculo> IRepositorioVehiculo.GetAllVehiculos()
        {
            var vehiculos = _appContext.Vehiculos;
            foreach (var vehiculo in vehiculos)
            {
                Console.WriteLine(vehiculo.marca);
            }
            return _appContext.Vehiculos;
        }

        
    }
}