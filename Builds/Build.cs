namespace IntoOOP.Builds;

/// <summary>Класс, описывающий здание.</summary>
public class Build
{
    /// <summary>Идентификатор здания.</summary>
    private readonly int _Id;

    /// <summary>Высота здания.</summary>
    private double _Height;

    /// <summary>Колличество этажей в здании.</summary>
    private int _FloorsCount = 1;

    /// <summary>Колличество подъездов в здании.</summary>
    private int _EntrancesCount = 1;

    /// <summary>Колличество квартир в здании.</summary>
    private int _ApartmentsCount = 1;

    /// <summary>Идентификатор здания.</summary>
    public int Id => _Id;

    /// <summary>Высота здания.</summary>
    public double Height
    {
        get => _Height;
        set
        {
            if (value <= 0) return;
            _Height = value;
        }
    }

    /// <summary>Колличество этажей в здании.</summary>
    public int FloorsCount
    {
        get => _FloorsCount;
        set
        {
            if (value <= 0) return;
            _FloorsCount = value;
        }
    }

    /// <summary>Колличество подъездов в здании.</summary>
    public int EntrancesCount
    {
        get => _EntrancesCount;
        set
        {
            if (value <= 0) return;
            _EntrancesCount = value;
        }
    }

    /// <summary>Колличество квартир в здании.</summary>
    public int ApartmentsCount
    {
        get => _ApartmentsCount;
        set
        {
            if (value <= 0) return;
            _ApartmentsCount = value;
        }
    }

    /// <summary>Высота этажа.</summary>
    public double FloorHeight => _Height / _FloorsCount;

    /// <summary>Колличество квартир в подъезде.</summary>
    public double ApartmentsCountInEntrance => (double)_ApartmentsCount / _EntrancesCount;

    /// <summary>Колличество квартир на этаже.</summary>
    public double ApartmentsCountInFloor => (double)_ApartmentsCount / _FloorsCount;

    /// <summary>Инициализация объекта здания.</summary>
    /// <param name="id">Идентификатор здания.</param>
    /// <param name="height">Высота здания.</param>
    internal Build(int id, double height)
    {
        _Id = id;
        Height = height;
    }

    /// <summary>Инициализация объекта здания.</summary>
    /// <param name="id">Идентификатор здания.</param>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="height">Высота здания.</param>
    internal Build(int id, int apartmentsCount, double height) : this(id, height) => ApartmentsCount = apartmentsCount;

    /// <summary>Инициализация объекта здания.</summary>
    /// <param name="id">Идентификатор здания.</param>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="floorsCount">Колличество этажей в здании.</param>
    /// <param name="height">Высота здания.</param>
    internal Build(int id, int apartmentsCount, int floorsCount, double height) : this(id, apartmentsCount, height)
        => FloorsCount = floorsCount;

    /// <summary>Инициализация объекта здания.</summary>
    /// <param name="id">Идентификатор здания.</param>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="floorsCount">Колличество этажей в здании.</param>
    /// <param name="entrancesCount">Колличество подъездо в здании.</param>
    /// <param name="height">Высота здания.</param>
    internal Build(int id, int apartmentsCount, int floorsCount, int entrancesCount, double height) :
        this(id, apartmentsCount, floorsCount, height)
    {
        EntrancesCount = entrancesCount;
        ApartmentsCount = FloorsCount * EntrancesCount;
    }

    /// <summary>Переопределение метода приведения объекта класса здания к типу string.</summary>
    /// <returns>Строка c идентификатором объекта.</returns>
    public override string ToString() => "Здание №" + _Id;
}
