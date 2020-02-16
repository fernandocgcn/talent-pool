using Common.Resources;
using TPModel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPModel.Models
{
    public class DeveloperAvailability
    {
        [Display(Name = nameof(Developer), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Developer Developer { get; set; }

        [Display(Name = nameof(Availability), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Availability Availability { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperAvailability availability &&
                   EqualityComparer<Developer>.Default.Equals(Developer, availability.Developer) &&
                   EqualityComparer<Availability>.Default.Equals(Availability, availability.Availability);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Developer, Availability);
        }
    }
}
