// BankAccounts:
// int ID, int balance, string firstname, string surname, datecreated

// Reg:
// 1. Create new bank account
// 2. Login (bankaccount ID + password)

// Menu:
// 1. View Balance
// 2. Withdraw
// 3. Deposit
// 4. Log out

using Bank1;
while (true)
{
    Console.WriteLine("1. Create new bank account\n2. Login");
    if (int.TryParse(Console.ReadLine(), out int c))
    {
        switch (c)
        {
            case 1:
                Console.Clear();
                Account.CreateAccount();
                break;
            default: break;
        }
    }
    else
    {
        Console.WriteLine("Invalid Input");
    }
}
