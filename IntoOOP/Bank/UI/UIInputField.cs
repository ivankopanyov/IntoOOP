namespace IntoOOP.Bank.UI;

/// <summary>
/// Класс поля ввода числа.
/// </summary>
public class UIInputField : UIScreenItem
{
    /// <summary>
    /// Максимальное колличество символов для ввода.
    /// </summary>
    private const int LIMIT = 50;

    /// <summary>
    /// Позиция начала ввода.
    /// </summary>
    private Point _cursorPos;

    /// <summary>
    /// Текстовое значение ввода.
    /// </summary>
    private string _value = string.Empty;

    /// <summary>
    /// Высота поля ввода.
    /// </summary>
    public override int Height => Padding.Y + 3;

    /// <summary>
    /// Числовое значение ввода.
    /// </summary>
    public decimal Value => _value == string.Empty || _value == "," ? 0 : decimal.Parse(_value);

    /// <summary>
    /// Ширина поля ввода.
    /// </summary>
    public override int Width => Label.Length + LIMIT + 5;

    /// <summary>
    /// Конструктор класса поля ввода.
    /// </summary>
    /// <param name="label">Текст, выводимый перед полем ввода.</param>
    /// <param name="padding">Отступы.</param>
    public UIInputField(UIText label, Point padding) : base(label, padding) => 
        _cursorPos = new Point(Label.Length + Padding.X + 3, _cursorPos.Y);

    /// <summary>
    /// Метод вывода поля ввода в консоль.
    /// </summary>
    /// <param name="focus">Установка фокуса на поле ввода.</param>
    /// <returns>Возвращает клавишу завершения ввода.</returns>
    public override ConsoleKey Draw(bool focus)
    {
        Clear();
        Focus = focus;
        var border = new string('─', LIMIT + 1);

        Console.CursorLeft = Padding.X + Label.Length + 2;
        Console.WriteLine('┌' + border + '┐');

        Console.CursorLeft = Padding.X;
        Label.Print();
        Console.Write(": │" + _value);
        Console.CursorLeft += LIMIT + 1 - _value.Length;
        Console.WriteLine('│');

        Console.CursorLeft = Padding.X + Label.Length + 2;
        Console.WriteLine('└' + border + '┘');

        _cursorPos = new Point(_cursorPos.X, Position.Y + 1);

        if (Focus) return Read();
        return default;
    }

    /// <summary>
    /// Метод, выполняемый при нажатии клавиши Enter.
    /// </summary>
    /// <returns>Возвращает null.</returns>
    public override UIScreen Click() => null;

    /// <summary>
    /// Метод ввода значения в поле ввода.
    /// </summary>
    /// <returns>Возвращает клавишу завершения ввода.</returns>
    private ConsoleKey Read()
    {
        Console.CursorVisible = true;
        Console.SetCursorPosition(_cursorPos.X + _value.Length, _cursorPos.Y);

        ConsoleKeyInfo key;

        while (true)
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
            {
                Console.CursorVisible = false;
                return key.Key;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (_value != string.Empty)
                {
                    _value = _value.Substring(0, _value.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (_value.Length < LIMIT && (char.IsDigit(key.KeyChar) || key.KeyChar == ','))
            {
                if (key.KeyChar == '0' && _value == string.Empty) continue;

                var inputArr = _value.Split(',');

                if ((key.KeyChar == ',' && (inputArr.Length > 1 || inputArr[0] == string.Empty)) ||
                    inputArr.Length > 1 && inputArr[1].Length == 2) continue;

                Console.Write(key.KeyChar);
                _value += key.KeyChar;
            }
        }
    }
}

