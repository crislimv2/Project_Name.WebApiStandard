namespace Project_Name.Entities.EntityDescriptors
{
    public interface IHaveCreateOnlyAudit
    {
        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
    }
}
