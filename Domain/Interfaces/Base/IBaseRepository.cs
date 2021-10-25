using System;
using System.Collections.Generic;


namespace Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(Guid id);
        IReadOnlyList<T> GetAll();
        T Add(T entity);
        T Delete(T entity);  
    }
}
