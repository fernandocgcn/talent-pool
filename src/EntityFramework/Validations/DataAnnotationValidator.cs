using Kernel.Extensions;
using Kernel.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Validations
{
    public class DataAnnotationValidator : IDataAnnotationValidator
    {
        public void Validate<T>(T entity)
        {
            Validate(new EntityValidator<T>().Validate(entity));
        }
        
        public void Validate<T>(T entity, bool include, params string[] properties)
        {
            Validate(new EntityValidator<T>().Validate(entity, include, properties));
        }

        private void Validate(EntityValidationResult validationResult)
        {
            if (validationResult.HasError)
            {
                string errorMessage = "";
                foreach (var error in validationResult.ValidationErrors)
                {
                    if (!string.IsNullOrEmpty(errorMessage))
                        errorMessage += Environment.NewLine;
                    errorMessage += typeof(DataMessages).GetMessage(error.ErrorMessage);
                }
                throw new ValidationException(errorMessage);
            }
        }
    }
}
