namespace IntoOOP.Draw;

/// <summary>Класс, описывающий фигуру.</summary>
public class Figure
{
    /// <summary>Позиция фигуры.</summary>
    public Vector Pos { get; set; } 

    /// <summary>Цвет фигуры.</summary>
    public Color Color { get; set; }

    /// <summary>Видимость фигуры.</summary>
    public bool IsHidden { get; set; }

    /// <summary>Площадь фигуры.</summary>
    public virtual double Area => 0;

    /// <summary>Отрисовка фигуры.</summary>
    /// <param name="areaStart">Начало области вывода.</param>
    /// <param name="areaSize">Размер области вывода.</param>
    /// <param name="symbol">Символ отрисовки фигуры.</param>
    public virtual void Draw(Vector areaStart, Vector areaSize, char symbol) { }

    /// <summary>Приведение объекта фигуры к строке с информацией об объекте фигуры.</summary>
    /// <returns>Cтрока с информацией об объекте фигуры.</returns>
    public override string ToString() => $"Figure (pos: {Pos}, color: {Color})";
}
