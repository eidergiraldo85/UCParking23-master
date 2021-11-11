using System.Collections.Generic;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public interface IRepositorioVehiculo
    {
        //CRUD
        //GetAllVehiculos
        IEnumerable<Vehiculo> GetAllVehiculos();
        //AddVehiculo
        Vehiculo AddVehiculo(Vehiculo vehiculo);
        //UpdateVehiculo
        Vehiculo UpdateVehiculo(Vehiculo vehiculo);
        //DeleteVehiculo
        void DeleteVehiculo(int idVehiculo);
        //GetVehiculo
        Vehiculo GetVehiculo(int idVehiculo);       
    }
}