using System.Collections.Generic;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public interface IRepositorioParqueadero
    {
        //CRUD
        //GetAllParqueaderos
        IEnumerable<Parqueadero> GetAllParqueaderos();
        //AddParqueadero
        Parqueadero AddParqueadero(Parqueadero Parqueadero);
        //UpdateParqueadero
        Parqueadero UpdateParqueadero(Parqueadero Parqueadero);
        //DeleteParqueadero
        void DeleteParqueadero(int idParqueadero);
        //GetParqueadero
        Parqueadero GetParqueadero(int idParqueadero);  
        //GetParqueaderoConPuesto
        IEnumerable<Parqueadero> GetParqueaderoConPuesto(Estado estado);
        //GetParqueaderoConTipoVehiculo
        IEnumerable<Parqueadero> GetParqueaderoConVehiculo(TipoVehiculo tipoVehiculo);
        //GetParqueaderoConPuestoyTV     
        IEnumerable<Parqueadero> GetParqueaderoConPuestoyTV(Estado estado,TipoVehiculo tipoVehiculo);
    }
}