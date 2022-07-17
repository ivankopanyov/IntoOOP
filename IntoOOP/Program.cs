using IntoOOP.ConsoleDraw;

const string footer = @"  ▲            1 -> Point      R -> Red     +  -> Size In
◄   ► -> MOVE  2 -> Rectangle  G -> Green   -  -> Size Out
  ▼            3 -> Circle     B -> Blue   Esc -> Exit";

var screen = new ConsoleScreen();

screen.Footer = footer;
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