namespace IntoOOP.Bank.UI;

/// <summary>Класс, описывающий кнопку.</summary>
public class UIButton : UIScreenItem
{
    /// <summary>Делегат метода, выполняемого при нажатии на кнопку.</summary>
    /// <returns>Возвращает следующий экран.</returns>
    public delegate UIScreen OnClickAction();

    /// <summary>Событие, вызываемое при нажатии на кнопку.</summary>
    public event OnClickAction OnClick;

    /// <summary>Строка, выводящаяся перед кнопкой.</summary>
    protected const string PREFIX = " > ";

    /// <summary>Ширина кнопки.</summary>
    public override int Width => Label.Length + PREFIX.Length + Padding.X;

    /// <summary>Высота кнопки.</summary>
    public override int Height => Padding.Y + 1;

    /// <summary>Инициализация объекта кнопки.</summary>
    /// <param name="label">Текст, выводящийся внутри кнопки.</param>
    /// <param name="padding">Внутренний отступ.</param>
    public UIButton(UIText label, Point padding) : base(label, padding) { }

    /// <summary>Вывод кнопки на экран.</summary>
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

    /// <summary>Метод, выполняемый при нажатии на кнопку.</summary>
    /// <returns>Возвращает следующий экран.</returns>
    public override UIScreen Click() => OnClick?.Invoke();
}
