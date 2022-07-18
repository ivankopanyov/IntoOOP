namespace IntoOOP.Draw;

/// <summary>Геометрическая фигура.</summary>
public interface IFigure : IMovable, IColorized 
{
    /// <summary>Состояние видимости фигуры.</summary>
    bool IsHidden { get; set; }

    /// <summary>Площадь фигуры.</summary>
    double Area { get; }
}

