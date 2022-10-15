namespace Framework.Core.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}