namespace IntoOOP.Bank.Tests;

public class AccountEqualsTest
{
    private static Account _TestAccount = new Account(100, AccountType.Debit);

    private AccountEqualsTestCase[] testCases = new AccountEqualsTestCase[]
    {
        new AccountEqualsTestCase()
        {
            Account1 = new Account(1200, AccountType.Deposit),
            Account2 = new Account(1200, AccountType.Deposit),
            ExpectedEquals = true,
            ExpectedIdentical = false,
            ExpectedNotIdentical = true
        },

        new AccountEqualsTestCase()
        {
            Account1 = new Account(123, AccountType.Credit),
            Account2 = new Account(456, AccountType.Credit),
            ExpectedEquals = false,
            ExpectedIdentical = false,
            ExpectedNotIdentical = true
        },

        new AccountEqualsTestCase()
        {
            Account1 = _TestAccount,
            Account2 = _TestAccount,
            ExpectedEquals = true,
            ExpectedIdentical = true,
            ExpectedNotIdentical = false
        },

        new AccountEqualsTestCase()
        {
            Account1 = new Account(AccountType.Credit),
            Account2 = null!,
            ExpectedEquals = false,
            ExpectedIdentical = false,
            ExpectedNotIdentical = true
        },

        new AccountEqualsTestCase()
        {
            Account1 = null!,
            Account2 = null!,
            ExpectedEquals = false,
            ExpectedIdentical = false,
            ExpectedNotIdentical = true
        },
    };

    public void TestProcess(AccountEqualsTestCase testCase)
    {
        var properties = typeof(AccountEqualsTestCase).GetProperties();
        foreach (var property in properties)
            Console.WriteLine(property.Name + " = " + property.GetValue(testCase));

        bool result = true;

        if (testCase.Account1 is not null)
        {
            if (testCase.Account1.Equals(testCase.Account2) != testCase.ExpectedEquals)
            {
                result = false;
                Console.WriteLine("\nTest Account1.Equals(Account2) - BAD!");
            }
            else Console.WriteLine("\nTest Account1.Equals(Account2) - OK!");
        }
        else if (testCase.Account2 is not null)
        {
            if (testCase.Account2.Equals(testCase.Account1) != testCase.ExpectedEquals)
            {
                result = false;
                Console.WriteLine("\nTest Account2.Equals(Account1) - BAD!");
            }
            else Console.WriteLine("\nTest Account2.Equals(Account1) - OK!");
        }

        if ((testCase.Account1 == testCase.Account2) != testCase.ExpectedIdentical)
        {
            result = false;
            Console.WriteLine("\nTest Account1 == Account2 - BAD!");
        } 
        else Console.WriteLine("\nTest Account1 == Account2 - OK!");

        if ((testCase.Account1 != testCase.Account2) != testCase.ExpectedNotIdentical)
        {
            result = false;
            Console.WriteLine("\nTest Account1 != Account2 - BAD!");
        }
        else Console.WriteLine("\nTest Account1 != Account2 - OK!");

        Console.WriteLine("\nRESULT: " + (result ? "VALID TEST" : "INVALID TEST") + '\n');
    }

    public void DoProcess()
    {
        foreach (var testCase in testCases)
            TestProcess(testCase);
    }
}




