using System.Text.Json;
namespace Bankinsystme;

public class CustomerController
{
    public void CreateCustomer()
    {
        int customerId = 1;
        bool truehai = true;
        Console.WriteLine("Enter Your Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter The Amount you would like to start with");
        decimal balance = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter Your Contact Number");
        string contactNumber = Console.ReadLine();
        Console.WriteLine("Enter your address");
        string address =  Console.ReadLine();
        
        

        Customer customer = new Customer()
        {
            CustomerId = customerId,
            Name = name,
            Balance = balance,
            IsActive = truehai,
            Contact = new ContactDetails()
            {
                ContactNumber = contactNumber,
                Address = address,
            }
        };

        WriteJsonData(customer);
    }

    public void Deposit()
    {
        Console.WriteLine("Enter Your CustomerId");
        int customerId =Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter THe Amount you want to deposit");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
        var customer = ReadJsonData(customerId);
        if (customer.IsActive)
        {
            customer.Balance += depositAmount;
            WriteJsonData(customer);
        }
        else
        {
            Console.WriteLine("Sorry! Your Account was deleted");
        }
        WriteJsonData(customer);
        
    }

    public void checkBalance()
    {
        Console.WriteLine("Enter Your CustomerId");
        int customerId =Convert.ToInt32(Console.ReadLine());
        var customer = ReadJsonData(customerId);
        if (customer.IsActive)
        {
            Console.WriteLine("Your Current Balance is :{0}",customer.Balance);
        }
        else
        {
            Console.WriteLine("Sorry! Your Account was deleted");
        }
        WriteJsonData(customer);

    }

    public void Withdraw()
    {
        Console.WriteLine("Enter Your CustomerId");
        int customerId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the Amount you want to Withdraw");
        decimal withdrawalmoney = Convert.ToDecimal(Console.ReadLine());
        var customer = ReadJsonData(customerId);
        if (customer.IsActive)
        {
            if (withdrawalmoney > customer.Balance)
            {
                Console.WriteLine("Insufficient Balance, enter Amount Less than {0}", customer.Balance);
            }
            else
            {
                customer.Balance -= withdrawalmoney;
                Console.WriteLine("Please Collect Your Amount");
            }
        }
        else
        {
            Console.WriteLine("Sorry! Your Account was deleted");
        }
        WriteJsonData(customer);

    }

    public void DeleteId()
    {
        Console.WriteLine("Enter Your CustomerId");
        int customerId =Convert.ToInt32(Console.ReadLine());
        var customer = ReadJsonData(customerId);
        customer.IsActive = false;
        Console.WriteLine("Your Account has been Deleted");
        WriteJsonData(customer);

    }

    private void WriteJsonData(Customer customer)
    {
        var jsonString = JsonSerializer.Serialize(customer);
        File.WriteAllText(@"C:\Users\parsh\Documents\Projects\matrixaddition\Accounts\"+customer.CustomerId+".json", jsonString);
    }

    private Customer ReadJsonData(int customerId)
    {
        var fileData = File.ReadAllText(@"C:\Users\parsh\Documents\Projects\matrixaddition\Accounts\"+customerId+".json");
        var customer = JsonSerializer.Deserialize<Customer>(fileData);
        return customer;
    }
}