using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Объект, отображаемый в консоли.</summary>
public interface IConsoleDrawable
{
    /// <summary>Отображение объекта.</summary>
    /// <param name="areaStart">Начало области отображения.</param>
    /// <param name="areaSize">Размер области отображения.</param>
    /// <param name="symbol">Символ отрисовки объекта.</param>
    void Draw(Vector areaStart, Vector areaSize, char symbol);
}
