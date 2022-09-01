namespace DW.Domain.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; internal set; }
        public int ProductId { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal SubTotal { get; internal set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
