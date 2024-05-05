using MediatR;

namespace Cargo.Application.Features.Branch.Queries.GetBranches
{
    public class GetBranchesCommand : IRequest<List<BranchListDto>>
    {
    }
}
