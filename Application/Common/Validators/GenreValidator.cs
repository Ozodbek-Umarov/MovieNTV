using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Janr bo'sh bo'lmasin")
            .Length(4, 20).WithMessage("4 yoki 20 ta harfdan iborat bo'lsin");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("kino haqida ma'lumot kiriting");
    }
}
