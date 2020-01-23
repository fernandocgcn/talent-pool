using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_knowledge")]
    public class Knowledge
    {
        [Key]
        [Column("kno_id")]
        public int KnowledgeId { get; set; }

        [Column("kno_name")]
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
