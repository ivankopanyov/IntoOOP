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
        var result = TextHandler.Reverse(testCase.Str);
        if (result == testCase.ExceptedStr)
            Console.WriteLine($"{testCase.ExceptedStr} = {result}\nVALID TEST!\n");
        else
            Console.WriteLine($"{testCase.ExceptedStr} != {result}\nINVALID TEST!\n");
    }

    public void DoProcess()
    {
        foreach (var testCase in testCases)
            TestProcess(testCase);
    }
}
