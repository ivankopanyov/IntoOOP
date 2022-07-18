using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Геометрическая фигура для работы с консольным интерфейсом.</summary>
public interface IConsoleFigure : IMovable, IConsoleDrawable
{
    /// <summary>Цвет фигуры в консоли.</summary>
    ConsoleColor Color { get; set; }
}