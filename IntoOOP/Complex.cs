namespace IntoOOP;

/// <summary>Структура, описывающая комплексное число.</summary>
public readonly struct Complex
{
    /// <summary>Действительная часть комплексного числа.</summary>
    public double R { get; }

    /// <summary>Мнимая часть комплексного числа.</summary>
    public double I { get; }

    /// <summary>Инициализация комплексного числа.</summary>
    /// <param name="r">Действительная часть комплексного числа.</param>
    /// <param name="i">Мнимая часть комплексного числа.</param>
    public Complex(double r, double i) 
    { 
        R = r; 
        I = i; 
    }

    #region Number to Complex

    /// <summary>Неявное приведение типа sbyte к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(sbyte value) => (double)value;

    /// <summary>Неявное приведение типа byte к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(byte value) => (double)value;

    /// <summary>Неявное приведение типа short к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(short value) => (double)value;

    /// <summary>Неявное приведение типа ushort к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(ushort value) => (double)value;

    /// <summary>Неявное приведение типа int к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(int value) => (double)value;

    /// <summary>Неявное приведение типа uint к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(uint value) => (double)value;

    /// <summary>Неявное приведение типа long к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(long value) => (double)value;

    /// <summary>Неявное приведение типа ulong к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(ulong value) => (double)value;

    /// <summary>Неявное приведение типа nint к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(nint value) => (double)value;

    /// <summary>Неявное приведение типа nuint к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(nuint value) => (double)value;

    /// <summary>Неявное приведение типа float к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(float value) => (double)value;

    /// <summary>Неявное приведение типа double к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(double value) => new Complex(value, 0);

    /// <summary>Явное приведение типа decimal к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator Complex(decimal value) => (double)value;

    /// <summary>Неявное приведение типа Ratio к типу Complex.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static implicit operator Complex(Ratio value) => new Complex((double)value.P / value.Q, 0);

    #endregion

    #region Complex to Number

    /// <summary>Явное приведение типа Complex к типу sbyte.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator sbyte(Complex value) => (sbyte)value.R;

    /// <summary>Явное приведение типа Complex к типу byte.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator byte(Complex value) => (byte)value.R;

    /// <summary>Явное приведение типа Complex к типу short.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator short(Complex value) => (short)value.R;

    /// <summary>Явное приведение типа Complex к типу ushort.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator ushort(Complex value) => (ushort)value.R;

    /// <summary>Явное приведение типа Complex к типу int.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator int(Complex value) => (int)value.R;

    /// <summary>Явное приведение типа Complex к типу uint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator uint(Complex value) => (uint)value.R;

    /// <summary>Явное приведение типа Complex к типу long.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator long(Complex value) => (long)value.R;

    /// <summary>Явное приведение типа Complex к типу ulong.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator ulong(Complex value) => (ulong)value.R;

    /// <summary>Явное приведение типа Complex к типу nint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator nint(Complex value) => (nint)value.R;

    /// <summary>Явное приведение типа Complex к типу nuint.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator nuint(Complex value) => (nuint)value.R;

    /// <summary>Явное приведение типа Complex к типу float.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator float(Complex value) => (float)value.R;

    /// <summary>Явное приведение типа Complex к типу double.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator double(Complex value) => value.R;

    /// <summary>Явное приведение типа Complex к типу decimal.</summary>
    /// <param name="value">Приводимое значение.</param>
    public static explicit operator decimal(Complex value) => (decimal)value.R;

    #endregion

    #region + - * / == !=

    /// <summary>Унарный оператор сложения.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Новое комплексное число с тем же значением.</returns>
    public static Complex operator +(Complex value) => new Complex(value.R, value.I);

    /// <summary>Бинарный оператор сложения комплексных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый перанд.</param>
    /// <returns>Сумма операндов.</returns>
    public static Complex operator +(Complex left, Complex right) => new Complex(left.R + right.R, left.I + right.I);

    /// <summary>Оператор инкремента комплексных чисел.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Прибавляет 1 к действительной части операнда.</returns>
    public static Complex operator ++(Complex value) => value + 1;

    /// <summary>Унарный оператор вычитания.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Умножает значение опернда на -1.</returns>
    public static Complex operator -(Complex value) => value * -1;

    /// <summary>Бинарный оператор вычитания.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Разность операндов.</returns>
    public static Complex operator -(Complex left, Complex right) => new Complex(left.R - right.R, left.I - right.I);

    /// <summary>Оператор декремента комплексных чисел.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Вычитает 1 из действительной части операнда.</returns>
    public static Complex operator --(Complex value) => value - 1;

    /// <summary>Оператор умножения комплексных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат умножения операндов.</returns>
    public static Complex operator *(Complex left, Complex right)
    {
        var r = left.R * right.R;
        var i = left.I * right.I;
        return new Complex(r - i, r + i);
    }

    /// <summary>Оператор деления комплексных чисел.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат деления операндов.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если действительная и мнимая части 
    /// правого операнда равны 0..</exception>
    public static Complex operator /(Complex left, Complex right)
    {
        if (right.R == 0 && right.I == 0)
            throw new DivideByZeroException();

        var d = right.R * right.R + right.I * right.I;

        return new Complex((left.R * right.R + left.I * right.I) / d, (right.R * left.I - left.R * right.I) / d);
    }

    /// <summary>Оператор равенства комплексных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Результат проверки на равенство комплексных чисел.</returns>
    public static bool operator ==(Complex left, Complex right) => left.Equals(right);


    /// <summary>Оператор неравенства комплексных чисел.</summary>
    /// <param name="r1">Левый операнд.</param>
    /// <param name="r2">Правый операнд.</param>
    /// <returns>Результат проверки на неравенство комплексных чисел.</returns>
    public static bool operator !=(Complex left, Complex right) => !left.Equals(right);

    #endregion

    /// <summary>Приведение комплексного числа к типу string.</summary>
    /// <returns>Возвращает строку с комплексным числом.</returns>
    public override string ToString() =>
        $"{R}{(I == 0 ? string.Empty : $" + i * {I}")}";

    /// <summary>Сравнение комплексных чисел на эквивалентность.</summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>Возвращает true, если комплексные числа равны.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Complex)) return false;

        var other = (Complex)obj;

        return R == other.R && I == other.I;
    }

    /// <summary>Переопределение метода генерирования хэш-кода.</summary>
    /// <returns>Хэш-код</returns>
    public override int GetHashCode()
    {
        var hash = 287;

        unchecked
        {
            hash = (hash * 0x11f) ^ R.GetHashCode();
            hash = (hash * 0x11f) ^ I.GetHashCode();
        }

        return hash;
    }
}
