using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("bo'sh bo'lmasin")
            .Length(2, 20).WithMessage("2 yoki 20 ta harfdan iborat bo'lsin");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("bo'sh bo'lmasin")
            .Length(2, 20).WithMessage("2 yoki 20 ta harfdan iborat bo'lsin");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email kiriting");
        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("tanglang");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parolni kiriting")
            .Length(8, 16).WithMessage("Parol 8 va 16 belgidan iborat bo'lsinit");
    }
}
