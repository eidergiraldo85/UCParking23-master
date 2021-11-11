using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia

{
    public class RepositorioParqueadero : IRepositorioParqueadero
    {
        private static AppContext _appContext;
        IEnumerable<Parqueadero> Parqueaderos;
        public RepositorioParqueadero(AppContext appContext)
        {
            _appContext = appContext;
        }

        public RepositorioParqueadero(IEnumerable<Parqueadero> Parqueaderos)
        {
            this.Parqueaderos = Parqueaderos;
        }
        
        Parqueadero IRepositorioParqueadero.AddParqueadero(Parqueadero Parqueadero)
        {
            //var profesorAdicionado = _appContext.Parqueaderos.AddProfesor(profesor);
            var ParqueaderoAdicionado = _appContext.Parqueaderos.Add(Parqueadero);
            _appContext.SaveChanges();
            //return profesorAdicionado;
            return ParqueaderoAdicionado.Entity;
        }

        Parqueadero IRepositorioParqueadero.UpdateParqueadero(Parqueadero Parqueadero)
        {
            //var profesorEncontrado = _appContext.Parqueaderos.FirstOrDefault(p => p.id = profesor.id);
            var ParqueaderoEncontrado = _appContext.Parqueaderos.FirstOrDefault(p => p.id == Parqueadero.id);
            if (ParqueaderoEncontrado != null)
            {
                ParqueaderoEncontrado.direccion=Parqueadero.direccion;
                ParqueaderoEncontrado.numeroPuestos=Parqueadero.numeroPuestos;
                ParqueaderoEncontrado.picoPlaca=Parqueadero.picoPlaca;
                ParqueaderoEncontrado.horario=Parqueadero.horario;
                ParqueaderoEncontrado.puestos=Parqueadero.puestos;
                ParqueaderoEncontrado.personasAutorizadas=Parqueadero.personasAutorizadas;
                ParqueaderoEncontrado.transaccion=Parqueadero.transaccion;
                _appContext.SaveChanges();
            }
            return ParqueaderoEncontrado;
        }

        void IRepositorioParqueadero.DeleteParqueadero (int idParqueadero)
        {
            //var profesorEncontrado = _appContext.Parqueaderos.FirstOrDefault(p => p.id = idProfesor);
            var ParqueaderoEncontrado = _appContext.Parqueaderos.FirstOrDefault(p => p.id == idParqueadero);
            if (ParqueaderoEncontrado == null)
                return;
            _appContext.Parqueaderos.Remove(ParqueaderoEncontrado);
            _appContext.SaveChanges();
        }

        Parqueadero IRepositorioParqueadero.GetParqueadero(int idParqueadero)
        {
            //var profesorEncontrado= _appContext.Parqueaderos.FirstOrDefault(p => p.id = idProfesor);
            var ParqueaderoEncontrado= _appContext.Parqueaderos.FirstOrDefault(p => p.id == idParqueadero);
            return ParqueaderoEncontrado;
        }

        IEnumerable<Parqueadero> IRepositorioParqueadero.GetAllParqueaderos()
        {
            var Parqueaderos = _appContext.Parqueaderos;
            foreach (var Parqueadero in Parqueaderos)
            {
                Console.WriteLine(Parqueadero.direccion);
            }
            return _appContext.Parqueaderos;
        }

        IEnumerable<Parqueadero> IRepositorioParqueadero.GetParqueaderoConPuesto(Estado estado)
        {
            return _appContext.Parqueaderos.Where(p=>p.puestos.Any(s=>s.estado==estado)).ToList();
        }

        IEnumerable<Parqueadero> IRepositorioParqueadero.GetParqueaderoConVehiculo(TipoVehiculo tipoVehiculo)
        {
            return _appContext.Parqueaderos.Where(p=>p.puestos.Any(s=>s.tipoVehiculo==tipoVehiculo)).ToList();
        }
        IEnumerable<Parqueadero> IRepositorioParqueadero.GetParqueaderoConPuestoyTV(Estado estado,TipoVehiculo tipoVehiculo)
        {
            return _appContext.Parqueaderos.Where(p=>p.puestos.Any(s=>s.tipoVehiculo==tipoVehiculo && s.estado==estado)).ToList();
        }
    }
}