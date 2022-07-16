namespace IntoOOP.Draw;

/// <summary>Класс, описывающий точку.</summary>
public class Point : Figure
{
    /// <summary>Площадь точки.</summary>
    public override double Area => 0;

    /// <summary>Приведение объекта точки к строке с информацией об объекте точки.</summary>
    /// <returns>Строка с информацией об объекте точки.</returns>
    public override string ToString() => $"Point (pos: {Pos}, color: {Color})";
}
