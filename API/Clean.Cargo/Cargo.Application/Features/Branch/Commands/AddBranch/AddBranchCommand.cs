using MediatR;
using System.Windows.Input;

namespace Cargo.Application.Features.Branch.Commands.AddBranch
{
    public class AddBranchCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
