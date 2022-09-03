using System;

namespace DW.Domain.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationDocument { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DisplayExpression { get; set; }
    }
}
