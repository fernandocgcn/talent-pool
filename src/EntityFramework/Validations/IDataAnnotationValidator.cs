namespace EntityFramework.Validations
{
    public interface IDataAnnotationValidator
    {
        void Validate<T>(T entity);

        void Validate<T>(T entity, bool include, params string[] properties);
    }
}
