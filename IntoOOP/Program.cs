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
