public enum PaymentMethod
{
    CreditCard,
    PayPal,
    Crypto
}

public static class PaymentFactory
{
    public static IPayment CreatePayment(PaymentMethod method)
    {
        return method switch
        {
            PaymentMethod.CreditCard => new CreditCardPayment(),
            PaymentMethod.PayPal => new PayPalPayment(),
            PaymentMethod.Crypto => new CryptoPayment(),
            _ => throw new ArgumentException("Unsupported payment method")
        };
    }
}
