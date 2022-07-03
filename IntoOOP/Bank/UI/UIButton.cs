namespace IntoOOP.Bank.UI;

/// <summary>
/// Класс кнопки.
/// </summary>
public class UIButton : UIScreenItem
{
    /// <summary>
    /// Строка, выводящаяся перед кнопкой.
    /// </summary>
    protected const string PREFIX = " > ";

    /// <summary>
    /// Метод, выполняемый при нажатии на кнопку.
    /// </summary>
    public OnClick OnClick { get; set; }

    /// <summary>
    /// Ширина кнопки.
    /// </summary>
    public override int Width => Label.Length + PREFIX.Length + PaddingLeft;

    /// <summary>
    /// Высота кнопки.
    /// </summary>
    public override int Height => PaddingTop + 1;

    /// <summary>
    /// Конструктор класса кнопки.
    /// </summary>
    /// <param name="label">Текст, выводящийся внутри кнопки.</param>
    /// <param name="paddingLeft">Внутренний отступ слева.</param>
    /// <param name="paddingTop">Внутренний отступ сверху.</param>
    public UIButton(UIText label, int paddingLeft = 0, int paddingTop = 0) : base(label, paddingLeft, paddingTop) { }

    /// <summary>
    /// Вывод кнопки в консоль.
    /// </summary>
    /// <param name="focus">Установка фокуса на кнопку.</param>
    /// <returns>Возвращает значение типа по умолчанию.</returns>
    public override ConsoleKey Draw(bool focus)
    {
        Clear();
        Focus = focus;
        Console.Write(PREFIX);
        if (focus) Console.BackgroundColor = ConsoleColor.DarkGray;
        Label.Print();
        Console.ResetColor();
        return default;
    }

    /// <summary>
    /// Метод, выполняемый при нажатии на кнопку.
    /// </summary>
    /// <returns>Возвращает следующий экран.</returns>
    public override UIScreen Click() => OnClick();

    /// <summary>
    /// Установка метода, выполняемого при нажатии на кнопку.
    /// </summary>
    /// <param name="onClick">Метод, выполняемый при нажатии на кнопку.</param>
    /// <returns>Кнопка.</returns>
    public UIButton SetOnClick(OnClick onClick)
    {
        OnClick = onClick;
        return this;
    }
}
