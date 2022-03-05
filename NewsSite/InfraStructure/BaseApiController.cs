using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ResturantProject.InfraStructure
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors(policyName: Startup.Other_Cors)]
    [Microsoft.AspNetCore.Mvc.Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class BaseApiController : ControllerBase
    {
        protected IUnitOfWork _unitOfWork { get; }
        protected readonly IMapper _mapper;
        public BaseApiController(IUnitOfWork unitOfWork, IMapper mapper) : base()
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
    }
}
