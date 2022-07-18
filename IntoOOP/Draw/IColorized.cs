namespace IntoOOP.Draw;

/// <summary>Объект с изменяемым цветом.</summary>
public interface IColorized
{
    /// <summary>Текущий цвет объекта.</summary>
    Color Color { get; set; }
}
