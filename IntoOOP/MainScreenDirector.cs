using IntoOOP.UI;
using IntoOOP.Builds;

namespace IntoOOP;

/// <summary>Класс строителя главного экрана приложения.</summary>
public class MainScreenDirector : ScreenBuider
{
    /// <summary>Псевдографическое изображение здания.</summary>
    public const string IMAGE =
    "     _______________\n" +
    "    /              /\\\n" +
    "   /              /  \\\n" +
    "  /              / /\\ \\\n" +
    " /              /  \\/  \\\n" +
    "/______________/ /\\  /\\ \\\n" +
    "\\  __ __ __ __ \\ \\/  \\/  \\\n" +
    " \\ \\_\\\\_\\\\_\\\\_\\ \\  /\\  /\\ \\\n" +
    "  \\  __ __ __ __ \\ \\/  \\/  \\\n" +
    "   \\ \\_\\\\_\\\\_\\\\_\\ \\  /\\  /\\\n" +
    "    \\  __ __ __ __ \\ \\/  \\/ \n" +
    "     \\ \\_\\\\_\\\\_\\\\_\\ \\  /\\  /\n" +
    "      \\              \\ \\/  \\";

    /// <summary>Максималное колличество объектов зданий.</summary>
    public const int LIMIT = 15;

    /// <summary>Объект класса строителя экрана редактирования здания.</summary>
    private BuildScreenDirector _BuildScreenDirector;

    /// <summary>Объект, отображающий изображение здания в подвале экрана.</summary>
    private UIText _Image;

    /// <summary>Цвет элементов экрана.</summary>
    private ConsoleColor _Color = ConsoleColor.White;

    /// <summary>Заголовок экрана</summary>
    public UIText Header { get; private set; }

    /// <summary>Кнопка создания нового здания.</summary>
    public UIButton NewBuildButton { get; private set; }

    /// <summary>Размер экрана.</summary>
    public Point Size { get; private set; }

    /// <summary>Главный экран приложения.</summary>
    public UIScreen Screen => _Screen;

    /// <summary>Инициализация класса конструктора главного экрана приложения.</summary>
    /// <param name="size">Размер экрана.</param>
    public MainScreenDirector(Point size) : base(size)
    {
        Size = size;
        _Screen.BorderColor = _Color;
        
        _Screen.AddLast(Header = CreateHeader("<< Проэктировщик зданий >>", Position.Center, _Color));

        NewBuildButton = CreateButton("Новое здание", Position.Center, _Color);
        NewBuildButton.Padding += new Point(0, 2);
        _Screen.AddLast(NewBuildButton);
        NewBuildButton.OnClick += () => CreateBuildButton(Creator.CreateBuild());

        var builds = Creator.Builds;

        foreach (var build in builds)
            CreateBuildButton(build);

        _Screen.AddLast(CreateExitButton(Position.Center, ConsoleColor.Red));

        _Screen.AddLast(_Image = CreateFooter(IMAGE, Position.Right, _Color));
    }

    /// <summary>Создание кнопки для открытия экрана редактированя нового объекта здания.</summary>
    /// <param name="build">Новое здание.</param>
    /// <returns>Экран редактирования здания.</returns>
    private UIScreen CreateBuildButton(Build build)
    {
        var buildButton = CreateButton(build.ToString(), Position.Center, _Color, " > ");
        buildButton.PrefixColor = _Color;
        buildButton.Padding += new Point(0, NewBuildButton.Previous! == Header ? 2 : 0);
        _Screen.AddBefore(NewBuildButton, buildButton);
        _Image.Padding -= new Point(0, buildButton.Height);
        buildButton.OnClick += () => GetBuildScreen(build, buildButton);

        if (Creator.Count == LIMIT)
        {
            NewBuildButton.Next.Padding += new Point(0, 1);
            _Screen.Remove(NewBuildButton);
        }

        return GetBuildScreen(build, buildButton);
    }

    /// <summary>Создание экрана редактирования зданий.</summary>
    /// <param name="build">Здание для редактирования.</param>
    /// <param name="button">Кнопка здания.</param>
    /// <returns>Экран редактирования здания.</returns>
    private UIScreen GetBuildScreen(Build build, UIButton button)
    {
        if (_BuildScreenDirector == null)
        {
            _BuildScreenDirector = new BuildScreenDirector(this, build, button);
            return _BuildScreenDirector.Build();
        }

        return _BuildScreenDirector
            .UpdateScreen(build, button)
            .Build();
    }
}
