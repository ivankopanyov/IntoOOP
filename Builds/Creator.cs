using System.Collections;

namespace IntoOOP.Builds;

public static class Creator
{
    /// <summary>Значение высоты здания по умолчанию.</summary>
    private const double DEFAULT_HEIGHT = 1;

    /// <summary>Идентификатор последнего созданного экземпляра здания.</summary>
    private static int _LastId;

    /// <summary>Хэш-таблица с экземпоярами зданий.</summary>
    public static Hashtable _Builds = new();

    /// <summary>Создание нового объекта здания.</summary>
    /// <param name="height">Высота здания.</param>
    /// <returns>Новый экземпляр здания.</returns>
    public static Build CreateBuild(double height = DEFAULT_HEIGHT) => AddBuild(new Build(++_LastId, height));

    /// <summary>>Создание нового объекта здания.</summary>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="height">Высота здания.</param>
    /// <returns>Новый экземпляр здания.</returns>
    public static Build CreateBuild(int apartmentsCount, double height = DEFAULT_HEIGHT) 
        => AddBuild(new Build(++_LastId, apartmentsCount, height));

    /// <summary>>Создание нового объекта здания.</summary>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="floorsCount">Колличество этажей в здании.</param>
    /// <param name="height">Высота здания.</param>
    /// <returns>Новый экземпляр здания.</returns>
    public static Build CreateBuild(int apartmentsCount, int floorsCount, double height = DEFAULT_HEIGHT)
        => AddBuild(new Build(++_LastId, apartmentsCount, floorsCount, height));

    /// <summary>Создание нового объекта здания.</summary>
    /// <param name="apartmentsCount">Колличество квартир в зданиии.</param>
    /// <param name="floorsCount">Колличество этажей в здании.</param>
    /// <param name="entrancesCount">Колличество подъездо в здании.</param>
    /// <param name="height">Высота здания.</param>
    /// <returns>Новый экземпляр здания.</returns>
    public static Build CreateBuild(int apartmentsCount, int floorsCount, int entrancesCount, double height)
        => AddBuild(new Build(++_LastId, apartmentsCount, floorsCount, entrancesCount, height));

    /// <summary>Удаление экземпляра здания.</summary>
    /// <param name="id">Идентификатор здания.</param>
    public static void Remove(int id) => _Builds.Remove(id);

    /// <summary>Добавление экземпляра здания в хэш-таблицу</summary>
    /// <param name="build">Новый экземпляр здания.</param>
    /// <returns>Добавленный экземпляр здания.</returns>
    private static Build AddBuild(Build build)
    {
        _Builds.Add(build.Id, build);
        return build;
    }
}
