
public interface IPayment
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of ${amount}");
    }
}

public class PayPalPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
    }
}

public class CryptoPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing Crypto payment of ${amount}");
    }
}