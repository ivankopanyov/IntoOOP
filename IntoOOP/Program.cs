using IntoOOP.Bank.UI;
using IntoOOP.Bank.Screen;

#if DEBUG

var test = new IntoOOP.Bank.Tests.AccountEqualsTest();
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