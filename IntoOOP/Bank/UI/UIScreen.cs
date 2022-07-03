namespace IntoOOP.Bank.UI;

/// <summary>
/// Делегат метода, выполняемого при нажатии на кнопку.
/// </summary>
/// <returns>Возвращает следующий экран.</returns>
public delegate UIScreen OnClick();

/// <summary>
/// Класс экрана.
/// </summary>
public class UIScreen
{
    /// <summary>
    /// Экран для выхода из приложения.
    /// </summary>
    private static UIScreen _exit = new UIScreen(null, null);

    /// <summary>
    /// Экран для выхода из приложения.
    /// </summary>
    public static UIScreen Exit => _exit;

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    private UIText _message = new UIText().Add(string.Empty, ConsoleColor.Red);

    /// <summary>
    /// Дополнительное сообщение.
    /// </summary>
    private UIText _postMessage = new UIText().Add(string.Empty);

    /// <summary>
    /// Заголовок приложения.
    /// </summary>
    private UIText _header;

    /// <summary>
    /// Информация об экране.
    /// </summary>
    public UIText Label { get; private set; }

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public UIText Message => _message;

    /// <summary>
    /// Дополнительное сообщение.
    /// </summary>
    public UIText PostMessage => _postMessage;

    /// <summary>
    /// Список элементов экрана.
    /// </summary>
    private List<UIScreenItem> _items = new();

    /// <summary>
    /// Колличество элементов экрана.
    /// </summary>
    public int Amount => _items.Count;

    /// <summary>
    /// Общая высота заголовков экрана.
    /// </summary>
    private int HeaderHeight => (_header.Length > 0 ? 2 : 0) + (_message.Length > 0 ? 2 : 0) + 
        (Label.Length > 0 ? 2 : 0) + (_postMessage.Length > 0 ? 2 : 0);

    /// <summary>
    /// Конструктор класса экрана.
    /// </summary>
    /// <param name="label">Информация об экране.</param>
    /// <param name="header">Заголовок приложения.</param>
    public UIScreen(UIText label, UIText header)
    {
        Label = label;
        _header = header;
    }

    /// <summary>
    /// Метод добавления элемента на экран.
    /// </summary>
    /// <param name="item">Элемент для добавления на экран.</param>
    /// <param name="index">Индекс куда будет добавлен элемент.</param>
    public void Add(UIScreenItem item, int index = -1)
    {
        if (index < 0 || index >= _items.Count())
        {
            _items.Add(item);
            index = _items.Count() - 1;
        }
        else _items.Insert(index, item);
        Update(index);
    }

    /// <summary>
    /// Удаление элемента экрана.
    /// </summary>
    /// <param name="item">Удаляемый элемент.</param>
    public void Remove(UIScreenItem item)
    {
        var index = _items.IndexOf(item);
        _items.RemoveAt(index);
        Update(index);
    }

    /// <summary>
    /// Вывод экрана в консоль.
    /// </summary>
    public void Show()
    {
        Update(0);
        Console.Clear();

        Console.CursorLeft = 1;
        Console.CursorTop = 0;
        _header.Print();

        Console.CursorLeft = 1;
        Console.CursorTop += 2;
        _message.Print();

        Console.CursorLeft = 1;
        if (_message.Length > 0)
            Console.CursorTop += 2;
        Label.Print();

        Console.CursorLeft = 5;
        Console.CursorTop += 2;
        _postMessage.Print();

        foreach (var item in _items)
            item.Draw(false);
    }

    /// <summary>
    /// Запуск управления элементами экрана.
    /// </summary>
    /// <returns>Возвращает следующий экран.</returns>
    public UIScreen Control()
    {
        int focusIndex = 0;
        ConsoleKey key = _items[focusIndex].Draw(true);
        UIScreen nextScreen;

        while (true)
        {
            while (key != ConsoleKey.DownArrow && key != ConsoleKey.UpArrow && key != ConsoleKey.Enter)
                key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                nextScreen = _items[focusIndex].Click();
                if (nextScreen != null) return nextScreen;
                key = default;
                continue;
            }

            _items[focusIndex].Draw(false);
            if (key == ConsoleKey.DownArrow)
                focusIndex = focusIndex == _items.Count() - 1 ? 0 : ++focusIndex;
            else focusIndex = focusIndex == 0 ? _items.Count() - 1 : --focusIndex;
            key = _items[focusIndex].Draw(true);
        }
    }

    /// <summary>
    /// Обновление позиции элементов экрана.
    /// </summary>
    /// <param name="index">Индекс элмента, с которого начинается обновление.</param>
    private void Update(int index)
    {
        for (int i = index; i < _items.Count(); i++)
            _items[i].LineNumber = index == 0 && i == 0 ? HeaderHeight : _items[i - 1].LineNumber + _items[i - 1].Height;
    }
}
