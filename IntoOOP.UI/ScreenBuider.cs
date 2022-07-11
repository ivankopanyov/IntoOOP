namespace IntoOOP.UI;

/// <summary>Класс строителя экрана интерфейса пользователя.</summary>
public class ScreenBuider
{
    /// <summary>Экземпляр экрана.</summary>
    protected readonly UIScreen _Screen;

    /// <summary>Инициализация класса строителя экрана.</summary>
    /// <param name="size">Размер экрана.</param>
    public ScreenBuider(Point size) => _Screen = new UIScreen(size);

    /// <summary>Создание заголовка экрана.</summary>
    /// <param name="label">Текст заголовка.</param>
    /// <param name="position">Позиция заголовка в строке.</param>
    /// <param name="color">Цвет текста заголовка.</param>
    /// <returns>Заголовок экрана.</returns>
    public UIText CreateHeader(string label, Position position, ConsoleColor color)
    {
        var header = new UIText(label);
        header.Position = new Point(GetPosition(position, header.Width), 0);
        header.Padding = new Point(0, 2);
        header.LabelColor = color;
        return header;
    }

    /// <summary>Создание подвала экрана.</summary>
    /// <param name="label">Текст подвала.</param>
    /// <param name="position">Позиция подвала в строке.</param>
    /// <param name="color">Цвет текста подвала.</param>
    /// <returns>Подвал экрана.</returns>
    public UIText CreateFooter(string label, Position position, ConsoleColor color)
    {
        var footer = new UIText(label);
        footer.LabelColor = color;
        var paddingTop = 0;
        Array.ForEach(_Screen.ToArray(), i => paddingTop += i.Height);
        footer.Position = new Point(GetPosition(position, footer.Width), 0);
        footer.Padding = new Point(0, _Screen.Size.Y - paddingTop - footer.Height - 2);
        return footer;
    }

    /// <summary>Создание кнопки.</summary>
    /// <param name="label">Текст кнопки.</param>
    /// <param name="position">Позиция кнопки в строке.</param>
    /// <param name="color">Цвет текста кнопки.</param>
    /// <param name="prefix">Текст, выводимы перед кнопкой.</param>
    /// <returns>Новый объект кнопки.</returns>
    public UIButton CreateButton(string label, Position position, ConsoleColor color, string prefix = "")
    {
        var button = new UIButton(label);
        button.Prefix = prefix;
        button.Position = new Point(GetPosition(position, button.Width), 0);
        button.LabelColor = color;
        return button;
    }

    /// <summary>Создание кнопки возврата на предыдущий экран.</summary>
    /// <param name="screen">Экран для перехода.</param>
    /// <param name="position">Позиция кнопки в строке.</param>
    /// <param name="color">Цвет текста кнопки.</param>
    /// <returns>Новый объект кнопки возврата на предыдущий экран.</returns>
    public UIButton CreateBackButton(UIScreen screen, Position position, ConsoleColor color)
    {
        var backButton = CreateButton("Назад", position, color);
        backButton.Padding += new Point(0, 1);
        backButton.OnClick += () => screen;
        return backButton;
    }

    /// <summary>Создание кнопки выхода из приложения.</summary>
    /// <param name="position">Позиция кнопки в строке.</param>
    /// <param name="color">Цвет текста кнопки.</param>
    /// <returns>Новый объект кнопки выхода из приложения.</returns>
    public UIButton CreateExitButton(Position position, ConsoleColor color)
    {
        var exitButton = CreateButton("Выход", position, color);
        exitButton.Padding += new Point(0, 1);
        exitButton.OnClick += () => UIScreen.Exit;
        return exitButton;
    }

    /// <summary>Возвращает объект элемента экрана.</summary>
    /// <returns>Новый объект элемента экрана.</returns>
    public UIScreen Build() => _Screen;

    /// <summary>Вычисление горизонтальной координаты элемента на экране.</summary>
    /// <param name="position">Позиция элемента на экране.</param>
    /// <param name="width">Ширина элемента.</param>
    /// <returns>Горизонтальная координата элемента на экране.</returns>
    private int GetPosition(Position position, int width) => position switch
    {
        Position.Right => _Screen.Size.X - width,
        Position.Left => 1,
        Position.Center => (_Screen.Size.X - width) / 2
    };
}
