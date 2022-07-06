namespace IntoOOP.Bank.Tests;

public class AccountTestCase
{
    public Account Account { get; set; }

    public Account DestAccount { get; set; }

    public decimal DepositAmount { get; set; }

    public decimal WithdrawAmount { get; set; }

    public decimal TransferAmount { get; set; }

    public bool ExpectedArgumentException { get; set; }
}
