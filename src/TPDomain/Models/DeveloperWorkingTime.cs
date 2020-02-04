using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_developer_working_time", Schema = "dbo")]
    public class DeveloperWorkingTime
    {
        [Column("dev_id")]
        public int DeveloperId { get; set; }

        [Column("wot_id")]
        public int WorkingTimeId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperAvailability availability &&
                   DeveloperId == availability.DeveloperId &&
                   WorkingTimeId == availability.AvailabilityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeveloperId, WorkingTimeId);
        }
    }
}
