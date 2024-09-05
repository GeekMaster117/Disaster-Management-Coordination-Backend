using FluentValidation;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[`=;',.//~!@#$%^&*()_+{}:<>?]").WithMessage("Password must contain any special character")
                .Matches(@"[\s\S]").WithMessage("Password cannot contain whitespace characters.");
        }
    }
}
