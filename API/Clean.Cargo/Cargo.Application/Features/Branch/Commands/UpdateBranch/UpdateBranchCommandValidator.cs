using Cargo.Application.Features.Branch.Commands.UpdateBranch;
using FluentValidation;

namespace Cargo.Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchCommandValidator()
        {
            RuleFor(x => x.Adress)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
        }
    }
}
