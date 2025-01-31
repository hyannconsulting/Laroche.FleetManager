namespace Laroche.FleetManager.Domain.BaseObjects
{
    public abstract class BaseAuditableEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }


    }
}
