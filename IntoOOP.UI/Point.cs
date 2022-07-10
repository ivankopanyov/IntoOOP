namespace IntoOOP.UI;

/// <summary>Структура с координатами точки.</summary>
public readonly struct Point
{
    /// <summary>Позиция точки по горизонтали. </summary>
    public int X { get; }


    /// <summary>Позиция точки по вертикали.</summary>
    public int Y { get; }

    /// <summary>Инициализация точки.</summary>
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Переопределение унарного оператора сложения.</summary>
    /// <param name="p">Точка.</param>
    /// <returns>Новая точка с той же позицией.</returns>
    public static Point operator +(Point p) => p;

    /// <summary>Переопределение унарного оператора вычитания.</summary>
    /// <param name="p">Точка.</param>
    /// <returns>Новая точка с противоположной позицией.</returns>
    public static Point operator -(Point p) => new Point(-p.X, -p.Y);

    /// <summary>Переопределение бинарного оператора сложения точек.</summary>
    /// <param name="p1">Первый операнд.</param>
    /// <param name="p2">Второй операнд.</param>
    /// <returns>Новая точка с позицией суммы позиций точек операндов.</returns>
    public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

    /// <summary>Переопределение бинарного оператора вычитания точек.</summary>
    /// <param name="p1">Первый операнд.</param>
    /// <param name="p2">Второй операнд.</param>
    /// <returns>Новая точка с позицией разности позиций точек операндов.</returns>
    public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

    /// <summary>Переопределение оператора умножения точки на число.</summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, умноженной на число операнд.</returns>
    public static Point operator *(Point p, int n) => new Point(p.X * n, p.Y * n);

    /// <summary>Переопределение оператора деления точки на число.</summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, поделенной на число операнд.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если значение числа операнда равно 0.</exception>
    public static Point operator /(Point p, int n)
    {
        if (n == 0) throw new DivideByZeroException();
        return new Point(p.X / n, p.Y / n);
    }

    /// <summary>Приведение точки к типу string.</summary>
    /// <returns>Строка с типом и координатами точки.</returns>
    public override string ToString() => $"Point(x: {X}, y: {Y})";
}
