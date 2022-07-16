using IntoOOP.Draw;

namespace IntoOOP;

/// <summary>Класс, описывающий прямоугольник для работы с консольным интерфейсом.</summary>
public class ConsoleRectangle : Rectangle
{
    /// <summary>Инициализация объекта прямоугольника.</summary>
    /// <param name="width">Ширина прямоугольника.</param>
    /// <param name="heght">Высота прямоугольника.</param>
    public ConsoleRectangle(int width, int heght) : base(new Vector(width, heght)) { }

    /// <summary>Вывод прямоугольника в консоль.</summary>
    public override void Draw()
    {
        if (IsHidden) return;

        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;

        for (int y = (int)Pos.Y; y <= Pos.Y + Size.Y; y++)
        {
            if (y < 0) continue;
            if (y >= Console.WindowHeight) break;

            for (int x = (int)Pos.X * 2; x <= (Pos.X + Size.X) * 2; x += 2)
            {
                if (x < 0) continue;
                if (x >= Console.WindowWidth) break;
                Console.SetCursorPosition(x, y);
                Console.Write("██");
            }
        }

        Console.ForegroundColor = color;
    }

    /// <summary>Приведение объекта прямоугольника к строке с информацией об объекте прямоугольника..</summary>
    /// <returns>Строка с информацией об объекте прямоугольника.</returns>
    public override string ToString() =>
        $"Rectangle (size: {Size}, area: {Area:f0}, pos: {Pos}, color: {Color})";
}
