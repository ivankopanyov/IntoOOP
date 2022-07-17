namespace IntoOOP.Draw;

/// <summary>Структура, описывающая вектор.</summary>
public readonly struct Vector
{
    /// <summary>Инициализация объекта нулевого вектора.</summary>
    public static Vector Zero => new Vector(0, 0);

    /// <summary>Инициализация объекта единичного вектора по направлению вправо.</summary>
    public static Vector Right => new Vector(1, 0);

    /// <summary>Инициализация объекта единичного вектора по направлению влево.</summary>
    public static Vector Left => new Vector(-1, 0);

    /// <summary>Инициализация объекта единичного вектора по направлению вверх.</summary>
    public static Vector Up => new Vector(0, -1);

    /// <summary>Инициализация объекта единичного вектора по направлению вниз.</summary>
    public static Vector Down => new Vector(0, 1);

    /// <summary>Инициализация объекта единичного вектора.</summary>
    public static Vector One => new Vector(1, 1);

    /// <summary>Направление вектора по оси x.</summary>
    public double X { get; init; }

    /// <summary>Направление вектора по оси y.</summary>
    public double Y { get; init; }

    /// <summary>Инициализация объекта вектора.</summary>
    /// <param name="x">Направление вектора по оси x.</param>
    /// <param name="y">Направление вектора по оси y.</param>
    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Унарный оператор сложения.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Новый объект вектора с координатами, идентичными операнду.</returns>
    public static Vector operator +(Vector value) => new Vector(value.X, value.Y);

    /// <summary>Бинарный оператор сложения векторов.</summary>
    /// <param name="left">Первый операнд.</param>
    /// <param name="right">Второй операнд.</param>
    /// <returns>Новый вектор с сумарными координатами операндов.</returns>
    public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y);

    /// <summary>Оператор инкремента вектора.</summary>
    /// <param name="value">Инкрементируемый вектор.</param>
    /// <returns>Увеличивает значение координат вектора на 1.</returns>
    public static Vector operator ++(Vector value) => value + One;

    /// <summary>Унарный оператор вычитания.</summary>
    /// <param name="value">Операнд.</param>
    /// <returns>Новый объект вектора с координатами, противоположными операнду.</returns>
    public static Vector operator -(Vector value) => new Vector(-value.X, -value.Y);

    /// <summary>Бинарный оператор вычитания векторов.</summary>
    /// <param name="left">Первый операнд.</param>
    /// <param name="right">Второй операнд.</param>
    /// <returns>Новый вектор с координатами разности координат операндов.</returns>
    public static Vector operator -(Vector left, Vector right) => new Vector(left.X - right.X, left.Y - right.Y);

    /// <summary>Оператор декремента вектора.</summary>
    /// <param name="value">Декрементируемый вектор.</param>
    /// <returns>Уменьшает значение координат вектора на 1.</returns>
    public static Vector operator --(Vector value) => value - One;

    /// <summary>Оператор умножения вектора на число.</summary>
    /// <param name="vector">Вектор.</param>
    /// <param name="value">Число.</param>
    /// <returns>Новый вектор с координатами произведения координат вектора на число..</returns>
    public static Vector operator *(Vector vector, double value) => new Vector(vector.X * value, vector.Y * value);

    /// <summary>Оператор деления вектора на число.</summary>
    /// <param name="vector">Делимое.</param>
    /// <param name="value">Делитель.</param>
    /// <returns>Новый вектор с координатами частного координат вектора и числа.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если делитель равен 0.</exception>
    public static Vector operator /(Vector vector, double value)
    {
        if (value == 0)
            throw new DivideByZeroException();

        return new Vector(vector.X / value, vector.Y / value);
    }

    /// <summary>Оператор равенства векторов.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат проверки на равенство векторов.</returns>
    public static bool operator ==(Vector left, Vector right) => Equals(left, right);


    /// <summary>Оператор неравенства векторов.</summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат проверки на неравенство векторов.</returns>
    public static bool operator !=(Vector left, Vector right) => !Equals(left, right);

    /// <summary>Сравнение векторов на эквивалентность.</summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>Возвращает true, если координаты векторов равны.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Vector)) return false;

        var other = (Vector)obj;

        return X == other.X && Y == other.Y;
    }

    /// <summary>Переопределение метода генерирования хэш-кода.</summary>
    /// <returns>Хэш-код</returns>
    public override int GetHashCode()
    {
        var hash = 274;

        unchecked
        {
            hash = (hash * 0x112) ^ X.GetHashCode();
            hash = (hash * 0x112) ^ Y.GetHashCode();
        }

        return hash;
    }

    /// <summary>Приведение вектора к типу строки.</summary>
    /// <returns>Строка с координатами вектора.</returns>
    public override string ToString() => $"(X: {X}, Y: {Y})";
}
