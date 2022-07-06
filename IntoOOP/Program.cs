using IntoOOP.Bank.UI;
using IntoOOP.Bank.Screen;

class Program
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {

#if DEBUG

        var test = new IntoOOP.Bank.Tests.AccountTest();
        test.DoProcess();
        Console.Write("\nДля старта приложения нажмите любую клавишу...");
        Console.ReadKey(true);
        Console.SetCursorPosition(0, 0);
        Console.Clear();

#endif

        Console.CursorVisible = false;

        var screen = new MainScreenDirector().Build();

        while (true)
        {
            screen.Show();
            screen = screen.Control();
            if (screen == UIScreen.Exit) return;
        }
    }
}
