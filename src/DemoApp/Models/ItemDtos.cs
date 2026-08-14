namespace DemoApp.Models;

public record ItemCreateDto(string Name, string? Description);

public record ItemUpdateDto(string Name, string? Description);
