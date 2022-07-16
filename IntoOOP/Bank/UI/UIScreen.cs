namespace IntoOOP.Bank.UI;

/// <summary>Класс, описывающий экран.</summary>
public class UIScreen
{
    /// <summary>Экран для выхода из приложения.</summary>
    private static UIScreen _exit = new UIScreen();

    /// <summary>Экран для выхода из приложения.</summary>
    public static UIScreen Exit => _exit;

    /// <summary>Заголовок приложения.</summary>
    private UIText _Header = new UIText().Add(string.Empty);

    /// <summary>Информация об экране.</summary>
    private UIText _Label = new UIText().Add(string.Empty);

    /// <summary>Сообщение об ошибке.</summary>
    private UIText _Message = new UIText().Add(string.Empty);

    /// <summary>Дополнительное сообщение.</summary>
    private UIText _PostMessage = new UIText().Add(string.Empty);

    /// <summary>Информация об экране.</summary>
    public UIText Header 
    {
        get => _Header;
        set => _Header = value == null ? new UIText().Add(string.Empty) : value;
    }

    /// <summary>Информация об экране.</summary>
    public UIText Label
    {
        get => _Label;
        set => _Label = value == null ? new UIText().Add(string.Empty) : value;
    }

    /// <summary>Сообщение об ошибке.</summary>
    public UIText Message
    {
        get => _Message;
        set => _Message = value == null ? new UIText().Add(string.Empty) : value;
    }

    /// <summary>Дополнительное сообщение.</summary>
    public UIText PostMessage
    {
        get => _PostMessage;
        set => _PostMessage = value == null ? new UIText().Add(string.Empty) : value;
    }

    /// <summary>Список элементов экрана.</summary>
    private List<UIScreenItem> _items = new();

    /// <summary>Колличество элементов экрана.</summary>
    public int Amount => _items.Count;

    /// <summary>Общая высота заголовков экрана.</summary>
    private int HeaderHeight => (_Header.Length > 0 ? 2 : 0) + (_Message.Length > 0 ? 2 : 0) + 
        (_Label.Length > 0 ? 2 : 0) + (_PostMessage.Length > 0 ? 2 : 0);

    /// <summary>Метод добавления элемента на экран.</summary>
    /// <param name="item">Элемент для добавления на экран.</param>
    /// <param name="index">Индекс куда будет добавлен элемент.</param>
    public void Add(UIScreenItem item, int index = -1)
    {
        if (index < 0 || index >= _items.Count)
        {
            _items.Add(item);
            index = _items.Count - 1;
        }
        else _items.Insert(index, item);
        Update(index);
    }

    /// <summary>Удаление элемента экрана.</summary>
    /// <param name="item">Удаляемый элемент.</param>
    public void Remove(UIText label)
    {
        var index = _items.FindIndex(i => i.Label == label);
        if (index != -1)
        {
            _items.RemoveAt(index);
            Update(index);
        }
    }

    /// <summary>Вывод экрана в консоль.</summary>
    public void Show()
    {
        Update(0);
        Console.Clear();

        Console.SetCursorPosition(1, 0);

        if (_Header.Length > 0)
        {
            _Header.Print();
            Console.SetCursorPosition(1, Console.CursorTop += 2);
        }

        if (_Message.Length > 0)
        {
            _Message.Print();
            Console.SetCursorPosition(1, Console.CursorTop += 2);
        }

        if (_Label.Length > 0)
        {
            _Label.Print();
            Console.SetCursorPosition(5, Console.CursorTop += 2);
        }

        if (_PostMessage.Length > 0)
            _PostMessage.Print();

        foreach (var item in _items)
            item.Draw(false);
    }

    /// <summary>Запуск управления элементами экрана.</summary>
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
                focusIndex = focusIndex == _items.Count - 1 ? 0 : ++focusIndex;
            else focusIndex = focusIndex == 0 ? _items.Count - 1 : --focusIndex;
            key = _items[focusIndex].Draw(true);
        }
    }

    /// <summary>Обновление позиции элементов экрана.</summary>
    /// <param name="index">Индекс элмента, с которого начинается обновление.</param>
    private void Update(int index)
    {
        for (int i = index; i < _items.Count; i++)
            if (index == 0 && i == 0)
                _items[i].Position = new Point(_items[i].Position.X, HeaderHeight);
            else
                _items[i].Position = new Point(0, _items[i - 1].Position.Y + _items[i - 1].Height);
    }
}
