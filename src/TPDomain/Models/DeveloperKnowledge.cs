using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace TPDomain.Models
{
    [Table("tb_developer_knowledge")]
    public class DeveloperKnowledge
    {
        [Key]
        [Column("dek_id")]
        public int DeveloperKnowledgeId { get; set; }

        [Column("dek_rate")]
        public short Rate { get; set; }

        [Column("dev_id")]
        public int DeveloperId { get; set; }

        [Column("kno_id")]
        public int KnowledgeId { get; set; }

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
