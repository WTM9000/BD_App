using System;
using DB_Optics_core.Data;

namespace DB_Optics_core.Interface
{
    public interface IWarehouseRepository
    {
        Warehouse[] getAll();
        Warehouse getByID(int ID);
        Warehouse add(Warehouse entity);
        Warehouse update(Warehouse entity);
        void delete(Warehouse entity);
    }
}