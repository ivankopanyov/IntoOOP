using IntoOOP.Draw;

namespace IntoOOP.ConsoleDraw;

/// <summary>Экран отображения геометрических фигур.</summary>
public class ConsoleScreen
{
    /// <summary>Символ отрисовки фигуры.</summary>
    private const char _Symbol = '█';

    /// <summary>Состояние видимости экрана.</summary>
    private bool _IsShow;

    /// <summary>Список геометрических фигур.</summary>
    private List<Figure> _Figures = new();

    /// <summary>Подвал экрана с информацией.</summary>
    private string _Footer = string.Empty;

    /// <summary>Высота области вывода фигуры.</summary>
    private int _DrawAreaHeight = Console.WindowHeight - 3;

    /// <summary>Текущая отображаемая фигура.</summary>
    private Figure _CurrentFigure = null!;

    /// <summary>Начальная позиция новой фигуры.</summary>
    private Vector _StartPos => new Vector(Console.WindowWidth / 4, _DrawAreaHeight / 2);

    /// <summary>Рамка подвала экрана.</summary>
    private string _Border = string.Empty;

    /// <summary>Длина строки описания фигуры.</summary>
    private int _InfoLength;

    /// <summary>Состояние видимости экрана.</summary>
    public bool IsShow
    { 
        get => _IsShow;
        set
        {
            if (value == _IsShow) return;

            Console.Clear();
            if (value) Draw();
            _IsShow = value;
        }
    }

    /// <summary>Подвал экрана с информацией.</summary>
    public string Footer
    {
        get => _Footer;
        set
        {
            if (value == _Footer) return;

            if (string.IsNullOrEmpty(value))
            {
                _Footer = string.Empty;
                _DrawAreaHeight = Console.WindowHeight - 3;
            }
            else
            {
                _Footer = value;
                _DrawAreaHeight = Console.WindowHeight - _Footer.Split('\n').Length - 3;
            }

            if (_IsShow) DrawFooter();
        }
    }

    /// <summary>Рамка подвала экрана.</summary>
    private string Border
    {
        get
        {
            if (_Border.Length != Console.WindowWidth)
                _Border = new string('─', Console.WindowWidth);

            return _Border;
        }
    }

    /// <summary>Добавление точки.</summary>
    public void AddPoint() => Add(new ConsolePoint());

    /// <summary>Добавление окружности.</summary>
    public void AddCircle() => Add(new ConsoleCircle(4));

    /// <summary>Добавление прямоугольника.</summary>
    public void AddRectangle() => Add(new ConsoleRectangle(4, 4));

    /// <summary>Выполнение действия нажатой клавишы.</summary>
    /// <param name="key">Нажатая клавиша.</param>
    public void KeyDown(ConsoleKey key)
    {
        if (_CurrentFigure is null) return;

        switch (key)
        {
            case ConsoleKey.D1: SetCurrentFigure(0); break;
            case ConsoleKey.D2: SetCurrentFigure(1); break;
            case ConsoleKey.D3: SetCurrentFigure(2); break;
            case ConsoleKey.UpArrow: Move(Vector.Up); break;
            case ConsoleKey.DownArrow: Move(Vector.Down); break;
            case ConsoleKey.LeftArrow: Move(Vector.Left); break;
            case ConsoleKey.RightArrow: Move(Vector.Right); break;
            case ConsoleKey.R: SetColor(Color.Red); break;
            case ConsoleKey.G: SetColor(Color.Green); break;
            case ConsoleKey.B: SetColor(Color.Blue); break;
            case ConsoleKey.OemPlus: SetSize(1); break;
            case ConsoleKey.OemMinus: SetSize(-1); break;
        }
    }

    /// <summary>Добавление нового объекта фигуры.</summary>
    /// <param name="figure">Новый объект фигуры.</param>
    private void Add(Figure figure)
    {
        figure.Pos = _StartPos;
        figure.Color = Color.Blue;
        _Figures.Add(figure);

        if (_CurrentFigure == null)
        {
            _CurrentFigure = figure;
            if (IsShow) Draw();
        }
    }

    /// <summary>Установка отображаемой фигуры по индексу.</summary>
    /// <param name="index">Индекс фигуры в списке.</param>
    private void SetCurrentFigure(int index)
    {
        if (index < 0 || index >= _Figures!.Count || _CurrentFigure == _Figures[index]) return;

        if (IsShow) Clear();

        _CurrentFigure = _Figures[index];
        if (IsShow) Draw();
    }

    /// <summary>Изменение позиции текущей отображаемой фигуры.</summary>
    /// <param name="vector">Вектор изменения позиции.</param>
    private void Move(Vector vector)
    {
        if (vector == Vector.Zero) return;

        if (IsShow) Clear();

        _CurrentFigure.Pos += vector;
        if (IsShow) Draw();
    }

    /// <summary>Изменение цвета текущей отображаемой фигуры.</summary>
    /// <param name="color">Новый цвет.</param>
    private void SetColor(Color color)
    {
        if (color == _CurrentFigure.Color) return;

        _CurrentFigure.Color = color;
        if (IsShow) Draw();
    }

    /// <summary>Изменение размера текущей отображаемой фигуры.</summary>
    /// <param name="addValue">Добавляемое значение.</param>
    private void SetSize(int addValue)
    {
        var type = _CurrentFigure.GetType();
        if (type == typeof(ConsolePoint)) return;

        if (type == typeof(ConsoleCircle))
        {
            var circle = (ConsoleCircle)_CurrentFigure;
            if (addValue == 0 || circle.Radius + addValue < 0) return;

            if (IsShow && addValue < 0) Clear();

            circle.Radius += addValue;
            if (IsShow) Draw();
            return;
        }

        if (type == typeof(ConsoleRectangle))
        {
            var rectangle = (ConsoleRectangle)_CurrentFigure;
            if (addValue == 0 || rectangle.Size.X + addValue < 0 || rectangle.Size.Y + addValue < 0) return;

            if (IsShow && addValue < 0) Clear();

            rectangle.Size += Vector.One * addValue;
            if (IsShow) Draw();
            return;
        }
    }

    /// <summary>Очистка области отображения фигуры.</summary>
    private void Clear() => Draw(' ');

    /// <summary>Отображение фигуры на экране.</summary>
    private void Draw(char symbol = _Symbol)
    {
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

        if (_CurrentFigure is not null) 
            _CurrentFigure.Draw(Vector.Zero, new Vector(Console.WindowWidth, _DrawAreaHeight), symbol);

        DrawFooter();
    }

    /// <summary>Отображение подвала на экране.</summary>
    private void DrawFooter()
    {
        if (_DrawAreaHeight < 0) return;

        Console.SetCursorPosition(0, _DrawAreaHeight);
        Console.WriteLine(Border);

        var info = _CurrentFigure!.ToString();
        Console.Write(info);
        if (info.Length < _InfoLength)
            for (int i = 0; i < _InfoLength - info.Length; i++)
                Console.Write(' ');

        _InfoLength = info.Length;
        Console.WriteLine('\n');
        Console.Write(_Footer);
    }
}
