using System.Text.Json;
using Bankinsystme;

namespace MatrixAddition;

class Program {
    static void Main(string[] args)
    { 
        CustomerController controller = new CustomerController();
        Console.WriteLine("Welcome to ABC Bank,\n Press 1. To  Create an Account.\n Press 2. To Deposit. \n Press 3. To Withdraw. Press 4. To Check Balance.\nPress 5. To Delete Account.");
        int n = Convert.ToInt32(Console.ReadLine());
        switch(n)
        {
            case 1:
                controller.CreateCustomer();
                break;
            case 2:
                controller.Deposit();
                break;
            case 3:
                controller.Withdraw();
                break;
            case 4:
                controller.checkBalance();
                break;
            case 5:
                controller.DeleteId();
                break;
            default:
                Console.WriteLine("Enter a valid number");
                break;
        }
        
        
        Console.Read();
    }  
}

