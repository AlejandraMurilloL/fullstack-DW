using System;
using System.Collections.Generic;

namespace DW.Domain.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Num { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public CustomerDto Customer { get; set; }
        public ICollection<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
