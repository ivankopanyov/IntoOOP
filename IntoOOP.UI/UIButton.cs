namespace IntoOOP.UI;

/// <summary>Класс кнопки.</summary>
public class UIButton : UIScreenItem
{
    /// <summary>Высота кнопки без отступов.</summary>
    private const int HEIGHT = 1;

    /// <summary>Делегат метода, выполняемого при нажатии на кнопку.</summary>
    /// <returns>Следующий экран.</returns>
    public delegate UIScreen OnClickAction();

    /// <summary>Событие, вызываемое при нажатии на кнопку.</summary>
    public event OnClickAction OnClick;

    /// <summary>Строка, выводящаяся перед кнопкой.</summary>
    private string _Prefix = string.Empty;

    /// <summary>Строка, выводящаяся перед кнопкой.</summary>
    public string Prefix
    {
        get => _Prefix;
        set => _Prefix = value == null ? string.Empty : value;
    }

    /// <summary>Возможен ли фокус на данном элемента.</summary>
    public override bool IsFocusable => true;

    /// <summary>Ширина кнопки.</summary>
    public override int Width => Padding.X + Label.Length + _Prefix.Length;

    /// <summary>Высота кнопки.</summary>
    public override int Height => Padding.Y + HEIGHT;

    /// <summary>Цвет префикса кнопки.</summary>
    public ConsoleColor? PrefixColor { get; set; } = null;

    /// <summary>Цвет фона кнопки в фокусе.</summary>
    public ConsoleColor? FocusColor { get; set; } = null;

    /// <summary>Инициализация объекта кнопки.</summary>
    /// <param name="label">Текст кнопки.</param>
    public UIButton(string label = "") : base(label) { }

    /// <summary>Вывод кнопки в консоль.</summary>
    /// <param name="focus">Установка фокуса на кнопку.</param>
    /// <returns>Возвращает значение типа по умолчанию.</returns>
    public override ConsoleKey Draw(bool focus)
    {
        Clear();
        Focus = focus;
        var currentForegroundColor = Console.ForegroundColor;
        var currentBackgroundColor = Console.BackgroundColor;

        Console.CursorLeft = Position.X + Padding.X;

        if (PrefixColor != null) Console.ForegroundColor = (ConsoleColor)PrefixColor;
        Console.Write(_Prefix);

        if (focus)
            Console.BackgroundColor = FocusColor != null ? (ConsoleColor)FocusColor : ConsoleColor.DarkGray;

        Console.ForegroundColor = LabelColor != null ? (ConsoleColor)LabelColor : currentForegroundColor;
        Console.WriteLine(Label);

        Console.ForegroundColor = currentForegroundColor;
        Console.BackgroundColor = currentBackgroundColor;

        return default;
    }

    /// <summary>Метод, вызывающий событие при нажатии на кнопку..</summary>
    /// <returns>Возвращает следующий экран.</returns>
    public override UIScreen Click() => OnClick?.Invoke()!;
}