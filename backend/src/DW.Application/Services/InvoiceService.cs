using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDto> GetInvoice(int invoiceId)
        {
            await CheckIfInvoiceExists(invoiceId);

            var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(invoiceId);
            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return invoiceDto;
        }

        public async Task<IEnumerable<InvoiceDto>> GetInvoices()
        {
            var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync();
            var invoicesDto = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            return invoicesDto;
        }

        public async Task<InvoiceDto> AddInvoice(InvoiceDto invoiceDto)
        {
            CheckInvoiceDetails(invoiceDto);

            var invoice = _mapper.Map<Invoice>(invoiceDto)
                .WithInvoiceNumber(await GetLastInvoice())
                .WithCurrentDate();

            UpdateStock(invoice.InvoiceDetails);

            await _unitOfWork.InvoiceRepository.AddAsync(invoice);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task UpdateInvoice(InvoiceDto invoiceDto)
        {
            await CheckIfInvoiceExists(invoiceDto.Id);

            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _unitOfWork.InvoiceRepository.UpdateAsync(invoice);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteInvoice(int invoiceId)
        {
            await CheckIfInvoiceExists(invoiceId);

            var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(invoiceId);
            await _unitOfWork.InvoiceRepository.DeleteAsync(invoice);
            await _unitOfWork.SaveAsync();
        }

        private async Task CheckIfInvoiceExists(int invoiceId)
        {
            var exists = await _unitOfWork.InvoiceRepository.ExistAsync(x => x.Id == invoiceId);

            if (!exists)
                throw new NotFoundException("La Factura seleccionada no existe");
        }

        private void CheckInvoiceDetails(InvoiceDto invoice)
        {
            if (invoice.InvoiceDetails == null || invoice.InvoiceDetails.Count == 0)
                throw new NotFoundException("No se puede crear la Factura porque no tiene ningún producto");
        }

        private async Task<Invoice> GetLastInvoice()
        {
            var lastInvoice = (await _unitOfWork.InvoiceRepository.GetAllAsync())
                .OrderByDescending(x => x.Num)
                .FirstOrDefault();

            return lastInvoice;
        }

        private void UpdateStock(ICollection<InvoiceDetail> invoiceDetails)
        {
            foreach (var detail in invoiceDetails)
            {
                detail.Product.SubtractStock(detail.Quantity);
            }
        }
    }
}
