using Cargo.Application.Contracts.Percistance;
using Cargo.Application.Exceptions;
using MediatR;

namespace Cargo.Application.Features.Branch.Queries.GetBranch
{
    public class GetBranchByIDCommandHandler : IRequestHandler<GetBranchByIDCommand, GetBranchByIdDTO>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchByIDCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<GetBranchByIdDTO> Handle(GetBranchByIDCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id);
            if (branch == null)
                throw new NotFoundException(nameof(Domain.Branch), "Branch Not Found");

            var branchDto = new GetBranchByIdDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
            };

            return branchDto;
        }
    }
}
