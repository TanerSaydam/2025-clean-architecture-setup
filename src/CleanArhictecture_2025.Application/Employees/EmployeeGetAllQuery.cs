using CleanArhictecture_2025.Domain.Abstractions;
using CleanArhictecture_2025.Domain.Employees;
using MediatR;

namespace CleanArhictecture_2025.Application.Employees;
public sealed record EmployeeGetAllQuery() : IRequest<IQueryable<EmployeeGetAllQueryResponse>>;

public sealed class EmployeeGetAllQueryResponse : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly BirthOfDate { get; set; }
    public decimal Salary { get; set; }
    public string TCNo { get; set; } = default!;
}

internal sealed class EmployeeGetAllQueryHandler(
    IEmployeeRepository employeeRepository) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = employeeRepository.GetAll()
            .Select(s => new EmployeeGetAllQueryResponse
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Salary = s.Salary,
                BirthOfDate = s.BirthOfDate,
                CreateAt = s.CreateAt,
                DeleteAt = s.DeleteAt,
                Id = s.Id,
                IsDeleted = s.IsDeleted,
                TCNo = s.PersonelInformation.TCNo,
                UpdateAt = s.UpdateAt,
            })
            .AsQueryable();

        return Task.FromResult(response);
    }
}
