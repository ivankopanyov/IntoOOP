using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Делегат методов, выполняемых при нажатии на кнопку счета.
/// </summary>
/// <param name="account">Счет.</param>
/// <param name="accountButton">Кнопка счета.</param>
/// <returns>Экран для перехода.</returns>
public delegate UIScreen OnClickAccountButton(Account account, UIButton accountButton);

/// <summary>
/// Делегат методов операций со счетом.
/// </summary>
/// <param name="amount">Колличество средств в операции.</param>
public delegate void AccountOperation(decimal amount);

/// <summary>
/// Класс строителя экранов пользовательского интерфейса.
/// </summary>
public class ScreenBuilder
{
    /// <summary>
    /// Словарь, хранящий лейблы счетов.
    /// </summary>
    private static Dictionary<Account, UIText> _labels = new();

    /// <summary>
    /// Заголовок приложения.
    /// </summary>
    protected string _header = $"--------------- << {Server.BANK_NAME} >> ---------------";

    /// <summary>
    /// Новый экран.
    /// </summary>
    protected UIScreen _screen;

    /// <summary>
    /// Конструктор класса строителя экранов.
    /// </summary>
    public ScreenBuilder()
    {
        _screen = new UIScreen();
        _screen.Header.SetText(_header);
        _screen.Message.SetColor(ConsoleColor.Red);
    }

    /// <summary>
    /// Конструктор класса строителя экранов.
    /// </summary>
    /// <param name="label">Инструкция для пользователя.</param>
    public ScreenBuilder(string label) : this() => _screen.Label.SetText(label);

    /// <summary>
    /// Конструктор класса строителя экранов.
    /// </summary>
    /// <param name="account">Счет, отображаемый на экране.</param>
    public ScreenBuilder(Account account) : this() => _screen.Label = GetAccountText(account);

    /// <summary>
    /// Возвращает готовый экран.
    /// </summary>
    /// <returns>Новый экран.</returns>
    public UIScreen Build() => _screen;

    /// <summary>
    /// Добавление кнопки возврата.
    /// </summary>
    /// <param name="previousScreen">Экран для возврата.</param>
    /// <param name="padding">Внутренний отступ.</param>
    public void AddBackButton(UIScreen previousScreen, Point padding = default)
    {
        var button = GetButton("Назад", padding);
        button.OnClick += delegate () { return previousScreen; };
        _screen.Add(button);
    }

    /// <summary>
    /// Добавление кнопки закрытия счета.
    /// </summary>
    /// <param name="account">Счет для закрытия.</param>
    /// <param name="mainScreen">Главный экран.</param>
    public void AddCloseAccountButton(Account account, UIScreen mainScreen)
    {
        var button = GetButtonWithIndent("Закрыть счет");
        button.OnClick += delegate ()
        {
            try
            {
                Server.CloseAccount(account);
                mainScreen.Remove(_labels[account]);
                _labels.Remove(account);
                if (Server.Accounts.Length == 0)
                    mainScreen.PostMessage.SetText("У Вас нет текущих счетов.");
            }
            catch (Exception ex)
            {
                _screen.Message.SetText(ex.Message);
                return _screen;
            }
            return mainScreen;
        };
        _screen.Add(button);
    }

    /// <summary>
    /// Добавление кнопок типов счета.
    /// </summary>
    /// <param name="mainScreen">Главный экран.</param>
    public void AddAccountTypesButtons(UIScreen mainScreen)
    {
        var accountTypes = Enum.GetValues<AccountType>();
        foreach (var type in accountTypes)
        {
            var button = GetAccountTypeButton(type);
            button.OnClick += delegate ()
            {
                try
                {
                    var account = Server.OpenAccount(type);
                    var button = GetAccountButton(account);
                    button.OnClick += delegate ()
                    {
                        return new AccountScreenDirector(account, mainScreen).Build();
                    };
                    mainScreen.Add(button, mainScreen.Amount - 2);
                    mainScreen.PostMessage.SetText(string.Empty);
                    return mainScreen;
                }
                catch (Exception ex)
                {
                    _screen.Message.SetText(ex.Message);
                    return _screen;
                }
            };
            _screen.Add(button);
        }
    }

    /// <summary>
    /// Добавление кнопок для текущих счетов.
    /// </summary>
    /// <param name="onClick">Метод, выполняемый при нажатии кнопки счета.</param>
    /// <param name="exclusion">Счета, кнопки которых не создаются.</param>
    public void AddAccountsButtons(OnClickAccountButton onClick, params Account[] exclusion)
    {
        foreach (var account in Server.Accounts)
        {
            if (Array.IndexOf(exclusion, account) != -1) continue;
            var accountButton = GetAccountButton(account);
            accountButton.OnClick += delegate () { return onClick(account, accountButton); };
            _screen.Add(accountButton);
        }
    }

    /// <summary>
    /// Кнопка открытия нового счета.
    /// </summary>
    /// <param name="newAccountScreen">Экран открытия нового счета.</param>
    public void AddOpenAccountButton(UIScreen newAccountScreen)
    {
        
        var button = GetLineButton("Открыть новый счет"); 
        button.OnClick += delegate ()
        {
            newAccountScreen.Message.SetText(string.Empty);
            return newAccountScreen;
        };
        _screen.Add(button);
    }

