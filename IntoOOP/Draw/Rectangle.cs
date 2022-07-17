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

    /// <summary>Приведение объекта прямоугольника к строке с информацией об объекте прямоугольника..</summary>
    /// <returns>Строка с информацией об объекте прямоугольника.</returns>
    public override string ToString() =>
        $"Rectangle (size: {_Size}, area: {Area}, pos: {Pos}, color: {Color})";
}
