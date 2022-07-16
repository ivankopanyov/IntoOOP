namespace IntoOOP.UI;

/// <summary> Класс элемента экрана. </summary>
public abstract class UIScreenItem
{
    /// <summary> Текст, выводимый в элементе экрана.</summary>
    protected string _Label;

    /// <summary>Ширина элемента экрана.</summary>
    public abstract int Width { get; }

    /// <summary>Высота элемента экрана.</summary>
    public abstract int Height { get; }

    /// <summary>Возможен ли фокус на данном элемента.</summary>
    public abstract bool IsFocusable { get; }

    /// <summary>Текст, выводимый в элементе экрана.</summary>
    public virtual string Label
    {
        get => _Label;
        set => _Label = string.IsNullOrEmpty(value) ? string.Empty : value.Replace('\n', ' ');
    }

    /// <summary>Экземпляр экрана, на котором находится элемент.</summary>
    public UIScreen Screen { get; internal set; }

    /// <summary>Следующий элемент экрана.</summary>
    public UIScreenItem Next { get; internal set; }

    /// <summary>Предыдущий элемент экрана.</summary>
    public UIScreenItem Previous { get; internal set; }

    /// <summary>Находится ли элемент в фокусе.</summary>
    public bool Focus { get; protected set; }

    /// <summary>Внутренний отступ.</summary>
    public Point Padding { get; set; }

    /// <summary>Позиция на экране.</summary>
    internal Point Position { get; set; }

    /// <summary>Цвет текста элемента экрана.</summary>
    public ConsoleColor? LabelColor { get; set; } = null;

    /// <summary>Инициализация элемента экрана.</summary>
    /// <param name="label">Текст, выводимый в элементе экрана.</param>
    public UIScreenItem(string label = "") => _Label = label;

    /// <summary>Вывод элемента экрана в консоль.</summary>
    /// <param name="focus">Находится ли элемент в фокусе.</param>
    /// <returns>Возвращает клавишу завершения работы с элементом.</returns>
    public abstract ConsoleKey Draw(bool focus);

    /// <summary>Метод, выполняемый при выборе элемента.</summary>
    /// <returns>Следующий экран.</returns>
    public abstract UIScreen Click();

    /// <summary>Очистка области консоли, в которой будет выведен элемент.</summary>
    protected void Clear()
    {
        var clear = new string(' ', Screen.Size.X - 2);

        for (int i = 0; i < Height; i++)
        {
            Console.CursorTop = Position.Y + i;
            Console.CursorLeft = 1;
            Console.Write(clear);
        }

        Console.CursorTop = Position.Y + Padding.Y;
    }
}