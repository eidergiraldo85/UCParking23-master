using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        private static IRepositorioVehiculo _repoVehiculo = new RepositorioVehiculo(new Persistencia.AppContext());
        private static IRepositorioParqueadero _repoParqueadero = new RepositorioParqueadero(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Esto es un mensaje por consola");
            /*Profesor nuevoProfesor =AddProfesor();
            Vehiculo nuevoVehiculo = AgregarVehiculo();
            AdicionarVehiculo(24,null,nuevoVehiculo);
            Puesto nuevoPuesto =new Puesto{tipoVehiculo=TipoVehiculo.Automovil,numeroParquadero=1,estado=Estado.ocupado,vehiculo=nuevoVehiculo};
            Transaccion nuevaTransaccion = new Transaccion{horaIngreso=new DateTime(2021,10,06,10,30,15),horaSalida=new DateTime(2021,10,06,12,15,12),valorHora=1500,vehiculo=nuevoVehiculo};
            AdicionarDatosParqueadero(1,nuevoPuesto, nuevoProfesor, nuevaTransaccion);
            /*Profesor profesor = BuscarProfesorConVehiculo(13);
            Console.WriteLine(profesor.nombre);
            Console.WriteLine(profesor.apellidos);
            Console.WriteLine(profesor.facultad);
            Console.WriteLine(profesor.vehiculo_1.id);//no funciona
            Console.WriteLine(profesor.vehiculo_1.marca);//no funciona
            Console.WriteLine(profesor.vehiculo_1.modelo);//no funciona
            Console.WriteLine(profesor.vehiculo_1.placa);//no funciona
            Console.WriteLine(profesor.vehiculo_1.tipoVehiculo);//no funciona
            Console.WriteLine(profesor.vehiculo_2.marca);//no funciona*/
            //BuscarProfesor(1);
            //BuscarProfesores();
            //EliminarProfesor(3);
            //ActualizarProfesor();
           // Vehiculo vehiculo_p = new Vehiculo{marca="Toyota", modelo="Corola",placa="COR123",tipoVehiculo=TipoVehiculo.Automovil};
            //Vehiculo vehiculo_s = new Vehiculo{marca="Kia", modelo="Sportage",placa="SPO542",tipoVehiculo=TipoVehiculo.Camioneta};

            //AdicionaProfesorConVehiculo(vehiculo_p,vehiculo_s);*/
            //Vehiculo automovil = GetVehiculo(26);
            //Parqueadero nuevoparqueadero = AddParqueadero();
            //Console.WriteLine(nuevoparqueadero.direccion);
            //AdicionarVehiculo(5,automovil,null);

            //AgregarVehiculo();
            //BuscarProfesores();                        

            //BuscarProfesores();


            /*IEnumerable<Parqueadero> parqueaderos = BuscarParquederoSegunPuesto(Estado.ocupado);
            foreach (var parqueadero in parqueaderos)
            {
                Console.WriteLine(parqueadero.direccion);
            }
            Console.WriteLine("Fin del programa");
            */
            /*IEnumerable<Parqueadero> parqueaderos = _repoParqueadero.GetParqueaderoConVehiculo(TipoVehiculo.Motocicleta);
            foreach (var parqueadero in parqueaderos)
            {
                Console.WriteLine(parqueadero.direccion);
            }*/

            IEnumerable<Parqueadero> parqueaderos = _repoParqueadero.GetParqueaderoConPuestoyTV(Estado.libre,TipoVehiculo.Automovil);
            foreach (var parqueadero in parqueaderos)
            {
                Console.WriteLine(parqueadero.direccion);
            }
            Console.WriteLine("Fin del programa");
        }


        //AddProfesor

        private static Profesor AddProfesor()
        {
            var profesor = new Profesor 
            {
               nombre = "Mauricio",
               apellidos = "Orozco",
               identificacion = 10041005,
               correo =  "mauricioorozco.tic@ucaldas.edu.co",
               telefono ="30130130303",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Ciencias Computacionales",
               departamento = "Ingeniería",
               cubiculo ="ocho" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
            return profesor_retornado;
        }
        //GetProfesor
        private static Profesor BuscarProfesor(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            //Console.WriteLine(profesor.nombre+" "+profesor.apellidos+"\n Facultad: "+profesor.facultad + " "+profesor.departamento+"\n Identificación: "+profesor.identificacion+"\n Telefono: "+profesor.telefono);
            return profesor;
        }
        //DeleteProfesor

        private static void EliminarProfesor(int idProfesor)
        {
            _repoProfesor.DeleteProfesor(idProfesor);
        }
        //UpdateProfesor
        private static void ActualizarProfesor()
        {
            var profesor = new Profesor 
            {
               id = 9,
               nombre = "Angelica",
               apellidos = "Muñoz",
               identificacion = 100000010,
               correo =  "angelicamuñoz.tic@ucaldas.edu.co",
               telefono ="30000000020",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Ingeniería",
               departamento = "Ciencias Computacionales",
               cubiculo ="Tres"
            };
            Profesor profesor_retornado =_repoProfesor.UpdateProfesor(profesor);                         
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        
        }
        //GetAllProfesores
        private static void BuscarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();
            
            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre);
            }
            //Console.WriteLine(profesores.First().nombre);
        }

        private static void AdicionaProfesorConVehiculo()
        {
            var profesor = new Profesor 
            {
               nombre = "Catalina",
               apellidos = "Gómez",
               identificacion = 102543614,
               correo =  "catalinagomez.tic@ucaldas.edu.co",
               telefono ="3013013020",
               vehiculo_1 = new Vehiculo{marca="Renault", modelo="Clio",placa="ABA121",tipoVehiculo=TipoVehiculo.Coupe},
               vehiculo_2 = new Vehiculo{marca="Kawasaki", modelo="Ninja",placa="RAM12A",tipoVehiculo=TipoVehiculo.Motocicleta},
               facultad ="Ciencias Computacionales",
               departamento = "Ingeniería",
               cubiculo ="Tres" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }


        private static void AdicionaProfesorConVehiculo(Vehiculo pVehiculo,Vehiculo sVehiculo)
        {
            var profesor = new Profesor 
            {
               nombre = "Simón",
               apellidos = "Gaviria",
               identificacion = 105348213,
               correo =  "simongaviria.tic@ucaldas.edu.co",
               telefono ="3251323413",
               vehiculo_1 = pVehiculo,
               vehiculo_2 = sVehiculo,
               facultad ="Odontología",
               departamento = "Salud",
               cubiculo ="ocho" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }

        private static Profesor BuscarProfesorConVehiculo(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesorConVehiculo(idProfesor);        
            return profesor; 
        }

        private static void AdicionarVehiculo(int idProfesor, Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            var profesor = _repoProfesor.GetProfesorConVehiculo(idProfesor);
            if(profesor.vehiculo_1==null & vehiculo1!=null)
            {
                profesor.vehiculo_1=vehiculo1;
            }else{
                Console.WriteLine("Este profesor ya tiene un vehiculo asignado, verificar parametro incompleto");
            }
            if (profesor.vehiculo_2==null & vehiculo2!=null)
            {
                profesor.vehiculo_2=vehiculo2;
            }else{
                Console.WriteLine("Este profesor ya tiene un vehiculo asignado, verificar parametro incompleto");
            }
            _repoProfesor.UpdateProfesor(profesor);
        }

        private static Vehiculo AgregarVehiculo()
        {
            var vehiculo = new Vehiculo
            {
                marca="Chevrolet",
                modelo="MHH432",
                placa="Koleos",
                tipoVehiculo=TipoVehiculo.Automovil
            };
            Vehiculo vehiculo_retornado=_repoVehiculo.AddVehiculo(vehiculo);
            if(vehiculo_retornado!=null)
            {
                Console.WriteLine("Se registró un vehiculo nuevo");
            }
            return vehiculo_retornado;
        }

        private static Vehiculo GetVehiculo(int idVehiculo){
            return _repoVehiculo.GetVehiculo(idVehiculo);
        }

        private static Parqueadero AddParqueadero()
        {
            var parqueadero = new Parqueadero
            {
                direccion="Carrera 10 #20a -18",
                numeroPuestos=100,
                picoPlaca="0 y 9",
                horario="Lunes a Sábado 8 a 22 horas",
                puestos=new List<Puesto>{
                    new Puesto{tipoVehiculo=TipoVehiculo.Automovil,numeroParquadero=1,estado=Estado.ocupado,vehiculo=new Vehiculo{marca="Audi",modelo="tt",placa="TTT123",tipoVehiculo=TipoVehiculo.Automovil}},
                    new Puesto{tipoVehiculo=TipoVehiculo.Motocicleta,numeroParquadero=2,estado=Estado.ocupado,vehiculo=new Vehiculo{marca="KTM",modelo="Duke",placa="ABC12A",tipoVehiculo=TipoVehiculo.Motocicleta}},
                    new Puesto{tipoVehiculo=TipoVehiculo.Automovil,numeroParquadero=3,estado=Estado.ocupado,vehiculo=new Vehiculo{marca="FIAT",modelo="uno",placa="JKR123",tipoVehiculo=TipoVehiculo.Automovil}}
                },
                personasAutorizadas=new List<Persona>{
                    new Persona{nombre="Jacobo",apellidos="Jaramillo"},
                    new Persona{nombre="Tatiana",apellidos="Gómez"}
                },
                transaccion=null                
            };
            Parqueadero parqueadero_retornado =_repoParqueadero.AddParqueadero(parqueadero);
            return parqueadero_retornado;
        }

        private static void AdicionarDatosParqueadero(int idParqueadero,Puesto puesto, Persona persona, Transaccion transaccion)
        {
            var parqueaderoRecuperado = _repoParqueadero.GetParqueadero(idParqueadero);
            {
                if (parqueaderoRecuperado.puestos!=null)
                {
                    parqueaderoRecuperado.puestos.Add(puesto);
                }else
                {
                    parqueaderoRecuperado.puestos = new List<Puesto>();
                    parqueaderoRecuperado.puestos.Add(puesto);
                }
                _repoParqueadero.UpdateParqueadero(parqueaderoRecuperado);
            }
        }

        private static IEnumerable<Parqueadero> BuscarParquederoSegunPuesto(Estado estado)
        {
            return _repoParqueadero.GetParqueaderoConPuesto(estado);
        }
    }
}
