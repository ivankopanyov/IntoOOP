namespace IntoOOP.Bank;

/// <summary>
/// Класс банковского счета.
/// </summary>
public class Account
{
    /// <summary>
    /// Номер последнего созданного счета.
    /// </summary>
    private static int _lastNumber;

    /// <summary>
    /// Номер счета.
    /// </summary>
    private int _number;

    /// <summary>
    /// Баланс счета.
    /// </summary>
    private decimal _balance;

    /// <summary>
    /// Тип счета.
    /// </summary>
    private AccountType _accountType;

    /// <summary>
    /// Номер счета.
    /// </summary>
    public int Number => _number;

    /// <summary>
    /// Текущий баланс счета.
    /// </summary>
    public decimal Balance => _balance;

    /// <summary>
    /// Тип счета.
    /// </summary>
    public AccountType AccountType => _accountType;

    /// <summary>
    /// Название типа счета.
    /// </summary>
    public string DisplayAccountType => GetDisplayAccountType(_accountType);

    /// <summary>
    /// Строка с балансом счета.
    /// </summary>
    public string DisplayBalance => _balance.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    public Account() => InitNumber();

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="balance">Устанавливает баланс счета.</param>
    public Account(decimal balance) : this() => _balance = balance;

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="accountType">Устанавливает тип счета.</param>
    public Account(AccountType accountType) : this() => _accountType = accountType;

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="_balance">Устанавливает баланс счета.</param>
    /// <param name="accountType">Устанавливает тип счета.</param>
    public Account(decimal _balance, AccountType accountType) : this(_balance) => _accountType = accountType;

    /// <summary>
    /// Устанавливает номер счета, прибавляя 1 к номеру последнего созданного счета.
    /// </summary>
    private void InitNumber() => _number = ++_lastNumber;

    /// <summary>
    /// Внесение средств на счет.
    /// </summary>
    /// <param name="amount">Колличество вносимых средств.</param>
    /// <exception cref="ArgumentException">Возбуждается, если сумма внесения меньше 0.</exception>
    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма указана некорректно.");

        _balance += amount;
    }

    /// <summary>
    /// Снятие средств со счета.
    /// </summary>
    /// <param name="amount">Колличество снимаемых средств.</param>
    /// <exception cref="ArgumentException">Возбуждается при недостатке средств или если
    /// сумма снятия меньше 0.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount == 0) return;

        if (amount < 0)
            throw new ArgumentException("Сумма указана некорректно.");

        if (amount > _balance)
            throw new ArgumentException("Недостаточно средств на счете.");

        _balance -= amount;
    }

    /// <summary>
    /// Получение названия типа счета.
    /// </summary>
    /// <param name="accountType">Тип счета.</param>
    /// <returns>Название типа счета.</returns>
    public static string GetDisplayAccountType(AccountType accountType) => accountType switch
    {
        AccountType.Debit => "Дебетовый",
        AccountType.Credit => "Кредитный",
        AccountType.Deposit => "Депозитный",
        _ => "Не установлен"
    };

    /// <summary>
    /// Приведение экземпляра класса счета к типу строки.
    /// </summary>
    /// <returns>Строка счета.</returns>
    public override string ToString() => $"{GetDisplayAccountType(_accountType)} счет №{_number} ";
}
