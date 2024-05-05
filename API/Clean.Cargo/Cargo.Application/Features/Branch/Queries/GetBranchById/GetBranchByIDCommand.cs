using MediatR;

namespace Cargo.Application.Features.Branch.Queries.GetBranch
{
    public class GetBranchByIDCommand :IRequest<GetBranchByIdDTO>
    {
        public GetBranchByIDCommand(Guid ıd)
        {
            Id = ıd;
        }

        public Guid Id { get; set; }
    }
}
