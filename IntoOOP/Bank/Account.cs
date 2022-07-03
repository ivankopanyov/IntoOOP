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
    /// Устанавливает номер счета, прибавляя 1 к номеру последнего созданного счета.
    /// </summary>
    /// <exception cref="ArgumentException">Возбкждается, если номер счета уже был установлен.</exception>
    public void InitNumber()
    {
        if (_number != 0)
            throw new ArgumentException("Номер счета уже установлен");

        _number = ++_lastNumber;
    }

    /// <summary>
    /// Получение номера счета.
    /// </summary>
    /// <returns>Номер счета.</returns>
    public int GetNumber() => _number;

    /// <summary>
    /// Устанавливает баланс на счете.
    /// </summary>
    /// <param name="balance">Новый баланс счета.</param>
    public void SetBalance(decimal balance) => _balance = balance;

    /// <summary>
    /// Получение баланса счета.
    /// </summary>
    /// <returns>Баланс счета.</returns>
    public decimal GetBalance() => _balance;

    /// <summary>
    /// Устанавливает тип счета.
    /// </summary>
    /// <param name="accountType">Новый тип счета.</param>
    public void SetAccountType(AccountType accountType) => _accountType = accountType;

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
