using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Interface
{
    public interface IRepository<T>
    {
        T[] getAll();
        T getByID(int ID);
        T add(T entity);
        T update(T entity);
        void delete(T entity);
    }
}
