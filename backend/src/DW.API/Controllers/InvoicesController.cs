﻿using DW.Domain.DTOs;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> Get()
        {
            var result = await _invoiceService.GetInvoices();
            return Ok(result);
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDto>> Get(int invoiceId)
        {
            try
            {
                var result = await _invoiceService.GetInvoice(invoiceId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> Post([FromBody] InvoiceDto invoiceDto)
        {
            var result = await _invoiceService.AddInvoice(invoiceDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InvoiceDto invoiceDto)
        {
            try
            {
                await _invoiceService.UpdateInvoice(invoiceDto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> Delete(int invoiceId)
        {
            try
            {
                await _invoiceService.DeleteInvoice(invoiceId);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return StatusCode((int)HttpStatusCode.Conflict, e.Message);
            }            
        }
    }
}
