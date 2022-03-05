
using Microsoft.EntityFrameworkCore;
using Models.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderRepository : Repository<Models.TModels.OrderEntity>, IOrderRepository
    {
        internal OrderRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public async Task<IList<OrderEntity>> GetAllOrdersByCustomerIDAsync(Guid id)
        {
            var result = await DbSet
                .Include(a => a.Buyerlist)
                .Include(a => a.Food)
                .Where(a => a.Buyer == id).ToListAsync();
            return result;
        }
    }
}
