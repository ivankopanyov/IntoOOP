namespace IntoOOP.Text;

/// <summary>
/// Класс для работы с текстом.
/// </summary>
public static class TextHandler
{
	/// <summary>
	/// Метод разворота строки.
	/// </summary>
	/// <param name="str">Строка для разворота.</param>
	/// <returns>Развернутая строка.</returns>
	public static string Reverse(string str)
	{
		if (string.IsNullOrWhiteSpace(str) || str.Length == 1 || IsPalindrom(str)) return str;

		var strArr = str.ToCharArray();

		for (int i = 0; i < strArr.Length / 2; i++)
		{
			var temp = strArr[strArr.Length - i - 1];
			strArr[strArr.Length - i - 1] = strArr[i];
			strArr[i] = temp;
		}

		return new string(strArr);
	}

	/// <summary>
	/// Проверка строки на палиндром.
	/// </summary>
	/// <param name="str">Строка для проверки.</param>
	/// <returns>Результат проверки.</returns>
	private static bool IsPalindrom(in string str)
	{
		for (int i = 0; i < str.Length / 2; i++)
			if (str[i] != str[str.Length - i - 1])
				return false;

		return true;
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
