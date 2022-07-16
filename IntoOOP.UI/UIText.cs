namespace IntoOOP.UI;

/// <summary>Текст, выводиный на экране.</summary>
public class UIText : UIScreenItem
{
    /// <summary>Длина самой длинной строки текста.</summary>
    private int _LineLength = 0;

    /// <summary>Колличество строк в тексте.</summary>
    private int _LinesCount = 1;

    /// <summary>Массив строк, содержащихся в тексте.</summary>
    private string[] _ArrayLabel = new string[] { string.Empty };

    /// <summary>Текст, выводимый в элементе экрана.</summary>
    public override string Label
    {
        get => _Label;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                _Label = string.Empty;
                _ArrayLabel = new string[] { string.Empty };
                _LineLength = 0;
                _LinesCount = 1;
                return;
            }

            _Label = value;
            _ArrayLabel = _Label.Split('\n');
            _LineLength = 0;
            foreach (var str in _ArrayLabel)
                if (str.Length > _LineLength) _LineLength = str.Length;
            _LinesCount = _ArrayLabel.Length;
        }
    }

    /// <summary>Возможен ли фокус на данном элемента.</summary>
    public override bool IsFocusable => false;

    /// <summary>Ширина элемента текста.</summary>
    public override int Width => Padding.X + _LineLength;

    /// <summary>Высота элемента текста.</summary>
    public override int Height => Padding.Y + _LinesCount;

    /// <summary>Инициализация объекта текста.</summary>
    /// <param name="label">Текст, выводимый на экране.</param>
    public UIText(string label = "") : base(label) => Label = label;

    /// <summary>Метод, выполняемый при нажатии клавиши Enter.</summary>
    /// <returns>Возвращает null.</returns>
    public override UIScreen Click() => null!;

    /// <summary>Метод вывода текста в консоль.</summary>
    /// <param name="focus">Установка фокуса на элементе текста.</param>
    /// <returns>Возвращает клавишу завершения ввода.</returns>
    public override ConsoleKey Draw(bool focus)
    {
        Clear();
        Focus = focus;
        var currentColor = Console.ForegroundColor;

        Console.ForegroundColor = LabelColor != null ? (ConsoleColor)LabelColor : currentColor;

        foreach (var label in _ArrayLabel)
        {
            Console.CursorLeft = Position.X + Padding.X;
            Console.WriteLine(label);
        }

        Console.ForegroundColor = currentColor;

        return default;
    }
}
