namespace IntoOOP.Bank.Tests;

public class AccountTestCase
{
    public Account Account { get; set; }

    public decimal DepositAmount { get; set; }

    public decimal WithdrawAmount { get; set; }

    public bool ExpectedArgumentException { get; set; }
}
