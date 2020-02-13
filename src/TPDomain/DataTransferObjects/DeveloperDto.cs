using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.DataTransferObjects
{
    public class DeveloperDto
    {
        public Developer Developer { get; set; }
        public ICollection<Availability> Availabilities { get; set; }
        public ICollection<WorkingTime> WorkingTimes { get; set; }
        public ICollection<Knowledge> Knowledges { get; set; }
    }
}
