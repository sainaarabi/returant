using DataLayer.Base;
using Models.TModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IOrderRepository : DataLayer.Base.IRepository<Models.TModels.OrderEntity>
    {
        Task<IList<OrderEntity>> GetAllOrdersByCustomerIDAsync(Guid id); 

    }
}
