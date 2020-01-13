using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoPaymentFactory
    {
        public static KondutoCreditCardPayment CreateCreditCardPayment()
        {
            return new KondutoCreditCardPayment
            {
                Bin = "1234",
                ExpirationDate = "010214",
                Last4 = "1234",
                Status = KondutoCreditCardPaymentStatus.approved,
                Type = KondutoPaymentType.credit,
                Amount = 100.50,
                Description = "Test credit card payment"
            };
        }

        public static KondutoBoletoPayment CreateBoletoPayment() 
        {
            return new KondutoBoletoPayment
            {
                Type = KondutoPaymentType.boleto,
                ExpirationDate = "2015-01-01",
                Amount = 100.50,
                Description = "Test boleto payment"
            };
        }

        public static KondutoDebitPayment CreateDebitPayment()
        {
            return new KondutoDebitPayment
            {
                Type = KondutoPaymentType.debit,
                Amount = 100.50,
                Description = "Test debit payment"
            };
        }

        public static KondutoTransferPayment CreateTransferPayment()
        {
            return new KondutoTransferPayment
            {
                Type = KondutoPaymentType.transfer,
                Amount = 100.50,
                Description = "Test transfer payment"
            };
        }

        public static KondutoVoucherPayment CreateVoucherPayment()
        {
            return new KondutoVoucherPayment
            {
                Type = KondutoPaymentType.voucher,
                Amount = 100.50,
                Description = "Test voucher payment"
            };
        }

        public static List<KondutoPayment> CreatePayments()
        {
            return new List<KondutoPayment> { CreateCreditCardPayment() };
        }

        public static List<KondutoPayment> CreateNonCreditPayments()
        {
            return new List<KondutoPayment> { CreateBoletoPayment(), CreateDebitPayment(), CreateTransferPayment(), CreateVoucherPayment() };
        }
    }
}
