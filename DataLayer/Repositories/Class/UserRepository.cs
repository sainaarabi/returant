
namespace DataLayer
{
    public class UserRepository : Repository<Models.TModels.UserEntity>, IUserRepository
    {
        internal UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }
    }
}
