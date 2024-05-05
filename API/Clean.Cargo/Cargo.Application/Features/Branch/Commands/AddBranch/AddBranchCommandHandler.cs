using Cargo.Application.Contracts.Percistance;
using Cargo.Application.Exceptions;
using MediatR;

namespace Cargo.Application.Features.Branch.Commands.AddBranch
{
    public class AddBranchCommandHandler : IRequestHandler<AddBranchCommand, Guid>
    {
        private readonly IBranchRepository _branchRepository;

        public AddBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<Guid> Handle(AddBranchCommand request, CancellationToken cancellationToken)
        {

            var validation = new AddBranchCommandValidator();

            var validationResult = await validation.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var branch = new Domain.Branch
            {
                Address = request.Address,
                Name = request.Name
            };

            await _branchRepository.AddAsync(branch);
            await _branchRepository.SaveChangesAsync();

            return branch.Id;

        }
    }
}
