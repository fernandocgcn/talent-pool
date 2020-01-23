using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_developer_availability")]
    public class DeveloperAvailability
    {
        [Column("dev_id")]
        public int DeveloperId { get; set; }

        [Column("ava_id")]
        public int AvailabilityId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperAvailability availability &&
                   DeveloperId == availability.DeveloperId &&
                   AvailabilityId == availability.AvailabilityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeveloperId, AvailabilityId);
        }
    }
}
