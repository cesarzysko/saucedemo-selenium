namespace Tests;

public static class LoginPageTestsData
{
    private const string ValidPassword = "secret_sauce";

    private static readonly IReadOnlyList<string> _invalidPasswords =
    [
        "invalid_password",
        new('x', ValidPassword.Length)
    ];

    private static readonly IReadOnlyList<string> _anyPasswords = _invalidPasswords.Concat([ValidPassword]).ToList();

    private static readonly IReadOnlyList<string> _validUsernames =
    [
        "standard_user",
        "locked_out_user",
        "problem_user",
        "performance_glitch_user",
        "error_user",
        "visual_user"
    ];

    private static readonly IReadOnlyList<string> _invalidUsernames =
    [
        "invalid_user",
        ValidPassword
    ];

    private static readonly IReadOnlyList<string> _anyUsernames = _validUsernames.Concat(_invalidUsernames).ToList();

    public static IEnumerable<object[]> GetValidCredentials()
    {
        return _validUsernames.Select(CreateValidCredentials);
    }

    public static IEnumerable<object[]> GetAnyCredentials()
    {
        return _anyUsernames.SelectMany(CreateAnyCredentials);
    }

    private static object[] CreateValidCredentials(string username)
    {
        return [username, ValidPassword];
    }

    private static object[][] CreateAnyCredentials(string username)
    {
        return _anyPasswords.Select(password => (object[])[username, password]).ToArray();
    }
}
