using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Persistance.Repositories
{
    public interface IUnitOfWork
    {
       public void Complete();
    }
}
