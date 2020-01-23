using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TPDomain.Models
{
    [Table("tb_developer")]
    public class Developer
    {
        [Key]
        [Column("dev_id")]
        public int DeveloperId { get; set; }

        [Column("dev_email")]
        public string Email { get; set; }

        [Column("dev_name")]
        public string Name { get; set; }

        [Column("dev_city")]
        public string City { get; set; }

        [Column("dev_state")]
        public string State { get; set; }

        [Column("dev_whatsapp")]
        public string Whatsapp { get; set; }

        [Column("dev_salary")]
        public decimal Salary { get; set; }

        [Column("dev_linkedin")]
        public decimal LinkedIn { get; set; }

        [Column("dev_portfolio")]
        public decimal Portfolio { get; set; }

        [Column("dev_extra_knowledge")]
        public string ExtraKnowledge { get; set; }

        [Column("dev_crud_link")]
        public string CrudLink { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Developer developer &&
                   DeveloperId == developer.DeveloperId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeveloperId);
        }
    }
}
