namespace IntoOOP.Bank.UI;

/// <summary>
/// Текст для вывода в элементах экрана пользователя.
/// </summary>
public class UIText
{
    /// <summary>
    /// Список элементов для вывода и их цветов.
    /// </summary>
    private List<(string text, ConsoleColor color)> _textList = new();

    /// <summary>
    /// Разделитель строк.
    /// </summary>
    private char _separator = ' ';

    /// <summary>
    /// Колличество элементов.
    /// </summary>
    public int Count => _textList.Count;

    /// <summary>
    /// Колличество символов всех элементов.
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// Массив элементов текста.
    /// </summary>
    public (string text, ConsoleColor color)[] Texts => _textList.ToArray();

    /// <summary>
    /// Добавление нового элемента стандартного цвета в конец списка.
    /// </summary>
    /// <param name="text">Текст элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText Add(string text) => Add(text, Console.ForegroundColor);

    /// <summary>
    /// Добавление нового элемента в конец списка.
    /// </summary>
    /// <param name="text">Текст элемента.</param>
    /// <param name="color">Цвет текста.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText Add(string text, ConsoleColor color)
    {
        if (text == null) text = string.Empty;
        text.Replace('\n', ' ');
        _textList.Add((text, color));
        Length += text.Length;
        if (_textList.Count > 1) Length++;
        return this;
    }

    /// <summary>
    /// Изменение текста последнего элемента.
    /// </summary>
    /// <param name="text">Новый текст.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetText(string text) => SetText(text, _textList.Count - 1);

    /// <summary>
    /// Изменение текста элемента по индексу.
    /// </summary>
    /// <param name="text">Новый текст.</param>
    /// <param name="index">Индекс изменяемого элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetText(string text, int index)
    {
        if (index < 0 || index >= _textList.Count) return this;
        if (text == null) text = string.Empty;
        text.Replace('\n', ' ');
        var temp = _textList[index];
        _textList[index] = (text, temp.color);
        Length -= temp.text.Length;
        Length += text.Length;
        return this;
    }

    /// <summary>
    /// Изменение цвета текста последнего элемента.
    /// </summary>
    /// <param name="color">Новый цвет.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetColor(ConsoleColor color) => SetColor(color, _textList.Count - 1);

    /// <summary>
    /// Изменение цвета текста элемента по индексу.
    /// </summary>
    /// <param name="color">Новый цвет.</param>
    /// <param name="index">Индекс изменяемого элемента.</param>
    /// <returns>Экземпляр класса текста.</returns>
    public UIText SetColor(ConsoleColor color, int index)
    {
        if (index < 0 || index >= _textList.Count) return this;
        var text = _textList[index].text;
        _textList[index] = (text, color);
        return this;
    }

    /// <summary>
    /// Вывод текста в консоль.
    /// </summary>
    public void Print()
    {
        if (_textList.Count == 0) return;
        int counter = 0;
        foreach (var text in _textList)
        {
            if (text.text == null || text.text.Length == 0)
                continue;

            var temp = Console.ForegroundColor;
            Console.ForegroundColor = text.color;
            Console.Write(text.text);
            Console.ForegroundColor = temp;
            if (counter < _textList.Count - 1)
                Console.Write(_separator);
        }
    }
}
