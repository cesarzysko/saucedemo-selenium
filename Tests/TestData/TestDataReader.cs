namespace Tests.TestData;

using System.Text.Json;

public static class TestDataReader
{
    public static TestData Data { get; } = Load();

    private static TestData Load()
    {
        string jsonTestData = File.ReadAllText("testdata.json");
        return JsonSerializer.Deserialize<TestData>(jsonTestData)
               ?? throw new InvalidOperationException("Failed to deserialize test data.");
    }
}
