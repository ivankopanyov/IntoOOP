namespace IntoOOP.Draw;

/// <summary>Объект с изменяемой позицией на плоскости.</summary>
public interface IMovable
{
    /// <summary>Текущая позиция объекта.</summary>
    Vector Pos { get; set; }
}
