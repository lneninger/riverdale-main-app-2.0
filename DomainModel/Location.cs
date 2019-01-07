using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Location
    {
        public int Id { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
