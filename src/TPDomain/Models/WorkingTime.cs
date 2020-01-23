using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_working_time")]
    public class WorkingTime
    {
        [Key]
        [Column("wot_id")]
        public int WorkingTimeId { get; set; }

        [Column("wot_description")]
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WorkingTime time &&
                   WorkingTimeId == time.WorkingTimeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WorkingTimeId);
        }
    }
}
