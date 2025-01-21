using CleanArhictecture_2025.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using TS.Result;

namespace CleanArhictecture_2025.Application.Employees;
public sealed record EmployeeCreateCommand(
    string FirstName,
    string LastName,
    DateOnly BirthOfDate,
    decimal Salary,
    PersonelInformation PersonelInformation,
    Address? Address) : IRequest<Result<string>>;

public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
    {
        RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır");
        RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır");
        RuleFor(x => x.PersonelInformation.TCNo)
            .MinimumLength(11).WithMessage("Geçerli bir TC Numarası yazın")
            .MaximumLength(11).WithMessage("Geçerli bir TC Numarası yazın");
    }
}

internal sealed class EmployeeCreateCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {
        var isEmployeeExists = await employeeRepository.AnyAsync(p => p.PersonelInformation.TCNo == request.PersonelInformation.TCNo, cancellationToken);

        if (isEmployeeExists)
        {
            return Result<string>.Failure("Bu TC numarası daha önce kaydedilmiş");
        }

        Employee employee = request.Adapt<Employee>();

        employeeRepository.Add(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel kaydı başarıyla tamamlandı";
    }
}
