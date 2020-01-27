using EntityFramework.Resources;
using TPDomain.Resources;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeveloperId { get; set; }

        [Column("dev_email")]
        [Display(Name = nameof(Email), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Email { get; set; }

        [Column("dev_name")]
        [Display(Name = nameof(Name), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Name { get; set; }

        [Column("dev_city")]
        [Display(Name = nameof(City), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string City { get; set; }

        [Column("dev_state")]
        [Display(Name = nameof(State), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string State { get; set; }

        [Column("dev_skype")]
        [Display(Name = nameof(Skype), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Skype { get; set; }

        [Column("dev_whatsapp")]
        [Display(Name = nameof(Whatsapp), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Whatsapp { get; set; }

        [Column("dev_salary")]
        [Display(Name = nameof(Salary), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        [Range(1, double.MaxValue, ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public decimal Salary { get; set; }

        [Column("dev_linkedin")]
        [Display(Name = nameof(LinkedIn), ResourceType = typeof(Labels))]
        public string LinkedIn { get; set; }

        [Column("dev_portfolio")]
        [Display(Name = nameof(Portfolio), ResourceType = typeof(Labels))]
        public string Portfolio { get; set; }

        [Column("dev_extra_knowledge")]
        [Display(Name = nameof(ExtraKnowledge), ResourceType = typeof(Labels))]
        public string ExtraKnowledge { get; set; }

        [Column("dev_crud_link")]
        [Display(Name = nameof(CrudLink), ResourceType = typeof(Labels))]
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
