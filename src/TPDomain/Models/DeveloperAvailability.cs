using System;
using System.Collections.Generic;

namespace TPDomain.Models
{
    public class DeveloperAvailability
    {
        public Developer Developer { get; set; }

        public Availability Availability { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperAvailability availability &&
                   EqualityComparer<Developer>.Default.Equals(Developer, availability.Developer) &&
                   EqualityComparer<Availability>.Default.Equals(Availability, availability.Availability);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Developer, Availability);
        }
    }
}
