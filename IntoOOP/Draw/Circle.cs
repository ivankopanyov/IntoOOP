namespace IntoOOP.Draw;

/// <summary>Класс, описывающий окружность.</summary>
public class Circle : Point
{
    /// <summary>Радиус окружности.</summary>
    private double _Radius;

    /// <summary>Радиус окружности.</summary>
    public double Radius
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
    public Circle(double radius) => _Radius = radius;

    /// <summary>Приведение объекта окружности к строке с информацией об объекте окружности.</summary>
    /// <returns>Строка с информацией об объекте окружности.</returns>
    public override string ToString() =>
        $"Circle (radius: {_Radius}, area: {Area}, pos: {Pos}, color: {Color})";
}
