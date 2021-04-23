using System;

namespace Server.Models
{
    [Serializable]
    public class OrderData
    {
        public string Id { get; set; }
        public string CreatedDate { get; set; }
        public string Sum { get; set; }
        public string Currency { get; set; }
        public StatusType PaidStatus { get; set; }
        public bool IsShipped { get; set; }

        public enum StatusType
        {
            NotPaid,
            Installment,
            Paid
        }
    }
}
