using PaymentApi.Models;
using System;

namespace PaymentApi.Data
{
    public class SqlPaymentRepository : IPaymentRepository
    {
       
        private PaymentContext _context;

        public SqlPaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public Payment PersistPayment(Payment payment)
        {
            var card = payment.Cartao;       
            _context.Cards.Add(card);

            _context.Payments.Add(payment);

            return payment;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}