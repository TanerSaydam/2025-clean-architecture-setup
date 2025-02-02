using CleanArhictecture_2025.Domain.Users;

namespace CleanArhictecture_2025.Application.Services;
public interface IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user, CancellationToken cancellationToken = default);
}
