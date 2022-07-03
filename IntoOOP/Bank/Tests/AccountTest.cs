namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                Balance = 1_000_000,
                AccountType = AccountType.Credit,
            },

            new AccountTestCase()
            {
                Balance = -99_999_999.99m,
                AccountType = AccountType.Deposit,
            },

            new AccountTestCase()
            {
                Balance = 0,
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
            if (account1.GetBalance() != default(decimal)) result = false;
            if (account1.GetAccountType() != default(AccountType)) result = false;

            var account2 = new Account(testCase.Balance);
            if (account2.GetBalance() != testCase.Balance) result = false;
            if (account2.GetAccountType() != default(AccountType)) result = false;
            if (account1.GetNumber() == account2.GetNumber()) result = false;

            var account3 = new Account(testCase.AccountType);
            if (account3.GetBalance() != default(decimal)) result = false;
            if (account3.GetAccountType() != testCase.AccountType) result = false;
            if (account2.GetNumber() == account3.GetNumber()) result = false;

            var account4 = new Account(testCase.Balance, testCase.AccountType);
            if (account4.GetBalance() != testCase.Balance) result = false;
            if (account4.GetAccountType() != testCase.AccountType) result = false;
            if (account3.GetNumber() == account4.GetNumber()) result = false;

            Console.WriteLine("\nRESULT: " + (result ? "VALID TEST" : "INVALID TEST") + '\n');
        }

        public void DoProcess()
        {
            foreach (var testCase in testCases)
                TestProcess(testCase);
        }
    }
}
