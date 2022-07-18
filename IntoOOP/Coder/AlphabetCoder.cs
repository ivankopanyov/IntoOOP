namespace IntoOOP.Coder;

/// <summary>Класс, описывающий алфавитный шифратор строк.</summary>
public abstract class AlphabetCoder : ICoder
{
    /// <summary>Список включенных алфавитов.</summary>
    private List<Alphabet> _Alphabets = new();

    /// <summary>Добавление алфавита.</summary>
    /// <param name="alphabet">Алфавит для добавления.</param>
    /// <returns>False, если алфавит не добавлен из-за пересечения 
    /// символов с уже включенным алфавитом.</returns>
    public bool AddAlphabet(Alphabet alphabet)
    {
        if (_Alphabets.Count == 0)
        { 
            _Alphabets.Add(alphabet);
            return true;
        }

        if (Intersection(alphabet) != null) return false;

        _Alphabets.Add(alphabet);
        return true;
    }

    /// <summary>Добавление алфавитов.</summary>
    /// <param name="alphabets">Алфавиты.</param>
    /// <returns>False, если хотя бы один алфавит не добавлен из-за 
    /// пересечения символов с уже включенным алфавитом.</returns>
    public bool AddAlphabets(params Alphabet[] alphabets)
    {
        var result = true;

        foreach (var alphabet in alphabets)
            if (!AddAlphabet(alphabet)) result = false;
            
        return result;
    }

    /// <summary>Проверка на содержание пересекающегося алфавита с переданным алфавитом.</summary>
    /// <param name="alphabet">Алфавит для проверки.</param>
    /// <returns>Если пересечение найдено, возвращает пересекающийся алфавит.</returns>
    public Alphabet? Intersection(Alphabet alphabet)
    {
        foreach (var item in _Alphabets)
            if (Alphabet.Intersection(item, alphabet))
                return item;

        return null;
    }

    /// <summary>Шифрование строки.</summary>
    /// <param name="value">Строка для шифрования.</param>
    /// <returns>Зашифрованная строка.</returns>
    public string Encode(string value) => Process(value, ProcessType.Encode);

    /// <summary>Дешифрование строки.</summary>
    /// <param name="value">Строка для дешифрования.</param>
    /// <returns>Дешифрованная строка.</returns>
    public string Decode(string value) => Process(value, ProcessType.Decode);

    /// <summary>Шифрование символа.</summary>
    /// <param name="symbol">Символ для шифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для шифрования.</param>
    /// <returns>Зашифрованный символ.</returns>
    protected abstract char EncodeChar(char symbol, Alphabet alphabet);

    /// <summary>Дешифрование символа.</summary>
    /// <param name="symbol">Символ для дешифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для дешифрования.</param>
    /// <returns>Дешифрованный символ.</returns>
    protected abstract char DecodeChar(char symbol, Alphabet alphabet);

    /// <summary>Процесс шифрования или дешифрования строки.</summary>
    /// <param name="value">Строка для шифрования или дешифрования.</param>
    /// <param name="type">Тип процесса.</param>
    /// <returns>Результат процесса.</returns>
    private string Process(string value, ProcessType type)
    {
        if (string.IsNullOrWhiteSpace(value) || _Alphabets.Count == 0) return value;

        var result = new char[value.Length];

        for (int i = 0; i < value.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < _Alphabets!.Count; j++)
            {
                if (_Alphabets[j].Contains(value[i]))
                {
                    result[i] = type == ProcessType.Encode ? EncodeChar(value[i], _Alphabets[j]) :
                        DecodeChar(value[i], _Alphabets[j]);
                    found = true;
                    break;
                }
            }
            if (!found) result[i] = value[i];
        }

        return new string(result);
    }
}
