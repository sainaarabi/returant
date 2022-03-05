using DataLayer.Tools;
using System;

namespace DataLayer
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Options options) :
            base(options)
        {

        }

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(DataBaseContext);
                }

                return _userRepository;
            }
        }




        private IFoodRepository _foodRepository;

        public IFoodRepository FoodRepository
        {
            get
            {
                if (_foodRepository == null)
                {
                    _foodRepository = new FoodRepository(DataBaseContext);
                }

                return _foodRepository;
            }
        }


        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(DataBaseContext);
                }

                return _orderRepository;
            }
        }




    }
}
