using Framework.EF.DbContextImpl.Persistance;

namespace DomainModel.File
{
    public class FileSystemType: AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}