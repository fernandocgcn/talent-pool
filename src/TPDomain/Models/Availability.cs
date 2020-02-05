using System;

namespace TPDomain.Models
{
    public class Availability
    {
        public int AvailabilityId { get; set; }

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
