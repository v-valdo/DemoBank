namespace Bank1;
public class Account
{
    private readonly int _id;
    public string firstname;
    private readonly string _surname;
    private int _balance;
    public string dateCreated = DateTime.Now.ToString();
    public static List<Account>? List = new List<Account>();
    private readonly string _password;

    public Account(int id, string Firstname, string Surname, int Balance, string Password)
    {
        _id = id;
        firstname = Firstname;
        _surname = Surname;
        _balance = Balance;
        _password = Password;
        List?.Add(this);
    }
    public static void CheckBalance(Account account)
    {
        Console.WriteLine("$" + account._balance);
    }

    public static void CreateAccount()
    {
        int AccountID = GenerateID();
        string firstname = string.Empty;
        string lastname = string.Empty;
        string password = string.Empty;


        while (true)
        {
            Console.Write("Firstname: ");

            firstname = Console.ReadLine();

            if (ValidFormat(firstname))
            {
                break;
            }
        }
        Console.Clear();
        while (true)
        {
            Console.Write("Last Name: ");

            lastname = Console.ReadLine();

            if (ValidFormat(lastname))
            {
                break;
            }
        }
        Console.Clear();
        while (true)
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (ValidFormat(password, true))
                {
                    break;
                }
            }
            Console.Clear();
            Console.Write("Enter password again: ");
            string? password2 = Console.ReadLine();
            if (password != password2)
            {
                Console.WriteLine("Passwords don't match");
            }
            else
            {
                break;
            }
        }
        Account newAccount = new Account(AccountID, firstname, lastname, 500, password);
        File.AppendAllTextAsync("../../../banklogin.csv", $"ACCOUNT ID: {AccountID}\nPASSWORD: {password}\nFIRST NAME: {firstname}\nLAST NAME: {lastname}\nDATE CREATED: {newAccount.dateCreated}\n***********\n");
        Console.WriteLine($"Account Created With ID {AccountID}!");
    }

    public static int GenerateID()
    {
        int index = 1000;
        string[] data = File.ReadAllLines("../../../banklogin.csv");
        for (int i = 0; i < data.Length; i += 6)
        {
            int findId = data[i].IndexOf(':') + 2;
            string accountId = data[i].Substring(findId);
            if (int.TryParse(accountId, out int id))
            {
                id++;
                index = id;
            }
            else
            {
                throw new Exception("ID not found");
            }
        }
        return index;
    }

    public static bool ValidFormat(string input)
    {
        if (input.Contains(' ') || !input.All(Char.IsLetter) || input == "")
        {
            Console.WriteLine("Invalid input. Letters only, no empty spaces");
            return false;
        }
        else if (input.Length == 1)
        {
            Console.WriteLine("Too short, 1 letter is not allowed");
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool ValidFormat(string input, bool IsPassword)
    {
        if (IsPassword)
        {
            if (input.Length < 8 || input.Contains(' '))
            {
                Console.WriteLine("Password must be more than 8 characters & cannot contain whitespaces");
                return false;
            }
            else if (!input.Any(Char.IsDigit))
            {
                Console.WriteLine("Password must contain at least one digit");
                return false;
            }
        }
        return true;
    }
}