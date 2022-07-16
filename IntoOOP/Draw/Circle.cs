namespace IntoOOP.Draw;

/// <summary>Класс, описывающий окружность.</summary>
public class Circle : Point
{
    /// <summary>Радиус окружности.</summary>
    private int _Radius;

    /// <summary>Радиус окружности.</summary>
    public int Radius
    {
        get => _Radius;
        set
        { 
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Radius));

            _Radius = value;
        }
    }

    /// <summary>Площадь окружности.</summary>
    public override double Area => Math.PI * _Radius * _Radius;

    /// <summary>Инициализация объекта окружности.</summary>
    /// <param name="radius">Радиус окружности.</param>
    public Circle(int radius) => _Radius = radius;

    /// <summary>Вывод окружности в консоль.</summary>
    public override void Draw()
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        for (int y = Pos.Y - Radius; y <= Pos.Y + Radius; y++)
        {
            if (y < 0) continue;
            if (y >= Console.WindowHeight) break;

            for (int x = Pos.X - Radius; x <= Pos.X + Radius; x++)
            {
                var X = Pos.X * 2 - (Pos.X - x) * 2;
                if (X < 0) continue;
                if (X >= Console.WindowWidth) break;
                var legX = Pos.X - x;
                var legY = Pos.Y - y;
                if (Math.Sqrt(legX * legX + legY * legY) > Radius + 0.5) continue;
                Console.SetCursorPosition(X, y);
                Console.Write("..");
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта окружности к строке с информацией об объекте окружности.</summary>
    /// <returns>Строка с информацией об объекте окружности.</returns>
    public override string ToString() =>
        $"Circle\r\n\tRadius = {_Radius}\r\n\tArea = {Area}\r\n\tPosition = {Pos}\r\n\tColor = {Color}\r\n\tIsHidden = {IsHidden}";
}
