using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequestDto>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Must(ContainUppercase).WithMessage("Password must contain at least one uppercase letter.")
            .Must(ContainNumber).WithMessage("Password must contain at least one number.")
            .Must(ContainSpecialCharacter).WithMessage("Password must contain at least one special character.");
        
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match");
        
        
    }
    private bool ContainUppercase(string password)
    {
        return password.Any(char.IsUpper);
    }

    private bool ContainNumber(string password)
    {
        return password.Any(char.IsDigit);
    }

    private bool ContainSpecialCharacter(string password)
    {
        return password.Any(ch => !char.IsLetterOrDigit(ch));
    }
}