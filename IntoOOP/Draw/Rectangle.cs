namespace IntoOOP.Draw;

/// <summary>Класс, описывающий прямоугольник.</summary>
public class Rectangle : Point
{
    /// <summary>Размер прямоугольника.</summary>
    private Vector _Size;

    /// <summary>Размер прямоугольника.</summary>
    public Vector Size
    {
        get => _Size;
        set
        {
            if (value.X < 0 || value.Y < 0 )
                throw new ArgumentOutOfRangeException(nameof(Size));

            _Size = value;
        }
    }

    /// <summary>Площадь прямоугольника.</summary>
    public override double Area => _Size.X * _Size.Y;

    /// <summary>Инициализация объекта прямоугольника.</summary>
    /// <param name="size">Размер прямоугольника.</param>
    public Rectangle(Vector size) => _Size = size;

    /// <summary>Вывод прямоугольника в консоль.</summary>
    public override void Draw()
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        for (int y = Pos.Y; y <= Pos.Y + Size.Y; y++)
        {
            if (y < 0) continue;
            if (y >= Console.WindowHeight) break;

            for (int x = Pos.X * 2; x <= (Pos.X + Size.X) * 2; x += 2)
            {
                if (x < 0) continue;
                if (x >= Console.WindowWidth) break;
                Console.SetCursorPosition(x, y);
                Console.Write("..");
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта прямоугольника к строке с информацией об объекте прямоугольника..</summary>
    /// <returns>Строка с информацией об объекте прямоугольника.</returns>
    public override string ToString() =>
        $"Rectangle\r\n\tSize = {_Size}\r\n\tArea = {Area}\r\n\tPosition = {Pos}\r\n\tColor = {Color}\r\n\tIsHidden = {IsHidden}";
}
