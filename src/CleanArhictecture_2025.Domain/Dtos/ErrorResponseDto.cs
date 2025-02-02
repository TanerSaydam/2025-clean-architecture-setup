using System.Text.Json.Serialization;

namespace CleanArhictecture_2025.Domain.Dtos;

public sealed class ErrorResponseDto
{
    [JsonPropertyName("error")]
    public string Field { get; set; } = default!;
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; } = default!;
}