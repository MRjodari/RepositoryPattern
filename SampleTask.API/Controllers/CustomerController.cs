using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleTask.Application.CQRS.Commands;
using SampleTask.Application.CQRS.Queries;
using SampleTask.Application.Interfaces.Repos;
using Swashbuckle.AspNetCore.Annotations;

namespace SampleTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController :ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork
            , IMediator mediator , IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
      Summary = "Save a User",
      Description = "Save a User with Details",
      OperationId = "User.Add",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> AddUser([FromBody] SaveCustomerCommand saveCustomerCommand)
        {
            
            var result = await _mediator.Send(saveCustomerCommand);
            return Ok(result);
        }

        [HttpGet("Id")]
        [SwaggerOperation(
      Summary = "Get a User",
      Description = "Get a User with id",
      OperationId = "User.GetById",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> Get([FromQuery] GetCustomerQuery getProductQuery)
        {
            return Ok(await _mediator.Send(getProductQuery));
        }

        [HttpGet]
        [SwaggerOperation(
      Summary = "Get All Users",
      Description = "Get All Users with base details",
      OperationId = "User.GetAll",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await _mediator.Send(new GetCustomerListQuery());
            return Ok(result);
        }
    }
}
