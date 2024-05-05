using MediatR;

namespace Cargo.Application.Features.Branch.Queries.GetBranches
{
    public class GetBranchesQuery : IRequest<List<BranchListDto>>
    {
    }
}
