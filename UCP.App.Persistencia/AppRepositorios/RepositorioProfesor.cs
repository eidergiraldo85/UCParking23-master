using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia

{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private static AppContext _appContext;
        IEnumerable<Profesor> profesores;
        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        public RepositorioProfesor(IEnumerable<Profesor> profesores)
        {
            this.profesores = profesores;
        }
        
        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            //var profesorAdicionado = _appContext.Profesores.AddProfesor(profesor);
            var profesorAdicionado = _appContext.Profesores.Add(profesor);
            _appContext.SaveChanges();
            //return profesorAdicionado;
            return profesorAdicionado.Entity;
        }

        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            //var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id = profesor.id);
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.telefono = profesor.telefono;
                profesorEncontrado.correo =profesor.correo;
                profesorEncontrado.vehiculo_1 = profesor.vehiculo_1;
                profesorEncontrado.vehiculo_2 = profesor.vehiculo_2;
                profesorEncontrado.facultad = profesor.facultad;
                profesorEncontrado.cubiculo = profesor.cubiculo;
                profesorEncontrado.departamento = profesor.departamento;
                _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }

        void IRepositorioProfesor.DeleteProfesor (int idProfesor)
        {
            //var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id = idProfesor);
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            if (profesorEncontrado == null)
                return;
            _appContext.Profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
        }

        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            //var profesorEncontrado= _appContext.Profesores.FirstOrDefault(p => p.id = idProfesor);
            var profesorEncontrado= _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            return profesorEncontrado;
        }

        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            var Profesores = _appContext.Profesores;
            foreach (var profesor in Profesores)
            {
                Console.WriteLine(profesor.apellidos);
            }
            return _appContext.Profesores;
        }

        Profesor IRepositorioProfesor.GetProfesorConVehiculo(int idProfesor)
        {
            //var profesoresEncontrados= _appContext.Profesores.Include(profesor => profesor.vehiculo_1).ToList();
            var profesorEncontrado= _appContext.Profesores.Include(p => p.vehiculo_1).Include(p=>p.vehiculo_2).FirstOrDefault(p=>p.id==idProfesor);
            /*foreach (var profesor in profesoresEncontrados)
            {
                if(profesor.id==idProfesor)
                {
                    if(profesor.vehiculo_1!=null)
                    {
                        Console.WriteLine(profesor.vehiculo_1.id);
                        Console.WriteLine(_appContext.Vehiculos.FirstOrDefault(v=>v.id==profesor.vehiculo_1.id).marca);
                        Console.WriteLine(_appContext.Vehiculos.FirstOrDefault(v=>v.id==profesor.vehiculo_1.id).modelo);
                        Console.WriteLine(_appContext.Vehiculos.FirstOrDefault(v=>v.id==profesor.vehiculo_1.id).placa);
                        Console.WriteLine(_appContext.Vehiculos.FirstOrDefault(v=>v.id==profesor.vehiculo_1.id).tipoVehiculo);
                        return profesor;
                    }
                }
            }*/
            return profesorEncontrado;
        }
    }
}