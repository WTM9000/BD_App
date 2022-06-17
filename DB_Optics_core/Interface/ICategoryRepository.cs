using System;
using DB_Optics_core.Data;

namespace DB_Optics_core.Interface
{
    public interface ICategoryRepository
    {
        Category[] getAll();
        Category getByID(int ID);
        Category add(Category entity);
        Category update(Category entity);
        void delete(int ID);
    }
}
