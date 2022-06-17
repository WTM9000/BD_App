
using System;
using DB_Optics_core.Data;

namespace DB_Optics_core.Interface
{
    public interface IWaresRepository
    {
        Wares[] getAll();
        Wares getByID(int ID);
        Wares add(Wares entity);
        Wares update(Wares entity);
        void delete(int ID);
    }
}
