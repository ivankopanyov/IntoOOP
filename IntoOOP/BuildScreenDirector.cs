using IntoOOP.UI;
using IntoOOP.Builds;

namespace IntoOOP;

/// <summary>Строитель экрана конструктора здания.</summary>
public class BuildScreenDirector : ScreenBuider
{
    /// <summary>Текст перед полем ввода колличества квартир.</summary>
    private const string APARTMENTS_FIELD_LABEL = "Колличество квартир:   ";

    /// <summary>Текст перед полем ввода колличества подъездов.</summary>
    private const string ENTRANCES_FIELD_LABEL = "Колличество подъездов: ";

    /// <summary>Текст перед полем ввода колличества этажей.</summary>
    private const string FLOORS_FIELD_LABEL = "Колличество этажей:    ";

    /// <summary>Текст перед полем ввода высоты здания.</summary>
    private const string HEIGHT_LABEL = "Высота здания:         ";

    /// <summary>Текст элемента, отображающего колличество квартир в подъезде.</summary>
    private const string ENTRANCE_APARTMENTS_LABEL = "Квартир в подъезде:     ";

    /// <summary>Текст элемента, отображающего колличество квартир на этаже.</summary>
    private const string FLOORS_APARTMENTS_LABEL = "Квартир на этаже:       ";

    /// <summary>Текст элемента, отображающего высоту этажа.</summary>
    private const string FLOOR_HEIGHT_LABEL = "Высота этажа:           ";

    /// <summary>Цвет элементов экрана.</summary>
    private const ConsoleColor _Color = ConsoleColor.White;

    /// <summary>Цвет элемента при некорректном значении.</summary>
    private const ConsoleColor _InvalidValueColor = ConsoleColor.Red;

    /// <summary>Элемент заголовка экрана.</summary>
    private readonly UIText _Header;

    /// <summary>Поле ввода колличества квартир.</summary>
    private readonly UIInputField _ApartmentsField;

    /// <summary>Поле ввода колличества подъездов.</summary>
    private readonly UIInputField _EntrancesField;

    /// <summary>Поле ввода колличества этажей.</summary>
    private readonly UIInputField _FloorsField;

    /// <summary>Поле ввода высоты здания.</summary>
    private readonly UIText _FloorHeight;

    /// <summary>Элемент экрана, отображающий колличество квартир в подъезде.</summary>
    private readonly UIText _EntranceApartments;

    /// <summary>Элемент экрана, отображающий колличество квартир на этаже..</summary>
    private readonly UIText _FloorApartments;

    /// <summary>Элемент экрана, отображающий высоту этажа.</summary>
    private readonly UIInputField _HeightField;

    /// <summary>Здание для редактирования.</summary>
    private Build _Build;

    /// <summary>Кнопка здания на главном экране.</summary>
    private UIButton _Button;

    /// <summary>Опрежеление цвета поля ввода.</summary>
    private ConsoleColor InputFieldColor => _Build.ApartmentsCount % (_Build.EntrancesCount * _Build.FloorsCount) != 0
        ? _InvalidValueColor : _Color;

