using DW.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Domain.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetInvoice(int invoiceId);
        Task<IEnumerable<InvoiceDto>> GetInvoices();
        Task<InvoiceDto> AddInvoice(InvoiceDto invoiceDto);
        Task UpdateInvoice(InvoiceDto cinvoiceDto);
        Task DeleteInvoice(int invoiceId);
    }
}
