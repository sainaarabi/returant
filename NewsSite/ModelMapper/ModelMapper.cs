using AutoMapper;
using Models.TModels;
using ViewModelsLayer;

namespace NewsSite.ModelMapper
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<UserEntity, UserViewModel>();
            CreateMap<UserViewModel, UserEntity>();

            CreateMap<FoodEntity, FoodViewModel>();
            CreateMap<FoodViewModel, FoodEntity>();

            CreateMap<OrderEntity, OrderViewModel>();
            CreateMap<OrderViewModel, OrderEntity>();
        }
    }
}
