﻿namespace IntoOOP.Bank.Tests;

public class AccountTestCase
{
    public int IterationsNumber { get; set; }

    public decimal Balance { get; set; }

    public AccountType AccountType { get; set; }

    public bool ExpectedArgumentException { get; set; }
}
