using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Country
    {
        public int Id { get; set; }

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        public string Name { get; set; }
    }
}
