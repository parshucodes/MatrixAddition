namespace Bankinsystme;

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }
    public ContactDetails Contact { get; set; }
}

public class ContactDetails
{
    public string ContactNumber { get; set; }
    public string Address { get; set; }
}