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

	/// <summary>
	/// Преобразование файла, содержащего именама и эмейл адреса в файл с эмейл адресами.
	/// </summary>
	/// <param name="source">Файл источник.</param>
	/// <param name="dest">Файл для записи.</param>
	/// <exception cref="ArgumentException">Возбуждается, если не указан путь к файлу источнику или к файлу для записи.</exception>
	/// <exception cref="FileNotFoundException">Возбуждается, если файл источник не найден.</exception>
	public static void WriteAllEmails(string source, string dest)
	{
		if (string.IsNullOrEmpty(source))
			throw new ArgumentException("Не указан путь к источнику.", nameof(source));

		if (string.IsNullOrEmpty(dest))
			throw new ArgumentException("Не указан путь к файлу для записи.", nameof(dest));

		source = source.Trim('\"');

		if (!File.Exists(source))
			throw new FileNotFoundException("Файл источник не найден.");


		using var reader = new StreamReader(source);
		using var writer = new StreamWriter(dest);

		string s;
		while ((s = reader.ReadLine()) != null)
		{
			try
			{
				GetEmail(ref s);
				writer.WriteLine(s);
			}
			catch
			{
				continue;
			}
		}
	}

	/// <summary>
	/// Метод отделения эмейл адреса.
	/// </summary>
	/// <param name="sourceLine">Строка с именем и эмейл адресом.</param>
	/// <exception cref="ArgumentNullException">Возбуждается, если переданная строка не инициализирована.</exception>
	/// <exception cref="ArgumentException">Возбуждается, строка не содержит эмейл адреса.</exception>
	private static void GetEmail(ref string sourceLine)
	{
		if (sourceLine == null)
			throw new ArgumentNullException("Строка не инициализирована.", nameof(sourceLine));

		var array = sourceLine.Split('&');

		if (array.Length < 2)
			throw new ArgumentException("Строка не содержит эмейл адреса.", nameof(sourceLine));

		sourceLine = array[1].Trim();
	}
}
