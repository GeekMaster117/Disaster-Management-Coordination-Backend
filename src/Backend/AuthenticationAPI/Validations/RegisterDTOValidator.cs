using FluentValidation;
using DisasterManager.Models;

namespace DisasterManager.Validators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.")
                .Matches(@"^\S*$").WithMessage("Username cannot contain any whitespace");

            RuleFor(x => x.Firstname)
                .NotEmpty().WithMessage("Firstname is required.")
                .Matches(@"^[a-zA-Z]+$").WithMessage("Firstname can only contain letters");


            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("Lastname is required.")
                .Matches(@"^[a-zA-Z]+$").WithMessage("Lastname can only contain letters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[`=;',.//~!@#$%^&*()_+{}:<>?]").WithMessage("Password must contain any special character");
        }
    }
}
