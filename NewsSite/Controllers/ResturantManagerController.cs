using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Http;
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
    public class ResturantManagerController : BaseApiController
    {
        public ResturantManagerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        [HttpGet]
        public async Task<ActionResult<FoodViewModel>> Get()
        {

            var result = _unitOfWork.FoodRepository.GetAll();

            var res = _mapper.Map<List<FoodViewModel>>(result);

            return Ok(res);

        }



        //Delegate is Here
        [HttpPost]
        public async Task<ActionResult<FoodViewModel>> Post([FromBody] FoodViewModel inModel)
        {

            var res = _mapper.Map<FoodEntity>(inModel);

            await _unitOfWork.FoodRepository.DelegateAdd(res);

            //await _unitOfWork.FoodRepository.InsertAsync(res);

            await _unitOfWork.SaveAsync();

            return Ok("Food Is added");

        }

        [HttpPut]
        public async Task<ActionResult<FoodViewModel>> Put([FromBody] FoodViewModel inModel, Guid ID)
        {

            if (inModel.ID == ID)
            {
                var res = _mapper.Map<FoodEntity>(inModel);

                await _unitOfWork.FoodRepository.UpdateAsync(res);

                await _unitOfWork.SaveAsync();

                return Ok("Food Is Updated");
            }
            else
            {
                return BadRequest("You send Wrind Date to server");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodViewModel>> Delete([FromBody] Guid id)
        {
            if (id != Guid.Empty)
            {

                var r = await _unitOfWork.FoodRepository.GetByIdAsync(id);
                await _unitOfWork.FoodRepository.DeleteAsync(r);
                await _unitOfWork.SaveAsync();
                return Ok("Food is Removed");
            }
            return BadRequest("Send Correct ID");
        }

    }
}
