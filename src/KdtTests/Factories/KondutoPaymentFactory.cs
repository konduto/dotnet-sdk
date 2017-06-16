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
                Type = KondutoPaymentType.credit
            };
        }

        public static KondutoBoletoPayment CreateBoletoPayment() 
        {
            return new KondutoBoletoPayment
            {
                Type = KondutoPaymentType.boleto,
                ExpirationDate = "2015-01-01"
            };
        }

        public static KondutoDebitPayment CreateDebitPayment()
        {
            return new KondutoDebitPayment
            {
                Type = KondutoPaymentType.debit
            };
        }

        public static KondutoTransferPayment CreateTransferPayment()
        {
            return new KondutoTransferPayment
            {
                Type = KondutoPaymentType.transfer
            };
        }

        public static KondutoVoucherPayment CreateVoucherPayment()
        {
            return new KondutoVoucherPayment
            {
                Type = KondutoPaymentType.voucher
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
