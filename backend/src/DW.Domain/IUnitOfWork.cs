using DW.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace DW.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; set; }
        Task<int> SaveAsync();
    }
}
