using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Класс, формирующий экран для операций со счетом.
/// </summary>
public class OperationScreenDirector : ScreenBuilder
{
    /// <summary>
    /// Конструктор класса, формирующего экран для операций со счетом.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    /// <param name="accountOperation">Метод операции.</param>
    /// <param name="buttonLabel">Имя кноки.</param>
    public OperationScreenDirector(Account account, UIScreen accountScreen, AccountOperation accountOperation, string buttonLabel) : base(account)
    {
        var inputField = AddAmountField();
        AddOperationButton(account, accountScreen, buttonLabel, inputField, accountOperation);
        AddBackButton(accountScreen);
    }
}
