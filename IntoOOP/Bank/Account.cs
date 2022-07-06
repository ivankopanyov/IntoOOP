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
    public readonly int number;

    /// <summary>
    /// Тип счета.
    /// </summary>
    public readonly AccountType accountType;

    /// <summary>
    /// Название типа счета.
    /// </summary>
    public readonly string displayAccountType;

    /// <summary>
    /// Баланс счета.
    /// </summary>
    private decimal _balance;

    /// <summary>
    /// Текущий баланс счета.
    /// </summary>
    public decimal Balance => _balance;

    /// <summary>
    /// Строка с балансом счета.
    /// </summary>
    public string DisplayBalance => _balance.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    public Account()
    {
        number = ++_lastNumber;
        displayAccountType = GetDisplayAccountType(accountType);
    }

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="balance">Устанавливает баланс счета.</param>
    public Account(decimal balance) : this() => _balance = balance;

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="accountType">Устанавливает тип счета.</param>
    public Account(AccountType accountType) : this() => this.accountType = accountType;

    /// <summary>
    /// Конструктор класса банковского счета.
    /// </summary>
    /// <param name="_balance">Устанавливает баланс счета.</param>
    /// <param name="accountType">Устанавливает тип счета.</param>
    public Account(decimal _balance, AccountType accountType) : this(_balance) => 
        this.accountType = accountType;

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
            throw new ArgumentException("Сумма указана некорректно.", nameof(amount));

        if (amount > _balance)
            throw new ArgumentException("Недостаточно средств на счете.", nameof(amount));

        _balance -= amount;
    }

    /// <summary>
    /// Перевод средств на другой счет.
    /// </summary>
    /// <param name="account">Счет для перевода.</param>
    /// <param name="amount">Колличество средств для пеервода.</param>
    /// <exception cref="ArgumentNullException">Возбуждается, если переданный счет не инициализирован.</exception>
    /// <exception cref="ArgumentException">Возбуждается при недостатке средств или если
    /// сумма перевода меньше 0.</exception>
    public void Transfer(Account account, decimal amount)
    {
        if (account == null)
            throw new ArgumentNullException("Указанный счет не найден", nameof(account));

        try 
        {
            Withdraw(amount);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException(ex.Message, nameof(amount));
        }

        account.Deposit(amount);
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
    public override string ToString() => $"{GetDisplayAccountType(accountType)} счет №{number} ";
}
