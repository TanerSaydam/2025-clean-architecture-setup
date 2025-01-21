namespace CleanArhictecture_2025.Domain.Employees;

public sealed record Address
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Town { get; set; }
    public string? FulLAddress { get; set; }
}

