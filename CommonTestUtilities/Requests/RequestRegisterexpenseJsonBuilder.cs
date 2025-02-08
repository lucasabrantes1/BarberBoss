using Bogus;
using BarberBoss.Communication.Enum;
using BarberBoss.Communication.Requests;

namespace CommonTestUtilities.Requests;
public  class RequestRegisterexpenseJsonBuilder
{
    public static RequestInvoicingJson Build()
    {

        return new Faker<RequestInvoicingJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
