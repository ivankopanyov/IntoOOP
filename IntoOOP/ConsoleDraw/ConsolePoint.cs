using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Класс, описывающий точку для работы с консольным интерфейсом.</summary>
public class ConsolePoint : Point
{
    /// <summary>Вывод точки в консоль.</summary>
    /// <param name="areaStart">Начало области вывода.</param>
    /// <param name="areaSize">Размер области вывода.</param>
    /// <param name="symbol">Символ отрисовки фигуры.</param>
    public override void Draw(Vector areaStart, Vector areaSize, char symbol)
    {
        if (IsHidden) return;

        var areaEnd = areaStart + new Vector(areaSize.X < 0 ? 0 : areaSize.X, areaSize.Y < 0 ? 0 : areaSize.Y);

        var pos = new Vector(Pos.X * 2, Pos.Y);

        if (pos.X < 0 || pos.X < areaStart.X || pos.X >= Console.WindowWidth || pos.X >= areaEnd.X
            || pos.Y < 0 || pos.Y < areaStart.Y || pos.Y >= Console.WindowHeight || pos.Y >= areaEnd.Y) return;

        Console.SetCursorPosition((int)pos.X + (int)areaStart.X, (int)pos.Y + (int)areaStart.Y);
        var color = Console.ForegroundColor;
        try
        {
            Console.ForegroundColor = (ConsoleColor)Color;
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Write(symbol); 
        Console.Write(symbol);
        Console.ForegroundColor = color;

    }
}
