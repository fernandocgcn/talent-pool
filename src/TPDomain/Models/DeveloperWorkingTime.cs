using System;
using System.Collections.Generic;

namespace TPDomain.Models
{
    public class DeveloperWorkingTime
    {
        public Developer Developer { get; set; }

        public WorkingTime WorkingTime { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperWorkingTime time &&
                   EqualityComparer<Developer>.Default.Equals(Developer, time.Developer) &&
                   EqualityComparer<WorkingTime>.Default.Equals(WorkingTime, time.WorkingTime);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Developer, WorkingTime);
        }
    }
}
