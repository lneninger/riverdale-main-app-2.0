namespace DomainModel.Product
{
    public class FlowerProductCategoryGrade : AbstractBaseEntity
    {
        public FlowerProductCategoryGrade(): base()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FlowerProductCategoryId { get; set; }
        public FlowerProductCategory FlowerProductCategory { get; set; }
    }
}