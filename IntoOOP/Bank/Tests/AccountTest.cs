namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                IterationsNumber = 1,
                Balance = 0,
                AccountType = AccountType.Credit,
            },

            new AccountTestCase()
            {
                IterationsNumber = 1,
                Balance = -100.10m,
                AccountType = AccountType.Deposit,
            },

            new AccountTestCase()
            {
                IterationsNumber = 2,
                ExpectedArgumentException = true
            }

        };

        public void TestProcess(AccountTestCase testCase)
        {
            var properties = typeof(AccountTestCase).GetProperties();
            foreach (var property in properties)
                Console.WriteLine(property.Name + " = " + property.GetValue(testCase));
            
            bool result = true;

            var accounts = new Account[] { new Account(), new Account() };

            foreach (var account in accounts)
            {

                for (int i = 0; i < testCase.IterationsNumber; i++)
                {
                    try
                    {
                        account.InitNumber();
                    }
                    catch (ArgumentException)
                    {
                        result = testCase.ExpectedArgumentException;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                    account.SetBalance(testCase.Balance);
                    if (testCase.Balance != account.GetBalance()) result = false;
                    account.SetAccountType(testCase.AccountType);
                    if (testCase.AccountType != account.GetAccountType()) result = false;
                }
            }

            if (accounts[0].GetNumber() == accounts[1].GetNumber()) 
                result =  false; 

            Console.WriteLine("\nRESULT: " + (result ? "VALID TEST" : "INVALID TEST") + '\n');
        }

        public void DoProcess()
        {
            foreach (var testCase in testCases)
                TestProcess(testCase);
        }
    }
}
