namespace IntoOOP.Coder;

/// <summary>Класс, описывающий шифратор строки с заменой символа на символ с обратной позицией в алфавите.</summary>
public sealed class BCoder : AlphabetCoder
{
    /// <summary>Шифрование символа.</summary>
    /// <param name="symbol">Символ для шифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для шифрования.</param>
    /// <returns>Зашифрованный символ.</returns>
    protected override char EncodeChar(char symbol, Alphabet alphabet) =>
        !alphabet.Contains(symbol) ? symbol : (char)(alphabet.Start + (alphabet.End - symbol));

    /// <summary>Дешифрование символа.</summary>
    /// <param name="symbol">Символ для дешифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для дешифрования.</param>
    /// <returns>Дешифрованный символ.</returns>
    protected override char DecodeChar(char symbol, Alphabet alphabet) =>
        !alphabet.Contains(symbol) ? symbol : (char)(alphabet.End - (symbol - alphabet.Start));
}
