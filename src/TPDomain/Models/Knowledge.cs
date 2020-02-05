using System;

namespace TPDomain.Models
{
    public class Knowledge
    {
        public int KnowledgeId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Knowledge knowledge &&
                   KnowledgeId == knowledge.KnowledgeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KnowledgeId);
        }
    }
}
