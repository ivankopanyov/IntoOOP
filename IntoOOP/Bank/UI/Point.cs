namespace IntoOOP.Bank.UI;

/// <summary>
/// Точка на экране.
/// </summary>
public struct Point
{
    /// <summary>
    /// Позиция точки по горизонтали.
    /// </summary>
    private int _x;

    /// <summary>
    /// Позиция точки по вертикали.
    /// </summary>
    private int _y;

    /// <summary>
    /// Позиция точки по горизонтали.
    /// </summary>
    public int X => _x;


    /// <summary>
    /// Позиция точки по вертикали.
    /// </summary>
    public int Y => _y;

    /// <summary>
    /// Инициализация точки.
    /// </summary>
    public Point(int x, int y)
    { 
        _x = x;
        _y = y;
    }

    /// <summary>
    /// Переопределение унарного оператора сложения.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <returns>Новая точка с той же позицией.</returns>
    public static Point operator +(Point p) => p;


    /// <summary>
    /// Переопределение унарного оператора вычитания.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <returns>Новая точка с противоположной позицией.</returns>
    public static Point operator -(Point p) => new Point(-p._x, -p._y);

    /// <summary>
    /// Переопределение бинарного оператора сложения точек.
    /// </summary>
    /// <param name="p1">Первый операнд.</param>
    /// <param name="p2">Второй операнд.</param>
    /// <returns>Новая точка с позицией суммы позиций точек операндов.</returns>
    public static Point operator +(Point p1, Point p2) => new Point(p1._x + p2._x, p1._y + p2._y);

    /// <summary>
    /// Переопределение бинарного оператора сложения точки с числом.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, увеличенной по вертикали на число операнд.</returns>
    public static Point operator +(Point p, int n) => new Point(p._x, p._y + n);

    /// <summary>
    /// Переопределение бинарного оператора вычитания точек.
    /// </summary>
    /// <param name="p1">Первый операнд.</param>
    /// <param name="p2">Второй операнд.</param>
    /// <returns>Новая точка с позицией разности позиций точек операндов.</returns>
    public static Point operator -(Point p1, Point p2) => new Point(p1._x - p2._x, p1._y - p2._y);

    /// <summary>
    /// Переопределение бинарного оператора вычитания числа из точки.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, уменьшенной по вертикали на значение числа операнда.</returns>
    public static Point operator -(Point p, int n) => new Point(p._x, p._y - n);

    /// <summary>
    /// Переопределение оператора умножения точки на число.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, умноженной на число операнд.</returns>
    public static Point operator *(Point p, int n) => new Point(p._x * n, p._y * n);

    /// <summary>
    /// Переопределение оператора деления точки на число.
    /// </summary>
    /// <param name="p">Точка.</param>
    /// <param name="n">Число.</param>
    /// <returns>Новая точка с позицией, поделенной на число операнд.</returns>
    /// <exception cref="DivideByZeroException">Возбуждается, если значение числа операнда равно 0.</exception>
    public static Point operator /(Point p, int n)
    {
        if (n == 0) throw new DivideByZeroException();
        return new Point(p._x / n, p._y / n);
    }

    /// <summary>
    /// Приведение точки к типу string.
    /// </summary>
    /// <returns>Строка с типом и координатами точки.</returns>
    public override string ToString() => $"Point(x: {_x}, y: {_y})";
}
