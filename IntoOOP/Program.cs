using IntoOOP;
using IntoOOP.Draw;

string footer = @"  ▲            1 -> Point      R -> Red     +  -> Size In
◄   ► -> MOVE  2 -> Rectangle  G -> Green   -  -> Size Out
  ▼            3 -> Circle     B -> Blue   Esc -> Exit";

int footerHeight = footer.Split('\n').Length;

var startPos = new Vector(Console.WindowWidth / 4, (Console.WindowHeight - footerHeight) / 2);

var figures = new Point[]
{
    new ConsolePoint()
    {
        Pos = startPos,
        Color = ConsoleColor.Blue
    },
    new ConsoleCircle(4)
    {
        Pos = startPos,
        Color = ConsoleColor.Green
    },
    new ConsoleRectangle(4, 4)
    {
        Pos = startPos - Vector.One * 2,
        Color = ConsoleColor.Red
    }
};

var currentFigere = figures[2];
ConsoleKey key;

Console.CursorVisible = false;
Draw();

while (true)
{
    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Escape) return;
    KeyDown(key);
}

void KeyDown(ConsoleKey key)
{
    switch (key)
    {
        case ConsoleKey.D1: SetCurrentFigure(0); break;
        case ConsoleKey.D2: SetCurrentFigure(1); break;
        case ConsoleKey.D3: SetCurrentFigure(2); break;
        case ConsoleKey.UpArrow:    Move(Vector.Up);    break;
        case ConsoleKey.DownArrow:  Move(Vector.Down);  break;
        case ConsoleKey.LeftArrow:  Move(Vector.Left);  break;
        case ConsoleKey.RightArrow: Move(Vector.Right); break;
        case ConsoleKey.R: SetColor(ConsoleColor.Red);   break;
        case ConsoleKey.G: SetColor(ConsoleColor.Green); break;
        case ConsoleKey.B: SetColor(ConsoleColor.Blue);  break;
        case ConsoleKey.OemPlus:  SetSize(1);  break;
        case ConsoleKey.OemMinus: SetSize(-1); break;
    }
}

void SetCurrentFigure(int index)
{
    if (index < 0 || index >= figures!.Length || currentFigere == figures[index]) return;

    currentFigere = figures[index];
    Draw();
}

void Move(Vector vector)
{
    if (vector == Vector.Zero) return;

    currentFigere.Pos += vector;
    Draw();
}

void SetColor(ConsoleColor color)
{
    if (color == currentFigere.Color) return;

    currentFigere.Color = color;
    Draw();
}

void SetSize(int addValue)
{
    var type = currentFigere.GetType();
    if (type == typeof(ConsolePoint)) return;

    if (type == typeof(ConsoleCircle))
    {
        var circle = (ConsoleCircle)currentFigere;
        if (addValue == 0 || circle.Radius + addValue < 0) return;
        circle.Radius += addValue;
        Draw();
        return;
    }

    if (type == typeof(ConsoleRectangle))
    {
        var rectangle = (ConsoleRectangle)currentFigere;
        if (addValue == 0 || rectangle.Size.X + addValue < 0 || rectangle.Size.Y + addValue < 0) return;
        rectangle.Size += Vector.One * addValue;
        Draw();
        return;
    }
}

void Draw()
{
    Console.Clear();
    Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
    currentFigere.Draw();
    DrawFooter();
}

void DrawFooter()
{
    var y = Console.WindowHeight - footerHeight - 2;
    if (y < 0) return;

    Console.SetCursorPosition(0, y);
    Console.WriteLine(currentFigere); 
    Console.WriteLine();
    Console.Write(footer);
}