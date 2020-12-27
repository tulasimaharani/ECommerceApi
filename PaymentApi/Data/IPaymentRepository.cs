using PaymentApi.Models;

namespace PaymentApi.Data
{
    public interface IPaymentRepository
    {
        Payment PersistPayment(Payment payment);
        bool SaveChanges();
    }
}