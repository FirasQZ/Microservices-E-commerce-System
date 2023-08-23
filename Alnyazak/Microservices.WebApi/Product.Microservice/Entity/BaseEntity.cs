namespace Product.Microservice.Entity
{
    public class BaseEntity:ParentEntity
    {
        public string createdBy { get; set; }
        public string createdAt { get; set; }
        public string updatedBy { get; set; }
        public string updatedAt { get; set; }
    }
}
