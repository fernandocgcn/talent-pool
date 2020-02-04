using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_availability", Schema = "dbo")]
    public class Availability
    {
        [Key]
        [Column("ava_id")]
        public int AvailabilityId { get; set; }

        [Column("ava_description")]
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Availability availability &&
                   AvailabilityId == availability.AvailabilityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AvailabilityId);
        }
    }
}
