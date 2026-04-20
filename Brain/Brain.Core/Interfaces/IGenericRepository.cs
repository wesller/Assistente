using System;
using System.Collections.Generic;
using System.Text;

namespace Brain.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task Add(T dados);
        Task Update(T dados);
        Task Delete(int id);
        Task Save(); 
    }
}
