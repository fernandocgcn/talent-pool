using EntityFramework.Resources;
using TPModel.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace TPModel.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }

        [Display(Name = nameof(Email), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Email { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Name { get; set; }

        [Display(Name = nameof(City), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string City { get; set; }

        [Display(Name = nameof(State), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string State { get; set; }

        [Display(Name = nameof(Skype), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Skype { get; set; }

        [Display(Name = nameof(Whatsapp), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public string Whatsapp { get; set; }

        [Display(Name = nameof(Salary), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        [Range(1, double.MaxValue, ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public decimal Salary { get; set; }

        [Display(Name = nameof(LinkedIn), ResourceType = typeof(Labels))]
        public string LinkedIn { get; set; }

        [Display(Name = nameof(Portfolio), ResourceType = typeof(Labels))]
        public string Portfolio { get; set; }

        [Display(Name = nameof(ExtraKnowledge), ResourceType = typeof(Labels))]
        public string ExtraKnowledge { get; set; }

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
