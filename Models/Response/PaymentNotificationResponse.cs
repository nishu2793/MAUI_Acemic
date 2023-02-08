namespace AceMicEV.Models.Response

{
    public class PaymentNotificationResponse 
    {
        public string Status { get; set; }

        public string OrderId { get; set; }

        public string PaymentId { get; set; }

        public string Amount { get; set; }

        public string Email { get; set; }

        public string Paymentorderid { get; set; }

    }
}