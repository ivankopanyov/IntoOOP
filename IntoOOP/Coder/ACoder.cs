namespace IntoOOP.Coder;

/// <summary>Класс, описывающий шифратор строки с заменой символа на следующий символ в алфавите.</summary>
public sealed class ACoder : AlphabetCoder
{
    /// <summary>Шифрование символа.</summary>
    /// <param name="symbol">Символ для шифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для шифрования.</param>
    /// <returns>Зашифрованный символ.</returns>
    protected override char EncodeChar(char symbol, Alphabet alphabet)
    {
        if (!alphabet.Contains(symbol)) return symbol;

        return symbol == alphabet.End ? alphabet.Start : (char)(symbol + 1);
    }

    /// <summary>Дешифрование символа.</summary>
    /// <param name="symbol">Символ для дешифрования.</param>
    /// <param name="alphabet">Алфавит, включающий символ для дешифрования.</param>
    /// <returns>Дешифрованный символ.</returns>
    protected override char DecodeChar(char symbol, Alphabet alphabet)
    {
        if (!alphabet.Contains(symbol)) return symbol;

        return symbol == alphabet.Start ? alphabet.End : (char)(symbol - 1);
    }
}
