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
    /// Получение номера счета.
    /// </summary>
    /// <returns>Номер счета.</returns>
    public int GetNumber() => _number;

    /// <summary>
    /// Получение баланса счета.
    /// </summary>
    /// <returns>Баланс счета.</returns>
    public decimal GetBalance() => _balance;

    /// <summary>
    /// Получение типа счета.
    /// </summary>
    /// <returns>Тип счета.</returns>
    public AccountType GetAccountType() => _accountType;

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
