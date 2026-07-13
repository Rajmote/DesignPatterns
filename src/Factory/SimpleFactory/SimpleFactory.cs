namespace DesignPatterns.Factory;

public class SimpleFactory
{
    public void Run()
    {
        // The client only interacts with the Factory and the Interface
        PaymentMethod userSelection = PaymentMethod.PayPal;

        IPayment paymentProcessor = PaymentFactory.CreatePayment(userSelection);
        paymentProcessor.Pay(150.00m);

        // Output: Processing PayPal payment of $150

    }
}
