namespace Tests.TestData;

public sealed class TestData
{
    public IReadOnlyList<string> ValidUsernames { get; init; } = [];
    public IReadOnlyList<string> InvalidUsernames { get; init; } = [];
    public string ValidPassword { get; init; } = string.Empty;
    public IReadOnlyList<string> InvalidPasswords { get; init; } = [];
}
