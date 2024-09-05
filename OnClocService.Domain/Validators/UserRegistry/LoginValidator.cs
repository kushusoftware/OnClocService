#nullable disable

using FluentValidation;
using OnClocService.Domain.Requests.UserRegistry;

namespace OnClocService.Domain.Validators.UserRegistry;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}
