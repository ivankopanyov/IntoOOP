namespace IntoOOP.UI;

/// <summary>Класс поля ввода.</summary>
public class UIInputField : UIScreenItem
{
    /// <summary>Высота поля ввода без отступов.</summary>
    private const int HEIGHT = 3;

    /// <summary>Делегат метода, выполняемого при при изменении значения в поле ввода.</summary>
    /// <returns>Cледующий экран.</returns>
    public delegate void ChangeValueAction();

    /// <summary>Событие, вызываемое при при окончании ввода.</summary>
    public event ChangeValueAction ChangeValue;

    /// <summary>Делегат метода, выполняемого при окончании ввода.</summary>
    /// <returns>Следующий экран.</returns>
    public delegate void InputEndAction();

    /// <summary>Событие, вызываемое при при окончании ввода.</summary>
    public event InputEndAction InputEnd;

    /// <summary>Текстовое значение ввода.</summary>
    private string _Value = string.Empty;

    /// <summary>Максимальное колличество символов для ввода.</summary>
    private int _Limit = 10;

    /// <summary>Возможен ли фокус на данном элемента.</summary>
    public override bool IsFocusable => true;

    /// <summary>Ширина поля ввода.</summary>
    public override int Width => Padding.X + Label.Length + Limit + 3;

    /// <summary>Высота поля ввода.</summary>
    public override int Height => Padding.Y + HEIGHT;

    /// <summary>Цвет рамки поля ввода.</summary>
    public ConsoleColor? BorderColor { get; set; } = null;

    /// <summary>Цвет текста внутри поля ввода.</summary>
    public ConsoleColor? InputTextColor { get; set; } = null;

    /// <summary>Текстовое значение ввода.</summary>
    public string Value
    {
        get => (InputType == InputType.Int || InputType == InputType.Double) &&
            _Value == string.Empty ? "0" : _Value;

        set
        {
            if (_Value == value) return;

            if (InputType == InputType.Int)
                _Value = !int.TryParse(value, out int _) ? string.Empty : value;
            else if (InputType == InputType.Double)
                _Value = !double.TryParse(value, out double _) ? string.Empty : value;
            else _Value = value;
            if (_Value.Length > _Limit) _Value = _Value.Substring(0, _Limit);
        }
    }

    /// <summary>Максимальное колличество символов для ввода.</summary>
    public int Limit
    {
        get => _Limit;
        set => _Limit = value < 1 ? 1 : value;
    }

    /// <summary>Тип вводимого занчения в поле ввода.</summary>
    public InputType InputType { get; }

    /// <summary>Инициализация объекта поля ввода.</summary>
    /// <param name="label">Текст перед полем ввода.</param>
    public UIInputField(string label = "") : base(label) { }

    /// <summary>Инициализация объекта поля ввода.</summary>
    /// <param name="inputType">Тип вводимого занчения в поле ввода.</param>
    public UIInputField(InputType inputType) : base("") => InputType = inputType;

    /// <summary>Инициализация объекта поля ввода.</summary>
    /// <param name="label">Текст перед полем ввода.</param>
    /// <param name="inputType">Тип вводимого занчения в поле ввода.</param>
    public UIInputField(string label, InputType inputType) : base(label) => InputType = inputType;

    /// <summary>Метод вывода поля ввода в консоль.</summary>
    /// <param name="focus">Установка фокуса на поле ввода.</param>
    /// <returns>Возвращает клавишу завершения ввода.</returns>
    public override ConsoleKey Draw(bool focus)
    {
        Clear();
        Focus = focus;

        var currentColor = Console.ForegroundColor;

        var border = new string('─', _Limit + 1);

        Console.CursorLeft = Position.X + Padding.X + Label.Length;

        if (BorderColor != null) Console.ForegroundColor = (ConsoleColor)BorderColor;
        Console.WriteLine('┌' + border + '┐');

        Console.CursorLeft = Position.X + Padding.X;

        Console.ForegroundColor = LabelColor != null ? (ConsoleColor)LabelColor : currentColor;
        Console.Write(Label);

        Console.ForegroundColor = BorderColor != null ? (ConsoleColor)BorderColor : currentColor;
        Console.Write('│');

        Console.ForegroundColor = InputTextColor != null ? (ConsoleColor)InputTextColor : currentColor;
        Console.Write(_Value);

        Console.CursorLeft += _Limit + 1 - _Value.Length;
        Console.ForegroundColor = BorderColor != null ? (ConsoleColor)BorderColor : currentColor;
        Console.WriteLine('│');

        Console.CursorLeft = Position.X + Padding.X + Label.Length;
        Console.WriteLine('└' + border + '┘');

        Console.ForegroundColor = currentColor;

        if (Focus) return Read();
        return default;
    }

    /// <summary>Метод, выполняемый при нажатии клавиши Enter.</summary>
    /// <returns>Возвращает null.</returns>
    public override UIScreen Click() => null!;

    /// <summary>Вызов события изменения значения в поле ввода.</summary>
    private void ChangeValueEvent()
    {
        Console.CursorVisible = false;
        var cursorPos = new Point(Console.CursorLeft, Console.CursorTop);
        ChangeValue?.Invoke();
        Console.SetCursorPosition(cursorPos.X, cursorPos.Y);
        Console.CursorVisible = true;
    }

    /// <summary>Метод ввода значения в поле ввода.</summary>
    /// <returns>Возвращает клавишу завершения ввода.</returns>
    private ConsoleKey Read()
    {
        Console.CursorVisible = true;
        var currentColor = Console.ForegroundColor;
        if (InputTextColor != null) Console.ForegroundColor = (ConsoleColor)InputTextColor;
        Console.SetCursorPosition(Position.X + Padding.X + Label.Length + _Value.Length + 1, Position.Y + Padding.Y + 1);

        ConsoleKeyInfo key;

        while (true)
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.Enter)
            {
                Console.ForegroundColor = currentColor;
                Console.CursorVisible = false;
                InputEnd?.Invoke();
                return key.Key == ConsoleKey.Enter ? ConsoleKey.DownArrow : key.Key;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (_Value != string.Empty)
                {
                    _Value = _Value.Substring(0, _Value.Length - 1);
                    Console.Write("\b \b");
                    ChangeValueEvent();
                }
            }
            else if (_Value.Length < _Limit && !char.IsControl(key.KeyChar))
            {
                if (InputType == InputType.Int && (!char.IsDigit(key.KeyChar))) continue;

                if (InputType == InputType.Double && !char.IsDigit(key.KeyChar) && key.KeyChar != ',') continue;

                if ((InputType == InputType.Int || (InputType == InputType.Double && key.KeyChar != ',')) &&
                    _Value.Length == 1 && _Value[0] == '0')
                {
                    _Value = key.KeyChar.ToString();
                    Console.Write("\b \b" + key.KeyChar);
                    ChangeValueEvent();
                    continue;
                }

                if (InputType == InputType.Double && key.KeyChar == ',' && _Value.Length == 0)
                {
                    _Value = "0,";
                    Console.Write(_Value);
                    ChangeValueEvent();
                    continue;
                }

                if (InputType == InputType.Double)
                {
                    var inputArr = _Value.Split(',');
                    if (key.KeyChar == ',' && (inputArr.Length > 1 || inputArr[0] == string.Empty)) continue;
                }

                Console.Write(key.KeyChar);
                _Value += key.KeyChar;
                ChangeValueEvent();
            }
        }
    }
}