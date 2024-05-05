using Cargo.Application.Contracts.Percistance;
using Cargo.Application.Exceptions;
using MediatR;

namespace Cargo.Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
    {
        private readonly IBranchRepository _branchRepository;

        public UpdateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id);

            if (branch == null)
                throw new NotFoundException(nameof(branch), "branch not found");

            var validation = new UpdateBranchCommandValidator();
            var validationResult = await validation.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new CustomValidationException(validationResult.Errors);


            branch.Name = request.Name;
            branch.Address = request.Adress;

            await _branchRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
