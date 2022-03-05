
using Models.TModels;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFoodRepository : DataLayer.Base.IRepository<Models.TModels.FoodEntity>
    {
        Task DelegateAdd(FoodEntity food);
    }
}
