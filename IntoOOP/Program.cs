using IntoOOP;
using IntoOOP.UI;

var size = new Point(119, 43);

Console.SetWindowSize(size.X, size.Y);
Console.SetBufferSize(size.X, size.Y);

Console.CursorVisible = false;

var screen = new MainScreenDirector(size).Build();

while (true)
{
    screen.Show();
    screen = screen.Control();
    if (screen == UIScreen.Exit) return;
}