    /// <summary>
    /// Кнопка открытия экрана операции со счетом.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    /// <param name="label">Информация об операции.</param>
    /// <param name="accountOperation">Метод операции со счетом.</param>
    public void AddOperationButton(Account account, UIScreen accountScreen, string label, AccountOperation accountOperation)
    {
        var button = GetButtonWithIndent(label);
        button.OnClick += delegate ()
        {
            accountScreen.Message.SetText(string.Empty);
            var screen = new OperationScreenDirector(account, accountScreen, accountOperation, label).Build();
            SetAmount(account, screen.Label);
            return screen;
        };
        _screen.Add(button);
    }

    /// <summary>
    /// Кнопка для запроса выполнения рперации со счетом.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    /// <param name="buttonLabel">Название кнопки.</param>
    /// <param name="inputField">Поле для считывания суммы операции.</param>
    /// <param name="accountOperation">Метод, выполняющий операцию.</param>
    public void AddOperationButton(Account account, UIScreen accountScreen, string buttonLabel, UIInputField inputField, AccountOperation accountOperation)
    {
        var button = GetLineButton(buttonLabel);
        button.OnClick += delegate ()
        {
            try
            {
                accountOperation(inputField.Value);
                SetAmount(account, accountScreen.Label);
                return accountScreen;
            }
            catch (ArgumentException e)
            {
                _screen.Message.SetText(e.Message);
                return _screen;
            }
        };
        _screen.Add(button);
    }

    /// <summary>
    /// Кнопка открытия экрана перевода.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    public void AddOpenTransferScreenButton(Account account, UIScreen accountScreen)
    {
        var button = GetButtonWithIndent("Перевести");
        button.OnClick += delegate ()
        {
            accountScreen.Message.SetText(string.Empty);
            var screen = new TransferScreenDirector(account, accountScreen).Build();
            SetAmount(account, screen.Label);
            return screen;
        };
        _screen.Add(button);
    }

    /// <summary>
    /// Кнопки счетов для перевода средств.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="accountScreen">Экран счета.</param>
    /// <param name="inputField">Поле ввода суммы.</param>
    public void AddTransferButtons(Account account, UIScreen accountScreen, UIInputField inputField)
    {
        AddAccountsButtons(delegate (Account destAccount, UIButton button)
        {
            try
            {
                account.Transfer(destAccount, inputField.Value);
                SetAmount(account, accountScreen.Label);
                SetAmount(destAccount, button.Label);
                return accountScreen;
            }
            catch (ArgumentException ex)
            {
                _screen.Message.SetText(ex.Message);
                return _screen;
            }
        }, account);
    }

    /// <summary>
    /// Создание поля ввода суммы оперции.
    /// </summary>
    public UIInputField AddAmountField()
    {
        var inputField = GetInputField("Укажите сумму");
        _screen.Add(inputField);
        return inputField;
    }

    /// <summary>
    /// Добавление кнопки выхода из приложения.
    /// </summary>
    public void AddExitButton()
    {
        var button = GetButton("Выход");
        button.OnClick += delegate () { return UIScreen.Exit; };
        _screen.Add(button);
    }

    /// <summary>
    /// Создание текста информации о счете.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <returns>Текст с информацией о счете.</returns>
    private static UIText GetAccountText(Account account)
    {
        if (!_labels.ContainsKey(account))
        {
            var label = GetText(account.ToString()).Add(account.DisplayBalance, account.Balance > 0 ? ConsoleColor.Green : ConsoleColor.White);
            _labels.Add(account, label);
            return label;
        }

        return _labels[account];
    }

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
    private static UIButton GetButtonWithIndent(string text) => GetButton(text, new Point(4, 0));

    /// <summary>
    /// Создание кнопки с верхним отступом.
    /// </summary>
    /// <param name="text">Текст кнопки.</param>
    /// <returns>Кнопка с верхним отступом.</returns>
    private static UIButton GetLineButton(string text) => GetButton(text, new Point(0, 1));

    /// <summary>
    /// Создание кнопки.
    /// </summary>
    /// <param name="text">Текст кнопки.</param>
    /// <param name="padding">Отступ.</param>
    /// <returns>Новая кнопка</returns>
    private static UIButton GetButton(string text, Point padding = default) =>
        new UIButton(new UIText().Add(text), padding);

    /// <summary>
    /// Создание кнопки счета.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <returns>Новая кнопка счета.</returns>
    private static UIButton GetAccountButton(Account account) => 
        new UIButton(GetAccountText(account), new Point(4, 0)); 

    /// <summary>
    /// Создание кнопки типа счета.
    /// </summary>
    /// <param name="type">Тип счета.</param>
    /// <returns>Новая кнопка типа счета.</returns>
    private static UIButton GetAccountTypeButton(AccountType type) =>
        new UIButton(GetText(Account.GetDisplayAccountType(type)), new Point(4, 0));

    /// <summary>
    /// Создание поля ввода.
    /// </summary>
    /// <param name="text">Текст перед полем.</param>
    /// <returns>Поле ввода.</returns>
    private static UIInputField GetInputField(string text) => new UIInputField(GetText(text), new Point(1, 0));

    /// <summary>
    /// Изменение баланса счета в текстовом поле.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="text">Текстовое поле.</param>
    private static void SetAmount(Account account, UIText text)
    {
        text.SetText(account.DisplayBalance);
        text.SetColor(account.Balance > 0 ? ConsoleColor.Green : ConsoleColor.White);
    }
}
