namespace IntoOOP.Draw;

/// <summary>Класс, описывающий точку.</summary>
public class Point : Figure
{
    /// <summary>Площадь точки.</summary>
    public virtual double Area => 0;

    /// <summary>Вывод точки в консоль.</summary>
    public virtual void Draw()
    {
        if (IsHidden || Pos.X < 0 || Pos.X >= Console.WindowWidth 
            || Pos.Y < 0 || Pos.Y >= Console.WindowWidth) return;

        Console.SetCursorPosition(Pos.X, Pos.Y);
        var color = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        Console.WriteLine('.');
        Console.ForegroundColor = color;

    }

    /// <summary>Приведение объекта точки к строке с информацией об объекте точки.</summary>
    /// <returns>Строка с информацией об объекте точки.</returns>
    public override string ToString() =>
        $"Point\r\n\tArea = {Area}\r\n\tPosition = {Pos}\r\n\tColor = {Color}\r\n\tIsHidden = {IsHidden}";
}