    /// <summary>Инициализация объекта строителя экрана конструктора здания.</summary>
    /// <param name="mainScreenDirector">Конструктор главного экрана приложения.</param>
    /// <param name="build">Здание для редактированяи.</param>
    /// <param name="button">Кнопка здания на главном экране.</param>
    public BuildScreenDirector(MainScreenDirector mainScreenDirector, Build build, UIButton button) : base(mainScreenDirector.Size)
    {
        _Screen.BorderColor = _Color;

        _Build = build;
        _Button = button;

        var paddingLeft = 10;

        _Screen.AddLast(_Header = CreateHeader($"<< {build} >>", Position.Center, _Color));

        _ApartmentsField = new UIInputField(APARTMENTS_FIELD_LABEL, InputType.Int);
        _EntrancesField = new UIInputField(ENTRANCES_FIELD_LABEL, InputType.Int);
        _FloorsField = new UIInputField(FLOORS_FIELD_LABEL, InputType.Int);
        _FloorHeight = new UIText();
        _EntranceApartments = new UIText();
        _FloorApartments = new UIText();

        _ApartmentsField.Limit = 4;
        _ApartmentsField.Padding = new Point(paddingLeft, 0);
        _ApartmentsField.ChangeValue += () =>
        {
            _Build.ApartmentsCount = int.Parse(_ApartmentsField.Value);
            SetColor(_ApartmentsField, _Color);
            _ApartmentsField.Draw(false);

            SetColor(_FloorsField, InputFieldColor);
            _FloorsField.Draw(false);

            SetColor(_EntrancesField, InputFieldColor);
            _EntrancesField.Draw(false);

            SetColor(_EntranceApartments, _Build.ApartmentsCountInEntrance);
            _EntranceApartments.Label = ENTRANCE_APARTMENTS_LABEL + _Build.ApartmentsCountInEntrance;
            _EntranceApartments.Draw(false);

            SetColor(_FloorApartments, _Build.ApartmentsCountInFloor);
            _FloorApartments.Label = FLOORS_APARTMENTS_LABEL + _Build.ApartmentsCountInFloor;
            _FloorApartments.Draw(false);
        };
        _ApartmentsField.InputEnd += () =>
        {
            _ApartmentsField.Value = _Build.ApartmentsCount.ToString();
            _ApartmentsField.Draw(false);
        };
        _Screen.AddLast(_ApartmentsField);

        _FloorsField.Limit = 3;
        _FloorsField.Padding = new Point(paddingLeft, 0);
        _FloorsField.ChangeValue += () =>
        {
            _Build.FloorsCount = int.Parse(_FloorsField.Value);
            SetColor(_FloorsField, _Color);
            _FloorsField.Draw(false);

            SetColor(_ApartmentsField, InputFieldColor);
            _ApartmentsField.Draw(false);

            SetColor(_EntrancesField, InputFieldColor);
            _EntrancesField.Draw(false);

            SetColor(_FloorApartments, _Build.ApartmentsCountInFloor);
            _FloorApartments.Label = FLOORS_APARTMENTS_LABEL + _Build.ApartmentsCountInFloor;
            _FloorApartments.Draw(false);

            _FloorHeight.Label = FLOOR_HEIGHT_LABEL + _Build.FloorHeight;
            _FloorHeight.Draw(false);
        };
        _FloorsField.InputEnd += () =>
        {
            _FloorsField.Value = _Build.FloorsCount.ToString();
            _FloorsField.Draw(false);
        };
        _Screen.AddLast(_FloorsField);

        _EntrancesField.Limit = 2;
        _EntrancesField.Padding = new Point(paddingLeft, 0);
        _EntrancesField.ChangeValue += () =>
        {
            _Build.EntrancesCount = int.Parse(_EntrancesField.Value);
            SetColor(_EntrancesField, _Color);
            _EntrancesField.Draw(false);

            SetColor(_FloorsField, InputFieldColor);
            _FloorsField.Draw(false);

            SetColor(_ApartmentsField, InputFieldColor);
            _ApartmentsField.Draw(false);

            SetColor(_EntranceApartments, _Build.ApartmentsCountInEntrance);
            _EntranceApartments.Label = ENTRANCE_APARTMENTS_LABEL + _Build.ApartmentsCountInEntrance;
            _EntranceApartments.Draw(false);
        };
        _EntrancesField.InputEnd += () =>
        {
            _EntrancesField.Value = _Build.EntrancesCount.ToString();
            _EntrancesField.Draw(false);
        };
        _Screen.AddLast(_EntrancesField);

        _HeightField = new UIInputField(HEIGHT_LABEL, InputType.Double);
        _HeightField.Limit = 6;
        _HeightField.Padding = new Point(paddingLeft, 0);
        _HeightField.LabelColor = _Color;
        _HeightField.ChangeValue += () =>
        {
            _Build.Height = double.Parse(_HeightField.Value);
            _HeightField.Draw(false);

            _FloorHeight.Label = FLOOR_HEIGHT_LABEL + _Build.FloorHeight;
            _FloorHeight.Draw(false);
        };
        _HeightField.InputEnd += () =>
        {
            _HeightField.Value = _Build.Height.ToString();
            _HeightField.Draw(false);
        };
        _Screen.AddLast(_HeightField);

        _FloorHeight.Padding = new Point(paddingLeft, 1);
        _FloorHeight.LabelColor = _Color;
        _Screen.AddLast(_FloorHeight);

        _EntranceApartments.Padding = new Point(paddingLeft, 2);
        _Screen.AddLast(_EntranceApartments);

        _FloorApartments.Padding = new Point(paddingLeft, 2);
        _Screen.AddLast(_FloorApartments);

        var removeButton = CreateButton("Удалить здание", Position.Center, ConsoleColor.Red);
        removeButton.Padding += new Point(0, 1);
        removeButton.OnClick += () =>
        {
            if (Creator.Count > 1 && _Button.Previous == mainScreenDirector.Header)
                _Button.Next.Padding += new Point(0, _Button.Padding.Y);

            mainScreenDirector.Screen.Last.Padding += new Point(0, _Button.Height - _Button.Padding.Y +
                (Creator.Count == 1 ? _Button.Padding.Y : 0));

            if (Creator.Count == MainScreenDirector.LIMIT)
            {
                mainScreenDirector.Screen.AddBefore(mainScreenDirector.Screen.Last.Previous, mainScreenDirector.NewBuildButton);
                mainScreenDirector.NewBuildButton.Next.Padding -= new Point(0, 1);
            }

            Creator.Remove(_Build.Id);
            mainScreenDirector.Screen.Remove(_Button);

            return mainScreenDirector.Screen;
        };
        _Screen.AddLast(removeButton);

        _Screen.AddLast(CreateBackButton(mainScreenDirector.Screen, Position.Center, _Color));

        _Screen.AddLast(CreateFooter(MainScreenDirector.IMAGE, Position.Right, _Color));

        Update();
    }

