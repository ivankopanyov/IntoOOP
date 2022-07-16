namespace IntoOOP.Bank.UI;

/// <summary>Класс, описывающий текст для вывода в элементах экрана пользователя.</summary>
public class UIText
{
    /// <summary>Список элементов для вывода и их цветов. </summary>
    private List<(string text, ConsoleColor color)> _TextList = new();

    /// <summary>Разделитель строк.</summary>
    private char _Separator = ' ';

    /// <summary>Колличество элементов.</summary>
    public int Count => _TextList.Count;

    /// <summary>Колличество символов всех элементов.</summary>
    public int Length { get; private set; }

    /// <summary>Массив элементов текста.</summary>
    public (string text, ConsoleColor color)[] Texts => _TextList.ToArray();

    /// <summary>Добавление нового элемента стандартного цвета в конец списка.</summary>
    /// <param name="text">Текст элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText Add(string text) => Add(text, Console.ForegroundColor);

    /// <summary>Добавление нового элемента в конец списка.</summary>
    /// <param name="text">Текст элемента.</param>
    /// <param name="color">Цвет текста.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText Add(string text, ConsoleColor color)
    {
        if (text == null) text = string.Empty;
        text.Replace('\n', ' ');
        _TextList.Add((text, color));
        Length += text.Length;
        if (_TextList.Count > 1) Length++;
        return this;
    }

    /// <summary>Изменение текста последнего элемента.</summary>
    /// <param name="text">Новый текст.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetText(string text) => SetText(text, _TextList.Count - 1);

    /// <summary>Изменение текста элемента по индексу.</summary>
    /// <param name="text">Новый текст.</param>
    /// <param name="index">Индекс изменяемого элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetText(string text, int index)
    {
        if (index < 0 || index >= _TextList.Count) return this;
        if (text == null) text = string.Empty;
        text.Replace('\n', ' ');
        var temp = _TextList[index];
        _TextList[index] = (text, temp.color);
        Length -= temp.text.Length;
        Length += text.Length;
        return this;
    }

    /// <summary>Изменение цвета текста последнего элемента.</summary>
    /// <param name="color">Новый цвет.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetColor(ConsoleColor color) => SetColor(color, _TextList.Count - 1);

    /// <summary>Изменение цвета текста элемента по индексу.</summary>
    /// <param name="color">Новый цвет.</param>
    /// <param name="index">Индекс изменяемого элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetColor(ConsoleColor color, int index)
    {
        if (index < 0 || index >= _TextList.Count) return this;
        var text = _TextList[index].text;
        _TextList[index] = (text, color);
        return this;
    }

    /// <summary>Вывод текста в консоль.</summary>
    public void Print()
    {
        if (_TextList.Count == 0) return;
        int counter = 0;
        foreach (var text in _TextList)
        {
            if (text.text == null || text.text.Length == 0)
                continue;

            var temp = Console.ForegroundColor;
            Console.ForegroundColor = text.color;
            Console.Write(text.text);
            Console.ForegroundColor = temp;
            if (counter < _TextList.Count - 1)
                Console.Write(_Separator);
        }
    }
}
