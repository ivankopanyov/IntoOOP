namespace IntoOOP.Bank.UI;

/// <summary>
/// Класс элеента экрана.
/// </summary>
public abstract class UIScreenItem
{
    /// <summary>
    /// Находится ли элемент в фокусе.
    /// </summary>
    private bool _focus;

    /// <summary>
    /// Внутренний отступ слева.
    /// </summary>
    private int _paddingLeft;

    /// <summary>
    /// Внутренний отступ сверху.
    /// </summary>
    private int _paddingTop;

    /// <summary>
    /// Текст, выводимый в элементе экрана.
    /// </summary>
    public UIText Label { get; private set; }

    /// <summary>
    /// Позиция строки для вывода эемента экрана.
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// Находится ли элемент в фокусе.
    /// </summary>
    public bool Focus { get => _focus; protected set => _focus = value; }

    /// <summary>
    /// Внутренний отступ слева.
    /// </summary>
    protected int PaddingLeft => _paddingLeft;

    /// <summary>
    /// Внутренний отступ сверху.
    /// </summary>
    protected int PaddingTop => _paddingTop;

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
    /// <param name="paddingLeft">Внутренний отступ сверху.</param>
    /// <param name="paddingTop">Внутренний отступ слева.</param>
    public UIScreenItem(UIText label, int paddingLeft, int paddingTop)
    {
        Label = label;
        _paddingLeft = paddingLeft;
        _paddingTop = paddingTop;
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
        Console.CursorLeft = 0;
        Console.CursorTop = LineNumber;
        var clear = new string(' ', Console.WindowWidth);
        for (int i = 0; i < Height; i++) Console.WriteLine(clear);
        Console.CursorTop = LineNumber;
        for (int i = 0; i < PaddingTop; i++) Console.WriteLine();
        Console.CursorLeft = PaddingLeft;
    }
}
