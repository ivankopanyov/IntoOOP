namespace IntoOOP.Bank;

/// <summary>Класс, описывающий банковский счет.</summary>
public class Account
{
    /// <summary>Номер последнего инициализированного объекта счета.</summary>
    private static int _LastNumber;

    /// <summary>Текущий баланс счета.</summary>
    private decimal _Balance;

    /// <summary>Номер счета.</summary>
    public int Number { get; init; }

    /// <summary>Тип счета.</summary>
    public AccountType AccountType { get; init; }

    /// <summary>Название типа счета.</summary>
    public string DisplayAccountType { get; init; }

    /// <summary>Текущий баланс счета.</summary>
    public decimal Balance => _Balance;

    /// <summary>Строка с текущим балансом счета.</summary>
    public string DisplayBalance => _Balance.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));

    /// <summary>Инициализация объекта банковского счета.</summary>
    public Account()
    {
        Number = ++_LastNumber;
        DisplayAccountType = GetDisplayAccountType(AccountType);
    }

    /// <summary>Инициализация объекта банковского счета.</summary>
    /// <param name="balance">Баланс счета.</param>
    public Account(decimal balance) : this() => _Balance = balance;

    /// <summary>Инициализация объекта банковского счета.</summary>
    /// <param name="accountType">Тип счета.</param>
    public Account(AccountType accountType) : this() => this.AccountType = accountType;

    /// <summary>Инициализация объекта банковского счета.</summary>
    /// <param name="_balance">Баланс счета.</param>
    /// <param name="accountType">Тип счета.</param>
    public Account(decimal _balance, AccountType accountType) : this(_balance) => 
        this.AccountType = accountType;

    /// <summary>Внесение средств на счет.</summary>
    /// <param name="amount">Колличество вносимых средств.</param>
    /// <exception cref="ArgumentException">Возбуждается, если сумма внесения меньше 0.</exception>
    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма указана некорректно.");

        _Balance += amount;
    }

    /// <summary>Снятие средств со счета.</summary>
    /// <param name="amount">Колличество снимаемых средств.</param>
    /// <exception cref="ArgumentException">Возбуждается при недостатке средств или если
    /// сумма снятия меньше 0.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount == 0) return;

        if (amount < 0)
            throw new ArgumentException("Сумма указана некорректно.", nameof(amount));

        if (amount > _Balance)
            throw new ArgumentException("Недостаточно средств на счете.", nameof(amount));

        _Balance -= amount;
    }

    /// <summary>Перевод средств на другой счет.</summary>
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

    /// <summary>Получение названия типа счета.</summary>
    /// <param name="accountType">Тип счета.</param>
    /// <returns>Название типа счета.</returns>
    public static string GetDisplayAccountType(AccountType accountType) => accountType switch
    {
        AccountType.Debit => "Дебетовый",
        AccountType.Credit => "Кредитный",
        AccountType.Deposit => "Депозитный",
        _ => "Не установлен"
    };

    /// <summary>Приведение экземпляра класса счета к типу строки.</summary>
    /// <returns>Строка с информацией о счете.</returns>
    public override string ToString() => $"{DisplayAccountType} счет №{Number} ";
}
