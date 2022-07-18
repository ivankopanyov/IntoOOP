using IntoOOP.UI;
using IntoOOP.Coder.UI;

var size = new Point(Console.WindowWidth, Console.WindowHeight);
Console.SetWindowSize(size.X, size.Y);
Console.SetBufferSize(size.X, size.Y);
Console.CursorVisible = false;

var screen = new CoderScreenBuilder(size).Build();

while (true)
{
    screen.Show();
    screen = screen.Control();
    if (screen == UIScreen.Exit) return;
}