using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Класс, формирующий экран перевода средств.
/// </summary>
public class TransferScreenDirector : ScreenBuilder
{
    /// <summary>
    /// Конструктор класса, формирующего экран для перевода средств.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    public TransferScreenDirector(Account account, UIScreen accountScreen) : base(account)
    {
        if (Server.Accounts.Length <= 1)
            _screen.PostMessage.SetText("У Вас нет счетов для перевода");
        else
        {
            var inputField = AddAmountField();
            AddTransferButtons(account, accountScreen, inputField);
        }
        AddBackButton(accountScreen, new Point(0, 1));
    }
}
