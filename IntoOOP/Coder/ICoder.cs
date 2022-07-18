namespace IntoOOP.Coder;

/// <summary>Шифратор строк.</summary>
public interface ICoder
{
    /// <summary>Шифрование строки.</summary>
    /// <param name="value">Строка для шифрования.</param>
    /// <returns>Зашифрованная строка.</returns>
    string Encode(string value);

    /// <summary>Дешифрование строки.</summary>
    /// <param name="value">Строка для дешифрования.</param>
    /// <returns>Дешифрованная строка.</returns>
    string Decode(string value);
}
