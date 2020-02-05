using System;

namespace TPDomain.Models
{
    public class DeveloperKnowledge
    {
        public int DeveloperKnowledgeId { get; set; }

        public short Rate { get; set; }

        public Developer Developer { get; set; }

        public Knowledge Knowledge { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperKnowledge knowledge &&
                   DeveloperKnowledgeId == knowledge.DeveloperKnowledgeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeveloperKnowledgeId);
        }
    }
}
