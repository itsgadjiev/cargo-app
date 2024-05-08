using Asp.Versioning;
using Cargo.Application.Features.Branch.Commands.AddBranch;
using Cargo.Application.Features.Branch.Commands.RemoveBranch;
using Cargo.Application.Features.Branch.Commands.UpdateBranch;
using Cargo.Application.Features.Branch.Queries.GetBranchById;
using Cargo.Application.Features.Branch.Queries.GetBranches;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var branches = await _mediator.Send(new GetBranchesQuery());
            return Ok(branches);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetBranchByIDCommand(id)));
        }

        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost("add")]
        public async Task<IActionResult> Post(AddBranchCommand addBranchCommand)
        {
            return Ok(await _mediator.Send(addBranchCommand));
        }

        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateBranchCommand updateBranchCommand)
        {
            await _mediator.Send(updateBranchCommand);
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(RemoveBranchCommand removeBranchCommand)
        {
            await _mediator.Send(removeBranchCommand);
            return NoContent();
        }
    }
}
