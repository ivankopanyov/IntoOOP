using IntoOOP.Draw;

namespace IntoOOP;

/// <summary>Класс, описывающий окружность для работы с консольным интерфейсом.</summary>
public class ConsoleCircle : Circle
{
    /// <summary>Инициализация объекта окружности.</summary>
    /// <param name="radius">Радиус окружности.</param>
    public ConsoleCircle(int radius) : base(radius) { }

    /// <summary>Вывод окружности в консоль.</summary>
    public override void Draw()
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        for (int y = (int)Pos.Y - (int)Radius; y <= Pos.Y + Radius; y++)
        {
            if (y < 0) continue;
            if (y >= Console.WindowHeight) break;

            for (int x = (int)Pos.X - (int)Radius; x <= Pos.X + Radius; x++)
            {
                var X = Pos.X * 2 - (Pos.X - x) * 2;
                if (X < 0) continue;
                if (X >= Console.WindowWidth) break;
                var legX = Pos.X - x;
                var legY = Pos.Y - y;
                if (Math.Sqrt(legX * legX + legY * legY) > Radius + 0.5) continue;
                Console.SetCursorPosition((int)X, y);
                Console.Write("██");
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта окружности к строке с информацией об объекте окружности.</summary>
    /// <returns>Строка с информацией об объекте окружности.</returns>
    public override string ToString() =>
        $"Circle (radius: {Radius}, area: {Area:f0}, pos: {Pos}, color: {Color})";
}
