using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
  public interface IRepositoryManager
  {
    IBookRepository Book { get; }
    IOrderRepository Order { get; }
    IOrdBookRepository OrdBook { get; }
    Task SaveAsync();
    void Save();
  }
}
