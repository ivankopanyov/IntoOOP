namespace IntoOOP.Bank.Tests
{
    public class AccountTest
    {
        private AccountTestCase[] testCases = new AccountTestCase[]
        {
            new AccountTestCase()
            {
                Account = new Account(),
                DestAccount = new Account(),
                DepositAmount = 500,
                WithdrawAmount = 400,
                TransferAmount = 100,
                ExpectedArgumentException = true
            },
            new AccountTestCase()
            {
                Account = new Account(),
                DestAccount = new Account(),
                DepositAmount = -100,
                ExpectedArgumentException = true
            },
            new AccountTestCase()
            {
                Account = new Account(),
                DestAccount = new Account(),
                WithdrawAmount = 100,
                ExpectedArgumentException = true
            },
            new AccountTestCase()
            {
                Account = new Account(),
                DestAccount = new Account(),
                TransferAmount = 100,
                ExpectedArgumentException = true
            }
        };

        public void TestProcess(AccountTestCase testCase)
        {
            Console.WriteLine("------------ NEW TEST --------------\n");

            if (testCase.Account == null)
            {
                Console.WriteLine("Account is null\n");
                return;
            }
            
            if (testCase.DestAccount == null)
            {
                Console.WriteLine("DestAccount is null");
                return;
            }

            var properties = typeof(AccountTestCase).GetProperties();
            foreach (var property in properties)
            {
                Console.Write(property.Name + " = " + property.GetValue(testCase));
                if (property.PropertyType == typeof(Account) && property.GetValue(testCase) != null)
                    Console.Write(", Баланс = " + ((Account)property.GetValue(testCase)).DisplayBalance);
                Console.WriteLine();
            }
            Console.WriteLine('\n');

            bool result = true;

            var balanceAccount = testCase.Account.Balance;
            var balanceDestAccount = testCase.DestAccount.Balance;

            try
            {
                Console.WriteLine($"Account.Deposit({testCase.DepositAmount});");
                testCase.Account.Deposit(testCase.DepositAmount);
                Console.WriteLine($"Account.Balance = {testCase.Account.Balance};");
                if (testCase.Account.Balance != balanceAccount + testCase.DepositAmount)
                {
                    Console.WriteLine("BAD!\n");
                    result = false;
                }
                else Console.WriteLine("OK!\n");

                Console.WriteLine($"Account.Withdraw({testCase.WithdrawAmount});");
                testCase.Account.Withdraw(testCase.WithdrawAmount);
                Console.WriteLine($"Account.Balance = {testCase.Account.Balance};");
                if (testCase.Account.Balance != balanceAccount + testCase.DepositAmount - testCase.WithdrawAmount)
                {
                    Console.WriteLine("BAD!\n");
                    result = false;
                }
                else Console.WriteLine("OK!\n");

                Console.WriteLine($"Account.Transfer(DestAccount, {testCase.TransferAmount});");
                testCase.Account.Transfer(testCase.DestAccount, testCase.TransferAmount);

                Console.WriteLine($"\nAccount.Balance = {testCase.Account.Balance};");
                if (testCase.Account.Balance != balanceAccount + testCase.DepositAmount - testCase.WithdrawAmount - testCase.TransferAmount)
                {
                    Console.WriteLine("BAD!\n");
                    result = false;
                }
                else Console.WriteLine("OK!\n");

                Console.WriteLine($"DestAccount.Balance = {testCase.DestAccount.Balance};");
                if (testCase.DestAccount.Balance != balanceDestAccount + testCase.TransferAmount)
                {
                    Console.WriteLine("BAD!\n");
                    result = false;
                }
                else Console.WriteLine("OK!\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                if (!testCase.ExpectedArgumentException)
                {
                    Console.WriteLine("\nBAD!\n");
                    result = false;
                }
                else Console.WriteLine("\nOK!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nBAD!\n");
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
