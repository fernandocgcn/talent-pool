using System;

namespace TPDomain.Models
{
    public class WorkingTime
    {
        public int WorkingTimeId { get; set; }

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
