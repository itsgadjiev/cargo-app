using FluentValidation;

namespace Cargo.Application.Features.Branch.Commands.AddBranch
{
    public class AddBranchCommandValidator : AbstractValidator<AddBranchCommand>
    {
        public AddBranchCommandValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
        }
    }
}
