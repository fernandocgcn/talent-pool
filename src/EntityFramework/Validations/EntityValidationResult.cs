using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Validations
{
    [Serializable]
    internal class EntityValidationResult
    {
        public IList<ValidationResult> ValidationErrors { get; private set; }

        public bool HasError
        {
            get { return ValidationErrors.Count > 0; }
        }

        public EntityValidationResult(IList<ValidationResult> violations = null)
        {
            ValidationErrors = violations ?? new List<ValidationResult>();
        }
    }
}
