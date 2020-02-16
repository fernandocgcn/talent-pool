using Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntityFramework.Validations
{
    internal class EntityValidator<T>
    {
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();

            if (entity == null)
            {
                validationResults.Add(new ValidationResult(new NullReferenceException().Message));
            }
            else
            {
                var vc = new ValidationContext(entity, null, null);
                _ = Validator.TryValidateObject(entity, vc, validationResults, true);
            }

            return new EntityValidationResult(validationResults);
        }

        public EntityValidationResult Validate(T entity, bool include, string[] properties)
        {
            var validationResults = new List<ValidationResult>();

            if (entity == null)
            {
                validationResults.Add(new ValidationResult(new NullReferenceException().Message));
            }
            else
            {
                var vc = new ValidationContext(entity, null, null);

                foreach (PropertyInfo item in entity.GetType().GetProperties())
                {
                    if (properties.ValidateItem(item.Name, include))
                    {
                        object value = item.GetValue(entity);
                        vc.MemberName = item.Name;
                        _ = Validator.TryValidateProperty(value, vc, validationResults);
                    }
                }
            }

            return new EntityValidationResult(validationResults);
        }

        public EntityValidationResult Validate(T entity, Type attributeType)
        {
            var validationResults = new List<ValidationResult>();

            if (entity == null)
            {
                validationResults.Add(new ValidationResult(new NullReferenceException().Message));
            }
            else
            {
                var vc = new ValidationContext(entity, null, null);

                foreach (var item in entity.GetType().GetProperties())
                {
                    if (item.GetCustomAttribute(attributeType) != null)
                    {
                        vc.MemberName = item.Name;
                        _ = Validator.TryValidateProperty(item.GetValue(entity), vc, validationResults);
                    }
                }
            }

            return new EntityValidationResult(validationResults);
        }
    }
}
