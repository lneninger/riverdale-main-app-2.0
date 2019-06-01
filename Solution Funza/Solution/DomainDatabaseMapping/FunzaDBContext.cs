using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping
{
    public class FunzaDBContext: DbContext
    {
        public DbSet<Quote> Quotes { get; set; }

    }
}
