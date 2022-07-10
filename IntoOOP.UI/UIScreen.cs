using System.Collections;

namespace IntoOOP.UI;

/// <summary>Класс экрана.</summary>
public class UIScreen : IEnumerable<UIScreenItem>
{
    /// <summary>Экран для выхода из приложения.</summary>
    private static readonly UIScreen _Exit = new UIScreen(new UIPoint(1, 1));

    /// <summary>Экран для выхода из приложения.</summary>
    public static UIScreen Exit => _Exit;

    /// <summary>Размер экрана.</summary>
    public UIPoint Size { get; }

    /// <summary>Колличество элемментов экрана.</summary>
    public int Count { get; private set; }

    /// <summary>Первый элемент экрана.</summary>
    public UIScreenItem First { get; private set; }

    /// <summary>Последний элемент экрана.</summary>
    public UIScreenItem Last { get; private set; }

    /// <summary>Цвет рамки экрана.</summary>
    public ConsoleColor? BorderColor { get; set; } = null!;

    /// <summary>Отображение рамки экрана.</summary>
    public bool ShowBorder { get; set; } = true;

    /// <summary>Инициализация объекта экрана.</summary>
    /// <param name="size">Размер экрана.</param>
    /// <exception cref="ArgumentOutOfRangeException">Возбуждается, если переданное значение экрана 
    /// содержит координату меньше или равную нулю.</exception>
    public UIScreen(UIPoint size)
    {
        if (size.X <= 0 || size.Y <= 0)
            throw new ArgumentOutOfRangeException("Размер экрана должен быть больше нуля.", nameof(size));

        Size = size;
    }

    /// <summary>Добавление элемента экрана после указанного элемента.</summary>
    /// <param name="item">Элемент, после которого добавляется новый элемент.</param>
    /// <param name="newItem">Новый элемент.</param>
    /// <exception cref="ArgumentNullException">Возбуждается, если передан неинициализированный элемент.</exception>
    /// <exception cref="ArgumentException">Возбуждается, если элемент не содержится в экране,
    /// или новый элемент уже содержится в экране.</exception>
    public void AddAfter(UIScreenItem item, UIScreenItem newItem)
    {
        if (item == null) throw new ArgumentNullException("Элемент не инициализирован", nameof(item));
        if (newItem == null) throw new ArgumentNullException("Новый элемент не инициализирован", nameof(newItem));
        if (item.Screen != this) throw new ArgumentException("Элемент не содержится в экземпляре экрана.", nameof(item));
        if (newItem.Screen != null) throw new ArgumentException("Новый элемент уже содержится в экземпляре экрана.", 
            nameof(newItem));

        if (item == Last)
        {
            AddLast(newItem);
            return;
        }

        newItem.Next = item.Next;
        newItem.Previous = item;
        item.Next.Previous = newItem;
        item.Next = newItem;
        newItem.Screen = this;
        Count++;
    }

    /// <summary>Добавление элемента экрана перед указанным элементом.</summary>
    /// <param name="item">Элемент, перед которым добавляется новый элемент.</param>
    /// <param name="newItem">Новый элемент.</param>
    /// <exception cref="ArgumentNullException">Возбуждается, если передан неинициализированный элемент.</exception>
    /// <exception cref="ArgumentException">Возбуждается, если элемент не содержится в экране,
    /// или новый элемент уже содержится в экране.</exception>
    public void AddBefore(UIScreenItem item, UIScreenItem newItem)
    {
        if (item == null) throw new ArgumentNullException("Элемент не инициализирован", nameof(item));
        if (newItem == null) throw new ArgumentNullException("Новый элемент не инициализирован", nameof(newItem));
        if (item.Screen != this) throw new ArgumentException("Элемент не содержится в экземпляре экрана.", nameof(item));
        if (newItem.Screen != null) throw new ArgumentException("Новый элемент уже содержится в экземпляре экрана.",
            nameof(newItem));

        if (item == First)
        {
            AddFirst(newItem);
            return;
        }

        newItem.Previous = item.Previous;
        newItem.Next = item;
        item.Previous.Next = newItem;
        item.Previous = newItem;
        newItem.Screen = this;
        Count++;
    }

