namespace IntoOOP.Bank.UI;

/// <summary>
/// Класс элеента экрана.
/// </summary>
public abstract class UIScreenItem
{
    /// <summary>
    /// Текст, выводимый в элементе экрана.
    /// </summary>
    public UIText Label { get; private set; }

    /// <summary>
    /// Находится ли элемент в фокусе.
    /// </summary>
    public bool Focus { get; protected set; }

    /// <summary>
    /// Внутренний отступ.
    /// </summary>
    public Point Padding { get; set; }

    /// <summary>
    /// Позиция на экране.
    /// </summary>
    public Point Position { get; set; }

    /// <summary>
    /// Ширина элемента экрана.
    /// </summary>
    public abstract int Width { get; }

    /// <summary>
    /// Высота элемента экрана.
    /// </summary>
    public abstract int Height { get; }

    /// <summary>
    /// Конструктор класса элемента экрана.
    /// </summary>
    /// <param name="label">Текст, выводимый в элементе экрана.</param>
    /// <param name="padding">Внутренний отступ.</param>
    public UIScreenItem(UIText label, Point padding)
    {
        Label = label;
        Padding = padding;
    }

    /// <summary>
    /// Вывод элемента экрана в консоль.
    /// </summary>
    /// <param name="focus">Находится ли элемент в фокусе.</param>
    /// <returns>Возвращает клавишу завершения работы с элементом.</returns>
    public abstract ConsoleKey Draw(bool focus);

    /// <summary>
    /// Метод, выполняемый при выборе элемента.
    /// </summary>
    /// <returns></returns>
    public abstract UIScreen Click();

    /// <summary>
    /// Очистка области консоли, в которой будет выведен элемент.
    /// </summary>
    protected void Clear()
    {
        Console.SetCursorPosition(0, Position.Y);
        var clear = new string(' ', Console.WindowWidth);
        for (int i = 0; i < Height; i++) Console.WriteLine(clear);
        Console.CursorTop = Position.Y;
        for (int i = 0; i < Padding.Y; i++) Console.WriteLine();
        Console.CursorLeft = Padding.X;
    }
}
