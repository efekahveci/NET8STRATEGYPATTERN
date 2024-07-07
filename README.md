# Payment Processing Strategy Pattern Example

This C# console application demonstrates the Strategy design pattern to process payments using different strategies: Credit Card, PayPal, and Mobile payments.

## Features

- **Strategy Pattern**: Switch between Credit Card, PayPal, and Mobile payment methods.
- **Immutable Model**: Ensures payment details remain unchanged.
- **User Interaction**: Select payment method during runtime.
- **Extensible**: Easily add new payment strategies.

## Usage

1. Run the application:
    ```bash
    dotnet run
    ```

2. Select a payment strategy:
    - `1`: Credit Card
    - `2`: PayPal
    - `3`: Mobile

3. Process the payment and see the result.

## Code Structure

- `PaymentOptions`: Immutable record for payment details.
- `IPaymentStrategy`: Interface for payment methods.
- `CreditCardPaymentStrategy`, `PayPalPaymentStrategy`, `MobilePaymentStrategy`: Implementations of payment strategies.
- `PaymentProcessor`: Processes payments using the selected strategy.

## License

This project is licensed under the MIT License.
