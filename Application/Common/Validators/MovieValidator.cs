using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Titleni kiriting");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("kino haqida ma'lumotni kiriting");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Davlatni kirirng")
            .Length(5, 20).WithMessage("davlat 5 va 20 ta harfdan iborat bo'lsin");
        RuleFor(x => x.Duration)
            .NotEmpty().WithMessage("Davomiylikni kiriting");
        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("Yilni kiriting")
            .GreaterThan(1900).WithMessage("1900 - yildan keyingi yilni kiritng");
        RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Kompaniyani kiriting")
            .Length(3, 30).WithMessage("Kompaniya nomi 3 va 30 ta belgidan iborat bo'lsin");
        RuleFor(x => x.Director)
            .NotEmpty().WithMessage("Direktorni kiriting")
            .Length(3, 30).WithMessage("Direktor 3 va 30 ta belgidan iborat bo'lsin");
        RuleFor(x => x.Genre)
            .NotEmpty().WithMessage("Janrni kiriting");
    }
}
