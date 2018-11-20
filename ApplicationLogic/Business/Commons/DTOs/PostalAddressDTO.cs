using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Business.Commons.DTOs
{
    public class PostalAddressDTO
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string AddressLine { get; set; }
        public string AddressNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
