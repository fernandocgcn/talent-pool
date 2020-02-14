using System.Collections.Generic;

namespace TPModel.Models
{
    public class DeveloperDto
    {
        public Developer Developer { get; set; }
        public ICollection<Availability> Availabilities { get; set; }
        public ICollection<WorkingTime> WorkingTimes { get; set; }
        public ICollection<KnowledgeDto> KnowledgeDtos { get; set; }
    }
}
