
using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Models.TModels;
using ResturantProject.InfraStructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelsLayer;

namespace ResturantProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        //[HttpGet]
        //public async Task<ActionResult<List<OrderViewModel>>> Get([FromBody]Guid Id)
        //{
        //    var result = _unitOfWork.OrderRepository.GetAllOrdersByCustomerIDAsync(Id);

        //    var res = _mapper.Map<List<OrderViewModel>>(result);

        //    return Ok(res);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> Get(Guid id)
        {
            var result =await _unitOfWork.OrderRepository.GetAllOrdersByCustomerIDAsync(id);

            var res = _mapper.Map<List<OrderViewModel>>(result);

            return Ok(res);
        }



        [HttpGet]
        public async Task<ActionResult<OrderViewModel>> Get()
        {
            var result = _unitOfWork.OrderRepository.GetAll();

            var res = _mapper.Map<List<OrderViewModel>>(result);

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Post([FromBody] OrderViewModel inModel)
        {

            var food = await _unitOfWork.FoodRepository.GetByIdAsync(inModel.FoodID);

            var res = _mapper.Map<OrderEntity>(inModel);

            res.Price = food.Price * inModel.FoodCount;

            await _unitOfWork.OrderRepository.InsertAsync(res);

            await _unitOfWork.SaveAsync();

            return Ok("Order Is added");

        }

        [HttpPut]
        public async Task<ActionResult<OrderViewModel>> Put([FromBody] OrderViewModel inModel, Guid ID)
        {
            if (inModel.ID == ID)
            {
                var food = await _unitOfWork.FoodRepository.GetByIdAsync(inModel.FoodID);

                var res = _mapper.Map<OrderEntity>(inModel);

                res.Price = food.Price * inModel.FoodCount;

                await _unitOfWork.OrderRepository.UpdateAsync(res);

                await _unitOfWork.SaveAsync();

                return Ok("Order Is Updated");
            }
            else
            {
                return BadRequest("You send Wrind Date to server");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderViewModel>> Delete([FromBody] Guid id)
        {
            if (id != Guid.Empty)
            {
                var r = await _unitOfWork.OrderRepository.GetByIdAsync(id);
                await _unitOfWork.OrderRepository.DeleteAsync(r);
                await _unitOfWork.SaveAsync();
                return Ok("User is Removed");
            }
            return BadRequest("Send Correct ID");
        }

    }
}
