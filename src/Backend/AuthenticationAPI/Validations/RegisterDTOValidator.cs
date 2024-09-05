using FluentValidation;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Validators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.");

            RuleFor(x => x.Firstname)
                .NotEmpty().WithMessage("Firstname is required.");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("Lastname is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one symbol.");
        }
    }
}
