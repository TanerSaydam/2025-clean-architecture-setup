using CleanArhictecture_2025.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArhictecture_2025.Infrastructure.Configurations;
internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.OwnsOne(p => p.PersonelInformation, builder =>
        {
            builder.Property(i => i.TCNo).HasColumnName("TCNO");
            builder.Property(i => i.Phone1).HasColumnName("Phone1");
            builder.Property(i => i.Phone2).HasColumnName("Phone2");
            builder.Property(i => i.Email).HasColumnName("Email");
        });

        builder.OwnsOne(p => p.Address, builder =>
        {
            builder.Property(i => i.Country).HasColumnName("Country");
            builder.Property(i => i.City).HasColumnName("City");
            builder.Property(i => i.Town).HasColumnName("Town");
            builder.Property(i => i.FulLAddress).HasColumnName("FulLAddress");
        });

        builder.Property(p => p.Salary).HasColumnType("money");
    }
}
