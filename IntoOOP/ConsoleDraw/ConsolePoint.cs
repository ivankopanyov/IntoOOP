using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Класс, описывающий точку для работы с консольным интерфейсом.</summary>
public class ConsolePoint : Point, IConsoleFigure
{
    /// <summary>Цвет точки.</summary>
    public ConsoleColor Color { get; set; }

    /// <summary>Вывод точки в консоль.</summary>
    /// <param name="areaStart">Начало области вывода.</param>
    /// <param name="areaSize">Размер области вывода.</param>
    /// <param name="symbol">Символ отрисовки фигуры.</param>
    public void Draw(Vector areaStart, Vector areaSize, char symbol)
    {
        var areaEnd = areaStart + new Vector(areaSize.X < 0 ? 0 : areaSize.X, areaSize.Y < 0 ? 0 : areaSize.Y);

        var pos = new Vector(Pos.X * 2, Pos.Y);

        if (pos.X < 0 || pos.X < areaStart.X || pos.X >= Console.WindowWidth || pos.X >= areaEnd.X
            || pos.Y < 0 || pos.Y < areaStart.Y || pos.Y >= Console.WindowHeight || pos.Y >= areaEnd.Y) return;

        Console.SetCursorPosition((int)pos.X + (int)areaStart.X, (int)pos.Y + (int)areaStart.Y);
        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        Console.Write(symbol); 
        Console.Write(symbol);
        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта точки к строке с информацией об объекте точки.</summary>
    /// <returns>Строка с информацией об объекте точки.</returns>
    public override string ToString() => $"Point (pos: {Pos}, color: {Color})";
}
