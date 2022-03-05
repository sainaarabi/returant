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
    public class UserController : BaseApiController
    {
        public UserController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> Get()
        {

            var result = _unitOfWork.UserRepository.GetAll();

            var res = _mapper.Map<List<UserViewModel>>(result);

            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Post([FromBody] UserViewModel inModel)
        {

            var res = _mapper.Map<UserEntity>(inModel);

            await _unitOfWork.UserRepository.InsertAsync(res);

            await _unitOfWork.SaveAsync();

            return Ok("User Is added");

        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> Put([FromBody] UserViewModel inModel, Guid ID)
        {

            if (inModel.ID == ID)
            {
                var res = _mapper.Map<UserEntity>(inModel);

                await _unitOfWork.UserRepository.UpdateAsync(res);

                await _unitOfWork.SaveAsync();

                return Ok("User Is Updated");
            }
            else
            {
                return BadRequest("You send Wrind Date to server");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserViewModel>> Delete([FromBody] Guid id)
        {
            if (id != Guid.Empty)
            {

                var r = await _unitOfWork.UserRepository.GetByIdAsync(id);
                await _unitOfWork.UserRepository.DeleteAsync(r);
                await _unitOfWork.SaveAsync();
                return Ok("User is Removed");
            }
            return BadRequest("Send Correct ID");
        }

    }
}
