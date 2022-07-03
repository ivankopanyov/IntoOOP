namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                Balance = 123_456.789m,
                AccountType = AccountType.Credit,
            },

            new AccountTestCase()
            {
                Balance = -0.01m,
                AccountType = AccountType.Deposit,
            },

            new AccountTestCase()
            {
                Balance = 101,
                AccountType = AccountType.Debit,
            }

        };

        public void TestProcess(AccountTestCase testCase)
        {
            var properties = typeof(AccountTestCase).GetProperties();
            foreach (var property in properties)
                Console.WriteLine(property.Name + " = " + property.GetValue(testCase));
            
            bool result = true;

            var account1 = new Account();
            if (account1.Balance != default(decimal)) result = false;
            if (account1.AccountType != default(AccountType)) result = false;

            var account2 = new Account(testCase.Balance);
            if (account2.Balance != testCase.Balance) result = false;
            if (account2.AccountType != default(AccountType)) result = false;
            if (account1.Number == account2.Number) result = false;

            var account3 = new Account(testCase.AccountType);
            if (account3.Balance != default(decimal)) result = false;
            if (account3.AccountType != testCase.AccountType) result = false;
            if (account2.Number == account3.Number) result = false;

            var account4 = new Account(testCase.Balance, testCase.AccountType);
            if (account4.Balance != testCase.Balance) result = false;
            if (account4.AccountType != testCase.AccountType) result = false;
            if (account3.Number == account4.Number) result = false;

            Console.WriteLine("\nRESULT: " + (result ? "VALID TEST" : "INVALID TEST") + '\n');
        }

        public void DoProcess()
        {
            foreach (var testCase in testCases)
                TestProcess(testCase);
        }
    }
}
