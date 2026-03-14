namespace lap5.Events
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; set; }

        public string OrderNumber { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerEmail { get; set; } = "";

        public decimal TotalAmount { get; set; }
    }
}
