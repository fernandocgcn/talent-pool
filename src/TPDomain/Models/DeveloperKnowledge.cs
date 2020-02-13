using EntityFramework.Resources;
using TPDomain.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace TPDomain.Models
{
    public class DeveloperKnowledge
    {
        public int DeveloperKnowledgeId { get; set; }

        [Display(Name = nameof(Rate), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public short? Rate { get; set; }

        [Display(Name = nameof(Developer), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Developer Developer { get; set; }

        [Display(Name = nameof(Knowledge), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
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
