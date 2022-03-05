
namespace DataLayer
{
    public class Repository<T> : Base.Repository<T> where T : Models.Base.Entity
    {
        internal Repository(DataBaseContext databaseContext) : base(databaseContext)
        {

        }

    }
}
