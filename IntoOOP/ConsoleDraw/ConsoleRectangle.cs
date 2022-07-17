using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Класс, описывающий прямоугольник для работы с консольным интерфейсом.</summary>
public class ConsoleRectangle : Rectangle, IConsoleFigure
{
    /// <summary>Цвет прямоугольника.</summary>
    public ConsoleColor Color { get; set; }

    /// <summary>Инициализация объекта прямоугольника.</summary>
    /// <param name="width">Ширина прямоугольника.</param>
    /// <param name="heght">Высота прямоугольника.</param>
    public ConsoleRectangle(int width, int heght) : base(new Vector(width, heght)) { }

    /// <summary>Вывод прямоугольника в консоль.</summary>
    /// <param name="areaStart">Начало области вывода.</param>
    /// <param name="areaSize">Размер области вывода.</param>
    /// <param name="symbol">Символ отрисовки фигуры.</param>
    public void Draw(Vector areaStart, Vector areaSize, char symbol)
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        var areaEnd = areaStart + new Vector(areaSize.X < 0 ? 0 : areaSize.X, areaSize.Y < 0 ? 0 : areaSize.Y);

        for (int y = (int)Pos.Y; y <= Pos.Y + Size.Y; y++)
        {
            if (y < 0 || y < areaStart.Y) continue;
            if (y >= Console.WindowHeight || y >= areaEnd.Y) break;

            for (int x = (int)Pos.X * 2; x <= (Pos.X + Size.X) * 2; x += 2)
            {
                if (x < 0 || y < areaStart.X) continue;
                if (x >= Console.WindowWidth || y >= areaEnd.X) break;
                Console.SetCursorPosition((int)areaStart.X + x, (int)areaStart.Y + y);
                Console.Write(symbol);
                Console.Write(symbol);
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта прямоугольника к строке с информацией об объекте прямоугольника..</summary>
    /// <returns>Строка с информацией об объекте прямоугольника.</returns>
    public override string ToString() =>
        $"Rectangle (size: {Size}, area: {Area:f0}, pos: {Pos}, color: {Color})";
}
