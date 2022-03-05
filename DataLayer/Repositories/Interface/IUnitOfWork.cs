
namespace DataLayer
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IFoodRepository FoodRepository{ get; }

    }
}
