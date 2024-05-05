using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommand :IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
