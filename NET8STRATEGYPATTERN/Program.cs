// PaymentOptions nesnesi oluşturuluyor.
var paymentOptions = new PaymentOptions(
    CardNumber: "1234 5678 9012 3456",
    CardHolder: "John Doe",
    CardExpirationDate: "12/24",
    CardSecurityCode: "123",
    Amount: 100
);

var paymentProcessor = new PaymentProcessor(new CreditCardPaymentStrategy()); // Varsayılan olarak kredi kartı ödeme stratejisi kullanılıyor.

while (true) // Ödeme işlemi başarılı olana kadar döngüyü devam ettir
{
    Console.WriteLine("\nÖdeme yapılacak stratejiyi seçin (1: Kredi Kartı, 2: PayPal, 3:Mobil Esc: Çıkış): ");
    var keyInfo = Console.ReadKey();
    Console.WriteLine(); // Yeni satıra geç

    if (keyInfo.Key == ConsoleKey.Escape)
    {
        break; // Escape tuşuna basıldığında döngüden çık
    }

    if (keyInfo.KeyChar == '1')
    {
        // Kredi kartı ödeme stratejisi seçildi.
        paymentProcessor = new PaymentProcessor(new CreditCardPaymentStrategy());
    }
    else if (keyInfo.KeyChar == '2')
    {
        // PayPal ödeme stratejisi seçildi.
        paymentProcessor = new PaymentProcessor(new PayPalPaymentStrategy());
    }
    else if (keyInfo.KeyChar == '3')
    {
        // Mobil ödeme stratejisi seçildi.
        paymentProcessor = new PaymentProcessor(new MobilePaymentStrategy());
    }
    else
    {
        // Geçersiz strateji seçimi.
        Console.WriteLine("Geçersiz strateji seçimi.");
        continue;
    }

    // Ödeme işlemi gerçekleştiriliyor.
    paymentProcessor.ProcessPayment(paymentOptions);
}

// Ödeme seçeneklerini temsil eden sınıf, immutable veri modeli olarak tanımlanmıştır.
public record PaymentOptions(
    string CardNumber,
    string CardHolder,
    string CardExpirationDate,
    string CardSecurityCode,
    double Amount
);

// IPaymentStrategy interface'i, ödeme stratejilerini tanımlamak için kullanılır.
interface IPaymentStrategy
{
    bool Pay(PaymentOptions paymentOptions); // Ödeme işlemi gerçekleştiren metod
}

// Kredi kartı ödeme stratejisini temsil eden sınıf.
class CreditCardPaymentStrategy : IPaymentStrategy
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        // Kredi kartı ödemesi işleniyor...
        Console.WriteLine("Kredi kartı ödemesi işleniyor...");
        return true; // Ödeme işlemi başarılı olarak varsayılmıştır.
    }
}

// PayPal ödeme stratejisini temsil eden sınıf.
class PayPalPaymentStrategy : IPaymentStrategy
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        // PayPal ödemesi işleniyor...
        Console.WriteLine("PayPal ödemesi işleniyor...");
        return true; // Ödeme işlemi başarılı olarak varsayılmıştır.
    }
}

class MobilePaymentStrategy : IPaymentStrategy
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        // Mobil ödeme işleniyor...
        Console.WriteLine("Mobil ödeme işleniyor...");
        return true; // Ödeme işlemi başarılı olarak varsayılmıştır.
    }
}

// PaymentProcessor sınıfı, ödeme işlemlerini strateji deseni ile gerçekleştirmek için kullanılır.
class PaymentProcessor
{
    private readonly IPaymentStrategy _paymentStrategy;

    // Kurucu metot, bir ödeme stratejisi alır.
    public PaymentProcessor(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Ödeme işlemi gerçekleştiren metod.
    public void ProcessPayment(PaymentOptions paymentOptions)
    {
        if (_paymentStrategy.Pay(paymentOptions))
        {
            Console.WriteLine("Ödeme işlemi başarılı."); // Ödeme işlemi başarılı olduğunda.
        }
        else
        {
            Console.WriteLine("Ödeme işlemi başarısız."); // Ödeme işlemi başarısız olduğunda.
        }
    }
}
