using Cargo.Application.Contracts.Percistance;
using MediatR;

namespace Cargo.Application.Features.Branch.Queries.GetBranches
{
    public class GetBranchesCommandHandler : IRequestHandler<GetBranchesCommand, List<BranchListDto>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchesCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<BranchListDto>> Handle(GetBranchesCommand request, CancellationToken cancellationToken)
        {
            var list = await _branchRepository.GetAllAsync();
            var dtoList = list.Select(x => new BranchListDto
            {
                Id = x.Id,
                Address = x.Address,
                Name = x.Name,
            }).ToList();

            return dtoList;
        }
    }
}
