using IntoOOP.UI;

namespace IntoOOP.Coder.UI;

/// <summary>Строитель экрана шифратора.</summary>
public class CoderScreenBuilder : ScreenBuider
{
    /// <summary>Префикс для кнопок экрана.</summary>
    private const string PREFIX = " >>> ";

    /// <summary>Инициализация объекта строителя экрана.</summary>
    /// <param name="size">Размер экрана.</param>
    public CoderScreenBuilder(Point size) : base(size)
    {
        var alphabets = new Alphabet[] {
            Alphabet.Numbers,
            Alphabet.EnLowerCase,
            Alphabet.EnUpperCase,
            Alphabet.RuLowerCase,
            Alphabet.RuUpperCase
        };

        var aCoder = new ACoder();
        aCoder.AddAlphabets(alphabets);

        var bCoder = new BCoder();
        bCoder.AddAlphabets(alphabets);

        _Screen.ShowBorder = false;

        _Screen.AddLast(CreateHeader("-= Шифрование / Дешифрование =-", Position.Center, Console.ForegroundColor));

        var inputField = new UIInputField();
        inputField.Label = "Введите строку: ";
        inputField.Padding = new Point(2, 2);
        inputField.Limit = size.X - inputField.Label.Length - 7;
        _Screen.AddLast(inputField);

        var aEncodeButton = CreateButton("Шифратор A", Position.Left, Console.ForegroundColor, PREFIX);
        aEncodeButton.Padding = new Point(aEncodeButton.Padding.X, 1);
        aEncodeButton.OnClick += () =>
        {
            inputField.Value = Encode(inputField.Value, aCoder);
            inputField.Draw(false);
            return null!;
        };
        _Screen.AddLast(aEncodeButton);

        var aDecodeButton = CreateButton("Дешифратор A", Position.Left, Console.ForegroundColor, PREFIX);
        aDecodeButton.OnClick += () =>
        {
            inputField.Value = Decode(inputField.Value, aCoder);
            inputField.Draw(false);
            return null!;
        };
        _Screen.AddLast(aDecodeButton);

        var bEncodeButton = CreateButton("Шифратор B", Position.Left, Console.ForegroundColor, PREFIX);
        bEncodeButton.Padding = new Point(bEncodeButton.Padding.X, 1);
        bEncodeButton.OnClick += () =>
        {
            inputField.Value = Encode(inputField.Value, bCoder);
            inputField.Draw(false);
            return null!;
        };
        _Screen.AddLast(bEncodeButton);

        var bDecodeButton = CreateButton("Дешифратор B", Position.Left, Console.ForegroundColor, PREFIX);
        bDecodeButton.OnClick += () =>
        {
            inputField.Value = Decode(inputField.Value, bCoder);
            inputField.Draw(false);
            return null!;
        };
        _Screen.AddLast(bDecodeButton);

        var exitButton = CreateExitButton(Position.Left, ConsoleColor.Red);
        exitButton.Prefix = PREFIX;
        _Screen.AddLast(exitButton);
    }

    /// <summary>Шифрование строки.</summary>
    /// <param name="value">Строка для шифрования.</param>
    /// <param name="coder">Шифратор.</param>
    /// <returns>Зашифрованная строка.</returns>
    private static string Encode(string value, ICoder coder) => coder.Encode(value);

    /// <summary>Дешифрование строки.</summary>
    /// <param name="value">Строка для шифрования.</param>
    /// <param name="coder">Дешифратор.</param>
    /// <returns>Дешифрованная строка.</returns>
    private static string Decode(string value, ICoder coder) => coder.Decode(value);
}
