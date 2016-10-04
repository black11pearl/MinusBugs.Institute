using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class FeeDbOperations
    {
        MinusBugsContext mbc;
        public FeeSchedule AddFeeSchedule(FeeSchedule feeschedule)
        {
            mbc = new MinusBugsContext();
            FeeSchedule feesch = mbc.FeeScheduleData.Add(feeschedule);
            mbc.SaveChanges();

            return feeschedule;

        }
        public string MakeANewPayment(PaymentDetails paydetails)
        {
            string paymentId; ;
            try
            {

                mbc = new MinusBugsContext();
                mbc.PaymentData.Add(paydetails);
                mbc.SaveChanges();
                paymentId = paydetails.PaymentId.ToString() ;
            }
            catch (Exception)
            {

                throw;
            }
            return paymentId;
           
        }

        public PaymentDetails GetPaymentDetails(int paymentid)
        {
            mbc = new MinusBugsContext();
            PaymentDetails pd = mbc.PaymentData.Single(p => p.PaymentId == paymentid);

            return pd;

        }
    }
}