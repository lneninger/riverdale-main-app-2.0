using DomainModel.File;
using System;

namespace DomainModel.Product
{
    public class ProductMedia : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public AbstractProduct Product { get; set; }

        public int FileRepositoryId { get; set; }

        public File.File FileRepository { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}