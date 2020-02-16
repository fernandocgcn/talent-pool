using Common.Resources;
using TPModel.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TPModel.Models
{
    public class DeveloperKnowledge
    {
        [Display(Name = nameof(Developer), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Developer Developer { get; set; }

        [Display(Name = nameof(Knowledge), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Knowledge Knowledge { get; set; }

        [Display(Name = nameof(Rate), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public short? Rate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperKnowledge knowledge &&
                   EqualityComparer<Developer>.Default.Equals(Developer, knowledge.Developer) &&
                   EqualityComparer<Knowledge>.Default.Equals(Knowledge, knowledge.Knowledge);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Developer, Knowledge);
        }
    }
}
