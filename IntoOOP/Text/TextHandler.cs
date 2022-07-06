namespace IntoOOP.Text;

/// <summary>
/// Класс для работы с текстом.
/// </summary>
public static class TextHandler
{
    /// <summary>
    /// Метод разворота строки.
    /// </summary>
    /// <param name="source">Строка для разворота.</param>
    /// <returns>Перевернутая строка.</returns>
    public static string Reverse(string source)
    {
        if (source == null || source.Length < 2)
            return source;

        char[] charArray = source.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
