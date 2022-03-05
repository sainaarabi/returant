
using Models.TModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FoodRepository : Repository<Models.TModels.FoodEntity>, IFoodRepository
    {
        internal FoodRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }


        public delegate void AddFoodDelegate(FoodEntity inModel);

        public async Task DelegateAdd(FoodEntity food)
        {
            AddFoodDelegate Adder = AddMethod;
            Adder.Invoke(food);
        }

        public async void AddMethod(FoodEntity inModel)
        {
            await base.InsertAsync(inModel);
        }


    }
}
