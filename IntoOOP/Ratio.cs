namespace IntoOOP;

/// <summary>Класс, описывающий рациональное число.</summary>
public readonly struct Ratio
{
    /// <summary>Числитель.</summary>
    public int P { get; }

    /// <summary>Знаменатель.</summary>
    public int Q { get; }

    /// <summary>Инициализация рационального числа.</summary>
    public Ratio()
    {
        P = 0;
        Q = 1;
    }

    /// <summary>Инициализация рационального числа.</summary>
    /// <param name="p">Числитель.</param>
    /// <param name="q">Знаменатель.</param>
    /// <exception cref="DivideByZeroException">Возбуждается, если знаменатель равен 0.</exception>
    public Ratio(int p, int q)
    { 
        if (q == 0)
            throw new DivideByZeroException();

        P = q < 0 ? -p : p;
        Q = q < 0 ? -q : q;
    }

    #region Number to Ratio

    /// <summary>Неявное приведение типа sbyte к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Ratio(sbyte value) => (int)value;

    /// <summary>Неявное приведение типа byte к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Ratio(byte value) => (int)value;

    /// <summary>Неявное приведение типа short к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Ratio(short value) => (int)value;

    /// <summary>Неявное приведение типа ushort к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Ratio(ushort value) => (int)value;

    /// <summary>Неявное приведение типа int к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Ratio(int value) => new Ratio(value, 1);

    /// <summary>Явное приведение типа uint к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(uint value) => (int)value;

    /// <summary>Явное приведение типа long к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(long value) => (int)value;

    /// <summary>Явное приведение типа ulong к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(ulong value) => (int)value;

    /// <summary>Явное приведение типа nint к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(nint value) => (int)value;

    /// <summary>Явное приведение типа nuint к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(nuint value) => (int)value;

    /// <summary>Явное приведение типа float к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(float value)
    {
        if (value <= int.MinValue) return new Ratio(int.MinValue, 1);
        if (value >= int.MaxValue) return new Ratio(int.MaxValue, 1);

        var intValue = (int)value;
        if (intValue == value) return new Ratio(intValue, 1);

        var numberArr = value.ToString("G", System.Globalization.CultureInfo.InvariantCulture).Split('.');
        if (numberArr.Length < 2) return new Ratio((int)value, 1);
        return NumberToRatio(numberArr);
    }

    /// <summary>Явное приведение типа double к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(double value)
    {
        if (value <= int.MinValue) return new Ratio(int.MinValue, 1);
        if (value >= int.MaxValue) return new Ratio(int.MaxValue, 1);

        var intValue = (int)value;
        if (intValue == value) return new Ratio(intValue, 1);

        var numberArr = value.ToString("G", System.Globalization.CultureInfo.InvariantCulture).Split('.');
        if (numberArr.Length < 2) return new Ratio((int)value, 1);
        return NumberToRatio(numberArr);
    }

    /// <summary>Явное приведение типа decimal к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(decimal value)
    {
        if (value <= int.MinValue) return new Ratio(int.MinValue, 1);
        if (value >= int.MaxValue) return new Ratio(int.MaxValue, 1);

        var intValue = (int)value;
        if (intValue == value) return new Ratio(intValue, 1);

        var numberArr = value.ToString("G", System.Globalization.CultureInfo.InvariantCulture).Split('.');
        if (numberArr.Length < 2) return new Ratio((int)value, 1);
        return NumberToRatio(numberArr);
    }

    /// <summary>Явное приведение типа Complex к типу Ratio.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Ratio(Complex value) => (Ratio)value.R;

    #endregion

    #region Ratio to Number

    /// <summary>Явное приведение типа Ratio к типу sbyte.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator sbyte(Ratio value) => (sbyte)(int)value;

    /// <summary>Явное приведение типа Ratio к типу byte.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator byte(Ratio value) => (byte)(int)value;

    /// <summary>Явное приведение типа Ratio к типу short.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator short(Ratio value) => (short)(int)value;

    /// <summary>Явное приведение типа Ratio к типу ushort.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator ushort(Ratio value) => (ushort)(int)value;

    /// <summary>Явное приведение типа Ratio к типу int.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator int(Ratio value) => value.P / value.Q;

    /// <summary>Явное приведение типа Ratio к типу uint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator uint(Ratio value) => (uint)(int)value;

    /// <summary>Явное приведение типа Ratio к типу long.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator long(Ratio value) => (int)value;

    /// <summary>Явное приведение типа Ratio к типу ulong.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator ulong(Ratio value) => (ulong)(int)value;

    /// <summary>Явное приведение типа Ratio к типу nint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator nint(Ratio value) => (int)value;

    /// <summary>Явное приведение типа Ratio к типу nuint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator nuint(Ratio value) => (nuint)(int)value;

    /// <summary>Явное приведение типа Ratio к типу float.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator float(Ratio value) => (float)value.P / value.Q;

    /// <summary>Явное приведение типа Ratio к типу double.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator double(Ratio value) => (double)value.P / value.Q;

    /// <summary>Явное приведение типа Ratio к типу decimal.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator decimal(Ratio value) => (decimal)value.P / value.Q;

    #endregion

    #region + -

    /// <summary>Унарный оператор сложения.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Новое рациональное число с тем же значением.</returns>
    public static Ratio operator +(Ratio value) => new Ratio(value.P, value.Q);

    /// <summary>Бинарный оператор сложения рациональных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый перанд.</param>
    /// <returns>Сумма операндов.</returns>
    public static Ratio operator +(Ratio left, Ratio right) => 
        new Ratio(left.P * right.Q + right.P * left.Q, left.Q * right.Q).Reduce();

    /// <summary>Оператор инкремента рациональных чисел.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Прибавляет 1 к значению операнда.</returns>
    public static Ratio operator ++(Ratio value) => value + 1;

    /// <summary>Унарный оператор вычитания.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Меняет значение числителя на противоположное.</returns>
    public static Ratio operator -(Ratio value) => new Ratio(-value.P, value.Q);

    /// <summary>Бинарный оператор вычитания.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Разность операндов.</returns>
    public static Ratio operator -(Ratio left, Ratio right) => 
        new Ratio(left.P * right.Q - right.P * left.Q, left.Q * right.Q).Reduce();

    /// <summary>Оператор декремента рациональных чисел.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Вычитает 1 из значения операнда.</returns>
    public static Ratio operator --(Ratio value) => value - 1;

    #endregion

    #region * / %

    /// <summary>Оператор умножения рациональных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат умножения операндов.</returns>
    public static Ratio operator *(Ratio left, Ratio right) => new Ratio(left.P * right.P, left.Q * right.Q).Reduce();

    /// <summary>Оператор деления рациональных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат деления операндов.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если числитель правого операнда равен 0.</exception>
    public static Ratio operator /(Ratio left, Ratio right)
    {
        if (right.P == 0)
            throw new DivideByZeroException();

        return (left * right.Flip()).Reduce();
    }

    /// <summary></summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException"></exception>
    public static Ratio operator %(Ratio left, Ratio right)
    {
        if (right.P == 0)
            throw new DivideByZeroException();

        if (left.P == 0) return 0;

        var sign = left.P / Math.Abs(left.P);

        if (left < 0) left = new Ratio(Math.Abs(left.P), left.Q); 
        if (right < 0) right = new Ratio(Math.Abs(right.P), right.Q);

        var result = left;

        while (result - right > 0)
            result -= right;

        return result * sign;
    }

    #endregion

    #region == != > < >= <=

    /// <summary>Оператор равенства рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Результат проверки на равенство рациональный чисел.</returns>
    public static bool operator ==(Ratio r1, Ratio r2) => r1.P * r2.Q == r2.P * r1.Q;

    /// <summary>Оператор неравенства рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Результат проверки на неравенство рациональный чисел.</returns>
    public static bool operator !=(Ratio r1, Ratio r2) => !(r1 == r2);

    /// <summary>Оператор сравнения рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Возвращает true, если левый операнд больше правого.</returns>
    public static bool operator >(Ratio r1, Ratio r2) => r1.P * r2.Q > r2.P * r1.Q;

    /// <summary>Оператор сравнения рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Возвращает true, если левый операнд меньше правого.</returns>
    public static bool operator <(Ratio r1, Ratio r2) => r2 > r1;

    /// <summary>Оператор сравнения рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Возвращает true, если левый операнд больше или равен правому.</returns>
    public static bool operator >=(Ratio r1, Ratio r2) => r1 > r2 || r1 == r2;


    /// <summary>Оператор сравнения рациональных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Возвращает true, если левый операнд меньше или равен правому.</returns>
    public static bool operator <=(Ratio r1, Ratio r2) => r2 >= r1;

    #endregion

    /// <summary>Меняет местами числитель и знаменатель.</summary>
    /// <returns>Перевернутое рациональное число.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если числитель равен 0.</exception>
    public Ratio Flip()
    {
        if (P == 0)
            throw new DivideByZeroException("Делитель не должен быть равен 0");

        return new Ratio(Q, P);
    }

    /// <summary>Сокращение рационального числа.</summary>
    /// <returns>Результат сокращения.</returns>
    public Ratio Reduce()
    {
        if (P == 0) return new Ratio(0, 1);

        int gcd = CalcGCD(P, Q);

        return new Ratio(P / gcd, Q / gcd);
    }

    /// <summary>Рассчет наибольшего общего делителя двух чисел.</summary>
    /// <param name="value1">Первое число.</param>
    /// <param name="value2">Второе число.</param>
    /// <returns>Наибольший общий делитель.</returns>
    public static int CalcGCD(int value1, int value2)
    {
        if (value1 == 0 && value2 == 0) return int.MaxValue;
        if (value2 < 0) value2 = Math.Abs(value2);
        if (value1 == 0) return value2;
        if (value1 < 0) value1 = Math.Abs(value1);
        if (value2 == 0) return value1;

        var max = Math.Max(value1, value2);
        var min = Math.Min(value1, value2);

        while (max != min)
            if (max > min) max -= min;
            else min -= max;

        return min;
    }

    /// <summary>Сравнение рациональных чисел на эквивалентность.</summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>Возвращает true, если числители и знаменатели равны.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Ratio)) return false;

        var other = (Ratio)obj;

        return P == other.P && Q == other.Q;
    }

    /// <summary>Приведение рационального числа к типу string.</summary>
    /// <returns>Возвращает строку с рациональным числом. Если знаменатель равен 1, он не отображается.</returns>
    public override string ToString() => P % Q == 0 ? (P / Q).ToString() : $"{P}/{Q}";

    /// <summary>Переопределение метода генерирования хэш-кода.</summary>
    /// <returns>Хэш-код</returns>
    public override int GetHashCode()
    {
        var hash = 242;

        unchecked
        {
            hash = (hash * 0xf2) ^ P.GetHashCode();
            hash = (hash * 0xf2) ^ Q.GetHashCode();
        }

        return hash;
    }

    /// <summary>Вспомогательный метод привидение вещественного числа к типу Ratioю</summary>
    /// <param name="numberArr">Массив строк с числителем и знаменателем.</param>
    /// <returns>Рациональное число.</returns>
    private static Ratio NumberToRatio(string[] numberArr)
    {
        var p = int.Parse(numberArr[0]);
        double intValue = p == 0 ? 1 : p;

        var q = 1;
        var i = 0;

        for (; i < numberArr[1].Length; i++)
        {
            intValue *= 10;
            if (intValue > int.MaxValue || intValue < int.MinValue) break;
            q *= 10;
        }

        p *= q;
        if (i > 0)
        {
            if (i < numberArr[1].Length)
                numberArr[1] = numberArr[1].Substring(0, i);
            p += int.Parse(numberArr[1]);
        }

        return new Ratio(p, q).Reduce();
    }
}