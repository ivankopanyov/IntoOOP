namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                Account = new Account(100),
                DepositAmount = 500,
                WithdrawAmount = 400
            },

            new AccountTestCase()
            {
                Account = new Account(),
                DepositAmount = 300
            },

            new AccountTestCase()
            {
                Account = new Account(500),
                WithdrawAmount = 500
            },

            new AccountTestCase()
            {
                Account = new Account(),
                WithdrawAmount = -100,
                ExpectedArgumentException = true
            },

            new AccountTestCase()
            {
                Account = new Account(),
                DepositAmount = -50,
                ExpectedArgumentException = true
            },

            new AccountTestCase()
            {
                Account = new Account(100),
                WithdrawAmount = 200,
                ExpectedArgumentException = true
            }
        };

        public void TestProcess(AccountTestCase testCase)
        {
            var properties = typeof(AccountTestCase).GetProperties();
            foreach (var property in properties)
                Console.WriteLine(property.Name + " = " + property.GetValue(testCase));
            
            bool result = true;

            var balance = testCase.Account.Balance;

            try
            {
                testCase.Account.Deposit(testCase.DepositAmount);
                if (testCase.Account.Balance != balance + testCase.DepositAmount) result = false;
                testCase.Account.Withdraw(testCase.WithdrawAmount);
                if (testCase.Account.Balance != 
                    balance + testCase.DepositAmount - testCase.WithdrawAmount) result = false;
            }
            catch (ArgumentException)
            {
                if (!testCase.ExpectedArgumentException) result = false;
            }
            catch
            {
                result = false;
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
