using Kernel.Extensions;
using EntityFramework.Resources;
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
                    errorMessage += typeof(DataMessages).GetMessage(error.ErrorMessage) + Environment.NewLine;
                }
                throw new ValidationException(errorMessage);
            }
        }
    }
}
