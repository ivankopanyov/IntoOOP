using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Класс, формирующий главный экран приложения.
/// </summary>
public class MainScreenDirector : ScreenBuilder
{
    /// <summary>
    /// Конструктор класса, формирующего главный экран приложения.
    /// </summary>
    /// <param name="newAccountScreen">Ссылка на переменную, хранящую экран открытия счета.</param>
    public MainScreenDirector() : base("Текущие счета:")
    {
       if (Server.Accounts.Length == 0)
            _screen.PostMessage.SetText("У Вас нет текущих счетов.");

        AddAccountsButtons(delegate (Account account, UIButton accountButton) 
        {
            return new AccountScreenDirector(account, _screen).Build(); ;
        });
        AddOpenAccountButton(new NewAccountScreenDirector(_screen).Build());
        AddExitButton();
    }
}
