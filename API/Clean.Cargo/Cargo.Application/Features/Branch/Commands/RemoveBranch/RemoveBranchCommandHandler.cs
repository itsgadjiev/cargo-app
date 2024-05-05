using Cargo.Application.Contracts.Percistance;
using Cargo.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Application.Features.Branch.Commands.RemoveBranch
{
    public class RemoveBranchCommandHandler : IRequestHandler<RemoveBranchCommand, Unit>
    {
        private readonly IBranchRepository _branchRepository;

        public RemoveBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<Unit> Handle(RemoveBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id);
            if (branch == null)
                throw new NotFoundException(nameof(branch), "branch not found");

            await _branchRepository.DeleteAsync(branch);
            await _branchRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
