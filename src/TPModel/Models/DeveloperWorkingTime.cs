using EntityFramework.Resources;
using TPModel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPModel.Models
{
    public class DeveloperWorkingTime
    {
        [Display(Name = nameof(Developer), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public Developer Developer { get; set; }

        [Display(Name = nameof(WorkingTime), ResourceType = typeof(Labels))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(DataMessages))]
        public WorkingTime WorkingTime { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DeveloperWorkingTime time &&
                   EqualityComparer<Developer>.Default.Equals(Developer, time.Developer) &&
                   EqualityComparer<WorkingTime>.Default.Equals(WorkingTime, time.WorkingTime);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Developer, WorkingTime);
        }
    }
}
