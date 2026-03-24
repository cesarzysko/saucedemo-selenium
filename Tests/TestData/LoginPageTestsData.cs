namespace Tests.TestData;

public static class LoginPageTestsData
{
    private static readonly TestData _data = TestDataReader.Data;
    private static readonly string _validPassword = _data.ValidPassword;
    private static readonly IReadOnlyList<string> _anyPasswords = _data.InvalidPasswords.Concat([_validPassword]).ToList();
    private static readonly IReadOnlyList<string> _validUsernames = _data.ValidUsernames;
    private static readonly IReadOnlyList<string> _anyUsernames = _validUsernames.Concat(_data.InvalidUsernames).ToList();

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
        return [username, _validPassword];
    }

    private static object[][] CreateAnyCredentials(string username)
    {
        return _anyPasswords.Select(password => (object[])[username, password]).ToArray();
    }
}
