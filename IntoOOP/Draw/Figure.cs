namespace IntoOOP.Draw;

/// <summary>Класс, описывающий фигуру.</summary>
public abstract class Figure : IFigure
{
    /// <summary>Позиция фигуры.</summary>
    public Vector Pos { get; set; }

    /// <summary>Цвет фигуры.</summary>
    public Color Color { get; set; }

    /// <summary>Видимость фигуры.</summary>
    public bool IsHidden { get; set; }

    /// <summary>Площадь фигуры.</summary>
    public abstract double Area { get; }
}
