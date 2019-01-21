using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Funza
{
    public class ColorReference : AbstractBaseEntity
    {
        public int Id { get; set; }
        public string FunzaId { get; set; }
       
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string State { get; set; }
        public string Version { get; set; }
        public string Hexagecimal { get; set; }
        public string Image { get; set; }

        public string FunzaCreatedBy { get; set; }
        public string FunzaCreatedDate { get; set; }
        public string FunzaUpdatedBy { get; set; }
        public string FunzaUpdatedDate { get; set; }
    }
}
