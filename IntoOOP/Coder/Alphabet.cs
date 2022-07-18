namespace IntoOOP.Coder;

/// <summary>Структура, описывающая алфавит.</summary>
public readonly struct Alphabet
{
    /// <summary>Символы цифр.</summary>
    public static Alphabet Numbers => new Alphabet('0', '9');

    /// <summary>Символы букв английского алфавита в верхнем регистре.</summary>
    public static Alphabet EnUpperCase => new Alphabet('A', 'Z');

    /// <summary>Символы букв английского алфавита в нижнем регистре.</summary>
    public static Alphabet EnLowerCase => new Alphabet('a', 'z');

    /// <summary>Символы букв русского алфавита в верхнем регистре.</summary>
    public static Alphabet RuUpperCase => new Alphabet('А', 'Я');

    /// <summary>Символы букв русского алфавита в нижнем регистре.</summary>
    public static Alphabet RuLowerCase => new Alphabet('а', 'я');

    /// <summary>Первый символ алфавита.</summary>
    public char Start { get; init; }

    /// <summary>Последний символ алфавита.</summary>
    public char End { get; init; }

    /// <summary>Инициализация алфавита.</summary>
    /// <param name="start">Первый символ алфавита.</param>
    /// <param name="end">Последний символ алфавита.</param>
    /// <exception cref="ArgumentOutOfRangeException">Возбуждается, если номер 
    /// последнего символа меньше номера первого символа.</exception>
    public Alphabet(char start, char end)
    {
        if (end < start)
            throw new ArgumentOutOfRangeException(nameof(end));

        Start = start;
        End = end;
    }

    /// <summary>Проверка вхождения символа в алфавит.</summary>
    /// <param name="symbol">Проверяемый символа.</param>
    /// <returns>Результат проверки.</returns>
    public bool Contains(char symbol) => symbol >= Start && symbol <= End;

    /// <summary>Проверка пересечения символов в алфавитах.</summary>
    /// <param name="left">Алфавит для проверки пересечения.</param>
    /// <param name="right">Алфавит для проверки пересечения.</param>
    /// <returns>Результат проверки.</returns>
    public static bool Intersection(Alphabet left, Alphabet right) => left.Contains(right.Start) || left.Contains(right.End);

    /// <summary>Приведение алфавита к типу строки.</summary>
    /// <returns>Строка с первым и последним символами алфавита.</returns>
    public override string ToString() => $"{Start}-{End}";
}
