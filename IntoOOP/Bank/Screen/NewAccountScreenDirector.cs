using IntoOOP.Bank.UI;

namespace IntoOOP.Bank.Screen;

/// <summary>
/// Класс, формирующий экран открытия нового счета.
/// </summary>
public class NewAccountScreenDirector : ScreenBuilder
{
    /// <summary>
    /// Конструктор класса, формирующего экран открытия нового счета.
    /// </summary>
    /// <param name="mainScreen">Главный экран приложения.</param>
    public NewAccountScreenDirector(UIScreen mainScreen) : base("Выберите тип счета:")
    {
        AddAccountTypesButtons(mainScreen);
        AddBackButton(mainScreen, new Point(0, 1));;
    }
}
