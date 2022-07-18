using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Класс, описывающий окружность для работы с консольным интерфейсом.</summary>
public class ConsoleCircle : Circle, IConsoleFigure
{
    /// <summary>Цвет окружности.</summary>
    public ConsoleColor Color { get; set; }

    /// <summary>Инициализация объекта окружности.</summary>
    /// <param name="radius">Радиус окружности.</param>
    public ConsoleCircle(int radius) : base(radius) { }

    /// <summary>Вывод окружности в консоль.</summary>
    /// <param name="areaStart">Начало области вывода.</param>
    /// <param name="areaSize">Размер области вывода.</param>
    /// <param name="symbol">Символ отрисовки фигуры.</param>
    public void Draw(Vector areaStart, Vector areaSize, char symbol)
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        var areaEnd = areaStart + new Vector(areaSize.X < 0 ? 0 : areaSize.X, areaSize.Y < 0 ? 0 : areaSize.Y);

        for (int y = (int)Pos.Y - (int)Radius; y <= Pos.Y + Radius; y++)
        {
            if (y < 0 || y < areaStart.Y) continue;
            if (y >= Console.WindowHeight || y >= areaEnd.Y) break;

            for (int x = (int)Pos.X - (int)Radius; x <= Pos.X + Radius; x++)
            {
                var X = Pos.X * 2 - (Pos.X - x) * 2;
                if (X < 0 || X < areaStart.X) continue;
                if (X >= Console.WindowWidth || X >= areaEnd.X) break;
                var legX = Pos.X - x;
                var legY = Pos.Y - y;
                if (Math.Sqrt(legX * legX + legY * legY) > Radius + 0.5) continue;
                Console.SetCursorPosition((int)X + (int)areaStart.X, y + (int)areaStart.Y);
                Console.Write(symbol);
                Console.Write(symbol);
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта окружности к строке с информацией об объекте окружности.</summary>
    /// <returns>Строка с информацией об объекте окружности.</returns>
    public override string ToString() =>
        $"Circle (radius: {Radius}, area: {Area:f0}, pos: {Pos}, color: {Color})";
}