    /// <summary>Обновления экрана для редактируемого здания.</summary>
    /// <param name="build">Здание для редактирования.</param>
    /// <param name="button">Кнопка здяния на главном экране.</param>
    /// <returns>Текущий экземпляр класса строителя экрана.</returns>
    public BuildScreenDirector UpdateScreen(Build build, UIButton button)
    {
        _Build = build;
        _Button = button;
        Update();
        return this;
    }

    /// <summary>Обновление экрана.</summary>
    private void Update()
    {
        _Header.Label = $"<< {_Build} >>";

        _ApartmentsField.Value = _Build.ApartmentsCount.ToString();
        SetColor(_ApartmentsField, InputFieldColor);

        _FloorsField.Value = _Build.FloorsCount.ToString();
        SetColor(_FloorsField, InputFieldColor);

        _EntrancesField.Value = _Build.EntrancesCount.ToString();
        SetColor(_EntrancesField, InputFieldColor);

        _HeightField.Value = _Build.Height.ToString();

        _FloorHeight.Label = FLOOR_HEIGHT_LABEL + _Build.FloorHeight;

        _EntranceApartments.Label = ENTRANCE_APARTMENTS_LABEL + _Build.ApartmentsCountInEntrance;
        SetColor(_EntranceApartments, _Build.ApartmentsCountInEntrance);

        _FloorApartments.Label = FLOORS_APARTMENTS_LABEL + _Build.ApartmentsCountInFloor;
        SetColor(_FloorApartments, _Build.ApartmentsCountInFloor);
    }

    /// <summary>Изменение цвета поля ввода.</summary>
    /// <param name="inputField">Поле ввода.</param>
    /// <param name="color">Цвет поля ввода.</param>
    private void SetColor(UIInputField inputField, ConsoleColor color)
    {
        inputField.LabelColor = color;
        inputField.InputTextColor = color;
        inputField.BorderColor = color;
    }

    /// <summary>Изменение цвета элемента текста.</summary>
    /// <param name="text">Элемент текста.</param>
    /// <param name="value">Проверяемое значение.</param>
    private void SetColor(UIText text, double value) =>
        text.LabelColor = value == Math.Truncate(value) ? _Color : _InvalidValueColor;
}
