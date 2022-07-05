using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Класс, формирующий экран счета.
/// </summary>
public class AccountScreenDirector : ScreenBuilder
{
    /// <summary>
    /// Конструктор класса, формирующего экран счета.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="mainScreen">Главный экран приложения.</param>
    public AccountScreenDirector(Account account, UIScreen mainScreen) : base(account)
    {
        AddOperationButton(account, _screen, "Внести на счет", account.Deposit);
        AddOperationButton(account, _screen, "Снять со счета", account.Withdraw);
        AddCloseAccountButton(account, mainScreen);
        AddBackButton(mainScreen, new Point(0, 1));
    }
}
