namespace Laroche.FleetManager.Domain.BaseObjects
{
    /// <summary>
    /// Base Auditable Entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
        /// <summary>
        /// Date of last update
        /// </summary>
        public DateTimeOffset UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string? CreatedBy { get; set; }
    }
}
