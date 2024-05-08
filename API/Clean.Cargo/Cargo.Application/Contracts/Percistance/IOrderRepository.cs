using Cargo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Application.Contracts.Percistance
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
    }
}
