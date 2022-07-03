using IntoOOP.Bank;
using IntoOOP.Bank.UI;

class Program
{
    /// <summary>
    /// Главный экран приложения.
    /// </summary>
    private static UIScreen mainScreen;

    /// <summary>
    /// Экран открытия нового счета.
    /// </summary>
    private static UIScreen newAccountScreen;

    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        ScreenBuilder mainScreenBuilder = new ScreenBuilder("Текущие счета:");

        mainScreen = mainScreenBuilder.Build();

        newAccountScreen = BuildNewAccountScreen();

        BuildMainScreen(mainScreenBuilder);

        var screen = mainScreen;

        while (true)
        {
            screen.Show();
            screen = screen.Control();
            if (screen == UIScreen.Exit) return;
        }
    }

    /// <summary>
    /// Создание главного экрана приложения.
    /// </summary>
    /// <param name="screenBuilder">Экземпляр класса стротиля главного экрана.</param>
    public static void BuildMainScreen(ScreenBuilder screenBuilder)
    {
        if (Server.Accounts.Length == 0)
            mainScreen.PostMessage.SetText("У Вас нет текущих счетов.");

        screenBuilder
            .AddAccountsButtons(BuildAccountScreen)
            .AddOpenAccountButton(newAccountScreen)
            .AddExitButton()
            .Build();
    }

    /// <summary>
    /// Создание экрана открытия нового счета.
    /// </summary>
    /// <returns>Экран открытия нового счета.</returns>
    public static UIScreen BuildNewAccountScreen() =>
        new ScreenBuilder("Выберите тип счета:")
        .AddAccountTypesButtons(mainScreen, BuildAccountScreen)
        .AddBackButton(mainScreen, 1)
        .Build();

    /// <summary>
    /// Создание экрана счета.
    /// </summary>
    /// <param name="account">Счет.</param>
    /// <param name="button">Кнопка счета.</param>
    /// <returns>Экран счета.</returns>
    public static UIScreen BuildAccountScreen(Account account, UIButton button) => 
        new ScreenBuilder(account)
            .AddCloseAccountButton(account, mainScreen, button)
            .AddBackButton(mainScreen, 1)
            .Build();
}
