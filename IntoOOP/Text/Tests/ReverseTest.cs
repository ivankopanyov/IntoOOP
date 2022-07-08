namespace IntoOOP.Text.Tests;

public class ReverseTest
{
    private ReverseTestCase[] testCases = new ReverseTestCase[]
    {
        new ReverseTestCase()
        {
            Str = null,
            ExceptedStr = null
        },
        new ReverseTestCase()
        {
            Str = string.Empty,
            ExceptedStr = string.Empty
        },
        new ReverseTestCase()
        {
            Str = "A",
            ExceptedStr = "A"
        },
        new ReverseTestCase()
        {
            Str = "Lorem ipsum dolor sit amet.",
            ExceptedStr = ".tema tis rolod muspi meroL"
        },
        new ReverseTestCase()
        {
            Str = "олололо",
            ExceptedStr = "олололо"
        }
    };

    public void TestProcess(ReverseTestCase testCase)
    {
        var reverseResult = TextHandler.Reverse(testCase.Str);
        var testResult = testCase.ExceptedStr == reverseResult;

        Console.WriteLine($"ExceptedStr: {testCase.ExceptedStr}, Result: {reverseResult}\n" + (testResult ? "OK!" : "BAD!"));
        Console.WriteLine(testResult ? "VALID TEST!\n" : "INVALID TEST!\n");
    }

    public void DoProcess()
    {
        foreach (var testCase in testCases)
            TestProcess(testCase);
    }
}
