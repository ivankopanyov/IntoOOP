using IntoOOP.Draw;

namespace IntoOOP;

/// <summary>Класс, описывающий точку для работы с консольным интерфейсом.</summary>
public class ConsolePoint : Point
{
    /// <summary>Вывод точки в консоль.</summary>
    public override void Draw()
    {
        var pos = new Vector(Pos.X * 2, Pos.Y);

        if (IsHidden || pos.X < 0 || pos.X >= Console.WindowWidth
            || pos.Y < 0 || pos.Y >= Console.WindowHeight) return;

        Console.SetCursorPosition((int)pos.X, (int)pos.Y);
        var color = Console.ForegroundColor;
        try
        {
            Console.ForegroundColor = (ConsoleColor)Color;
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("██");
        Console.ForegroundColor = color;

    }
}
