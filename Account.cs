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
        string[] data = File.ReadAllLines("../../../banklogin.csv");
        int findId = data[0].IndexOf(':') + 2;
        string accountId = data[0].Substring(findId);
        Console.WriteLine(accountId);

        int index;

        if (int.TryParse(accountId, out int id))
        {
            index = id;

            if (index == id)
            {
                index++;
            }
        }
        else
        {
            throw new Exception("ID not found");
        }

        Console.Write("Firstname: ");
        string firstname = Console.ReadLine();
        Console.Clear();
        Console.Write("Last Name: ");
        string lastname = Console.ReadLine();
        Console.Clear();
        string password = string.Empty;
        while (true)
        {
            Console.Clear();
            Console.Write("Password: ");
            password = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter password again: ");
            string password2 = Console.ReadLine();
            if (password != password2)
            {
                Console.WriteLine("Passwords don't match");
            }
            else
            {
                break;
            }
        }

        Account newAccount = new Account(index, firstname, lastname, 500, password);
        File.AppendAllTextAsync("../../../banklogin.csv", $"ACCOUNT ID: {index}\nPASSWORD: {password}\nFIRST NAME: {firstname}\nLAST NAME: {lastname}\nDATE CREATED: {newAccount.dateCreated}\n***********\n");
    }
}