    /// <summary>Добавление элемента в начало экрана.</summary>
    /// <param name="item">Новый эемент.</param>
    /// <exception cref="ArgumentNullException">Возбуждается, если передан неинициализированный элемент.</exception>
    /// <exception cref="ArgumentException">Возбуждается, если элемент уже содержится в экране.</exception>
    public void AddFirst(UIScreenItem item)
    {
        if (item == null) throw new ArgumentNullException("Элемент не инициализирован", nameof(item));
        if (item.Screen != null) throw new ArgumentException("Элемент уже содержится в экземпляре экрана.",
            nameof(item));

        if (First != null)
        {
            First.Previous = item;
            item.Next = First;
        }
        else Last = item;

        First = item;
        item.Screen = this;
        Count++;
    }

    /// <summary>Добавление элемента в конец экрана.</summary>
    /// <param name="item">Новый эемент.</param>
    /// <exception cref="ArgumentNullException">Возбуждается, если передан неинициализированный элемент.</exception>
    /// <exception cref="ArgumentException">Возбуждается, если элемент уже содержится в экране.</exception>
    public void AddLast(UIScreenItem item)
    {
        if (item == null) throw new ArgumentNullException("Элемент не инициализирован", nameof(item));
        if (item.Screen != null) throw new ArgumentException("Элемент уже содержится в экземпляре экрана.",
            nameof(item));

        if (Last != null)
        {
            Last.Next = item;
            item.Previous = Last;
        }
        else First = item;

        Last = item;
        item.Screen = this;
        Count++;
    }

    /// <summary>Удаление элемета экрана.</summary>
    /// <param name="item">Удаляемый элемент.</param>
    public void Remove(UIScreenItem item)
    {
        if (item == null || item.Screen != this)
            return;

        if (item.Previous != null)
            item.Previous.Next = item.Next;
        else First = item.Next;

        if (item.Next != null)
            item.Next.Previous = item.Previous!;
        else Last = item.Previous!;

        item.Previous = null!;
        item.Next = null!;
        item.Screen = null!;

        Count--;
    }

    /// <summary>Вывод экрана в консоль.</summary>
    public void Show()
    {
        Update();
        Console.Clear();

        foreach (var item in this)
            item.Draw(false);

        if (ShowBorder) DrawBorder();
    }

    /// <summary>Запуск управления элементами экрана.</summary>
    /// <returns>Возвращает следующий экран.</returns>
    public UIScreen Control()
    {
        if (First == null) return this;

        UIScreenItem focusedItem = null!;

        foreach (var item in this)
        {
            if (item.IsFocusable)
            {
                focusedItem = item;
                break;
            }
        }

        if (focusedItem == null) return this;

        ConsoleKey key = focusedItem!.Draw(true);
        UIScreen nextScreen;

        while (true)
        {
            while (key != ConsoleKey.DownArrow && key != ConsoleKey.UpArrow && key != ConsoleKey.Enter)
                key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                nextScreen = focusedItem.Click();
                if (nextScreen != null) return nextScreen;
                key = default;
                continue;
            }

            focusedItem.Draw(false);

            focusedItem = key == ConsoleKey.DownArrow ? (focusedItem.Next ?? First!)
                : (focusedItem.Previous ?? Last!);

            while (!focusedItem!.IsFocusable)
            {
                if (focusedItem.IsFocusable) break;
                focusedItem = key == ConsoleKey.DownArrow ? (focusedItem.Next ?? First!)
                : (focusedItem.Previous ?? Last!);
            }

            key = focusedItem.Draw(true);
        }
    }

    /// <summary>Отрисовка рамки экрана.</summary>
    private void DrawBorder()
    {
        Console.SetCursorPosition(0, 0);
        var currentColor = Console.ForegroundColor;

        if (BorderColor != null)
            Console.ForegroundColor = (ConsoleColor)BorderColor!;

        var border = new string('─', Size.X - 2);
        Console.WriteLine('┌' + border + '┐');
        for (Console.CursorTop = 1; Console.CursorTop < Size.Y - 2; Console.CursorTop++)
        {
            Console.CursorLeft = 0;
            Console.Write('│');
            Console.CursorLeft = Size.X - 1;
            Console.Write('│');
        }
        Console.CursorLeft = 0;
        Console.WriteLine('└' + border + '┘');
        Console.ForegroundColor = currentColor;
    }

    /// <summary>Обновление позиции элементов экрана.</summary>
    private void Update()
    {
        foreach (var item in this)
            item.Position = item == First ? new UIPoint(item.Position.X, 0) : new UIPoint(item.Position.X, item.Previous!.Position.Y + item.Previous.Height);
    }

    #region IEnumerable

    public IEnumerator<UIScreenItem> GetEnumerator()
    {
        var item = First;
        while (item is not null)
        {
            yield return item;
            item = item.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}