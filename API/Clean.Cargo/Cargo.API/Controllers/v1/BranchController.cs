using Asp.Versioning;
using Cargo.Application.Features.Branch.Commands.AddBranch;
using Cargo.Application.Features.Branch.Queries.GetBranch;
using Cargo.Application.Features.Branch.Queries.GetBranches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new GetBranchesCommand()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_mediator.Send(new GetBranchByIDCommand(id)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost("add")]
        public IActionResult Post(AddBranchCommand addBranchCommand)
        {
            return Ok(_mediator.Send(addBranchCommand));
        }
    }
}
