namespace Laroche.FleetManager.Domain.BaseObjects
{
    /// <summary>
    /// Base Auditable Entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
        /// <summary>
        /// Date of last update
        /// </summary>
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
