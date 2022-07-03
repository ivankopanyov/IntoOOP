namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                IterationsNumber = 1,
                Number = 10,
                Balance = 100,
                AccountType = AccountType.Debit,
                ExpectedArgumentException = false,
                ExpectedArgumentOutOfRangeException = false
            },

            new AccountTestCase()
            {
                IterationsNumber = 1,
                Number = 0,
                ExpectedArgumentOutOfRangeException = true
            },

            new AccountTestCase()
            {
                IterationsNumber = 2,
                Number = 100,
                ExpectedArgumentException = true
            }

        };

        public void TestProcess(AccountTestCase testCase)
        {
            var properties = typeof(AccountTestCase).GetProperties();
            foreach (var property in properties)
                Console.WriteLine(property.Name + " = " + property.GetValue(testCase));

            bool result = true;

            var account = new Account();

            for (int i = 0; i < testCase.IterationsNumber; i++)
            {
                try
                {
                    account.SetNumber(testCase.Number);
                }
                catch (ArgumentOutOfRangeException)
                {
                    result = testCase.ExpectedArgumentOutOfRangeException;
                }
                catch (ArgumentException)
                {
                    result = testCase.ExpectedArgumentException;
                }

                if (testCase.Number != account.GetNumber()) result = false;
                account.SetBalance(testCase.Balance);
                if (testCase.Balance != account.GetBalance()) result = false;
                account.SetAccountType(testCase.AccountType);
                if (testCase.AccountType != account.GetAccountType()) result = false;
            }
            Console.WriteLine("\nRESULT: " + (result ? "VALID TEST" : "INVALID TEST") + '\n');
        }

        public void DoProcess()
        {
            foreach (var testCase in testCases)
                TestProcess(testCase);
        }
    }
}
