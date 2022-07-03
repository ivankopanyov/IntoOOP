namespace IntoOOP.Bank;

/// <summary>
/// Класс, имитирующий работу сервера.
/// </summary>
public static class Server
{
    /// <summary>
    /// Масимальное колличество счетов.
    /// </summary>
    public const int ACCOUNT_LIMIT = 3;

    /// <summary>
    /// Размер кредита.
    /// </summary>
    public const decimal CREDIT_AMOUNT = 100_000;

    /// <summary>
    /// Название банка.
    /// </summary>
    public const string BANK_NAME = "Банк";

    /// <summary>
    /// Список счетов.
    /// </summary>
    private static List<Account> _accounts = new List<Account>();

    /// <summary>
    /// Массив счетов.
    /// </summary>
    public static Account[] Accounts => _accounts.ToArray();

    /// <summary>
    /// Открытие нового счета.
    /// </summary>
    /// <param name="type">Тип счета.</param>
    /// <returns>Новый счет.</returns>
    /// <exception cref="Exception">Возбуждается при привышении лимита колличества счетов.</exception>
    public static Account OpenAccount(AccountType type)
    {
        if (_accounts.Count == ACCOUNT_LIMIT)
            throw new Exception($"Максимальное колличество счетов: {ACCOUNT_LIMIT}");

        var amount = type == AccountType.Credit ? CREDIT_AMOUNT : 0;
        var account = new Account();
        account.SetNumber(Random.Shared.Next(1, 1_000_000));
        account.SetBalance(amount);
        account.SetAccountType(type);
        _accounts.Add(account);
        return account;
    }

    /// <summary>
    /// Закрытие счета.
    /// </summary>
    /// <param name="account">Счет для закрытия.</param>
    /// <exception cref="Exception">Возбуждается при несоответствующем балансе счета.</exception>
    public static void CloseAccount(Account account)
    {
        if (account.GetAccountType() == AccountType.Credit && account.GetBalance() != CREDIT_AMOUNT)
            throw new Exception($"На балансе счета должно быть {CREDIT_AMOUNT:f2}");

        if (account.GetAccountType() != AccountType.Credit && account.GetBalance() != 0)
            throw new Exception("На балансе счета должно быть 0.00");

        _accounts.Remove(account);
    }
}
