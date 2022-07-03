namespace IntoOOP.Bank.UI;

/// <summary>
/// Делегат метода создания экрана счета.
/// </summary>
/// <param name="account">Счет.</param>
/// <param name="button">Кнопка созданного счета.</param>
/// <returns>Следующий экран.</returns>
public delegate UIScreen BuildAccountScreenDelegate(Account account, UIButton button);

/// <summary>
/// Класс строителя экранов пользовательского интерфейса.
/// </summary>
public class ScreenBuilder
{
    /// <summary>
    /// Заголовок приложения.
    /// </summary>
    private UIText _header = new UIText().Add($"--------------- << {Server.BANK_NAME} >> ---------------");

    /// <summary>
    /// Новый экран.
    /// </summary>
    private UIScreen _screen;

    /// <summary>
    /// Конструктор класса строителя экранов.
    /// </summary>
    /// <param name="label">Инструкция для пользователя.</param>
    public ScreenBuilder(string label) => _screen = new UIScreen(GetText(label), _header);

    /// <summary>
    /// Конструктор класса строителя экранов.
    /// </summary>
    /// <param name="account">Счет, отображаемый на экране.</param>
    public ScreenBuilder(Account account) => _screen = new UIScreen(GetAccountText(account), _header);

    /// <summary>
    /// Возвращает готовый экран.
    /// </summary>
    /// <returns>Новый экран.</returns>
    public UIScreen Build() => _screen;

    /// <summary>
    /// Добавление кнопки возврата.
    /// </summary>
    /// <param name="previousScreen">Экран для возврата.</param>
    /// <param name="paddingTop">Внутренний отступ сверху.</param>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddBackButton(UIScreen previousScreen, int paddingTop = 0)
    {
        _screen.Add(GetButton("Назад", 0, paddingTop).SetOnClick(delegate ()
        {
            previousScreen.Message.SetText(string.Empty); ;
            return previousScreen;
        }));
        return this;
    }

    /// <summary>
    /// Добавление кнопки закрытия счета.
    /// </summary>
    /// <param name="account">Счет для закрытия.</param>
    /// <param name="mainScreen">Главный экран.</param>
    /// <param name="button">Кнопка счета на главном экране.</param>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddCloseAccountButton(Account account, UIScreen mainScreen, UIButton button)
    {
        _screen.Add(GetButtonWithIndent("Закрыть счет").SetOnClick(delegate ()
        {
            try
            {
                Server.CloseAccount(account);
            }
            catch (Exception ex)
            {
                _screen.Message.SetText(ex.Message);
                return _screen;
            }

            mainScreen.Remove(button);
            if (Server.Accounts.Length == 0)
                mainScreen.PostMessage.SetText("У Вас нет текущих счетов.");
            mainScreen.Message.SetText(string.Empty);
            return mainScreen;
        }));
        return this;
    }

    /// <summary>
    /// Добавление кнопок типов счета.
    /// </summary>
    /// <param name="mainScreen">Главный экран.</param>
    /// <param name="buildAccountScreen">Метод создания экрана счета.</param>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddAccountTypesButtons(UIScreen mainScreen, BuildAccountScreenDelegate buildAccountScreen)
    {
        var accountTypes = Enum.GetValues<AccountType>();
        foreach (var type in accountTypes)
        {
            var button = GetAccountTypeButton(type);
            _screen.Add(button.SetOnClick(delegate ()
            {
                try
                {
                    var account = Server.OpenAccount(type);
                    var button = GetAccountButton(account);
                    button.OnClick = delegate () { return buildAccountScreen(account, button); };
                    mainScreen.Add(button, mainScreen.Amount - 2);
                    mainScreen.PostMessage.SetText(string.Empty);
                    return mainScreen;
                }
                catch (Exception ex)
                {
                    _screen.Message.SetText(ex.Message);
                    return _screen;
                }
            }));
        }
        return this;
    }

    /// <summary>
    /// Добавление кнопок для текущих счетов.
    /// </summary>
    /// <param name="buildAccountScreen">Метод создания экрана счета.</param>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddAccountsButtons(BuildAccountScreenDelegate buildAccountScreen)
    {
        foreach (var account in Server.Accounts)
        {
            var accountButton = GetAccountButton(account);
            accountButton.OnClick = delegate () { return buildAccountScreen(account, accountButton); };
            _screen.Add(accountButton);
        }
        return this;
    }

    /// <summary>
    /// Кнопка открытия нового счета.
    /// </summary>
    /// <param name="newAccountScreen">Экран счета.</param>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddOpenAccountButton(UIScreen newAccountScreen)
    {
        _screen.Add(GetLineButton("Открыть новый счет").SetOnClick(delegate ()
        {
            newAccountScreen.Message.SetText(string.Empty);
            return newAccountScreen;
        }));
        return this;
    }

    /// <summary>
    /// Добавление кнопки выхода из приложения.
    /// </summary>
    /// <returns>Текущий экземпляр класса строителя.</returns>
    public ScreenBuilder AddExitButton()
    {
        _screen.Add(GetButton("Выход").SetOnClick(delegate () { return UIScreen.Exit; }));
        return this;
    }

    /// <summary>
    /// Создание текста информации о счете.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <returns>Текст с информацией о счете.</returns>
    private static UIText GetAccountText(Account account) =>
        GetText(account.ToString()).Add(account.DisplayBalance, account.Balance > 0 ? ConsoleColor.Green : ConsoleColor.White);

    /// <summary>
    /// Создание текста для вывода на консоль.
    /// </summary>
    /// <param name="text">Строка для вывода.</param>
    /// <returns>Текст для вывода в консоль.</returns>
    private static UIText GetText(string text) => new UIText().Add(text);

    /// <summary>
    /// Создание кнопки с левым отступом.
    /// </summary>
    /// <param name="text">Текст кнопки.</param>
    /// <returns>Кнопка с левым отступом.</returns>
    private static UIButton GetButtonWithIndent(string text) => GetButton(text, 4);

    /// <summary>
    /// Создание кнопки с верхним отступом.
    /// </summary>
    /// <param name="text">Текст кнопки.</param>
    /// <returns>Кнопка с верхним отступом.</returns>
    private static UIButton GetLineButton(string text) => GetButton(text, 0, 1);

    /// <summary>
    /// Создание кнопки.
    /// </summary>
    /// <param name="text">Текст кнопки.</param>
    /// <param name="paddingLeft">Левый отступ.</param>
    /// <param name="paddingTop">Верхний отступ.</param>
    /// <returns>Новая кнопка</returns>
    private static UIButton GetButton(string text, int paddingLeft = 0, int paddingTop = 0) =>
        new UIButton(new UIText().Add(text), paddingLeft, paddingTop);

    /// <summary>
    /// Создание кнопки счета.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <returns>Новая кнопка счета.</returns>
    private static UIButton GetAccountButton(Account account) => new UIButton(GetAccountText(account), 4);

    /// <summary>
    /// Создание кнопки типа счета.
    /// </summary>
    /// <param name="type">Тип счета.</param>
    /// <returns>Новая кнопка типа счета.</returns>
    private static UIButton GetAccountTypeButton(AccountType type) =>
        new UIButton(GetText(Account.GetDisplayAccountType(type)), 4);
}
