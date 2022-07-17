using IntoOOP.ConsoleDraw;

const string FOOTER = @"  ▲            1 -> Point      R -> Red     +  -> Size In
◄   ► -> MOVE  2 -> Circle     G -> Green   -  -> Size Out
  ▼            3 -> Rectangle  B -> Blue   Esc -> Exit";

var screen = new ConsoleScreen();

screen.Footer = FOOTER;
screen.AddPoint();
screen.AddCircle();
screen.AddRectangle();
screen.IsShow = true;

Console.CursorVisible = false;

ConsoleKey key;

while (true)
{
    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Escape) return;
    screen.KeyDown(key);
}