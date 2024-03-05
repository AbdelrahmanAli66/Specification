using System.Linq.Expressions;

namespace Repository
{
    public abstract class Specification<T> where T : class
    {
        protected Specification(Expression<Func<T, bool>> criteria) => Criteria = criteria;
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includeExpression) => IncludeExpressions.Add(includeExpression);
        public Specification<T> And(Specification<T> rightSpecification)
        {
            return new AndSpecification<T>(this, rightSpecification);
        }
        public Specification<T> Or(Specification<T> rightSpecification)
        {
            return new OrSpecification<T>(this, rightSpecification);
        }
        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
    internal sealed class AndSpecification<T> : Specification<T> where T : class
    {
        public AndSpecification(Specification<T> left, Specification<T> right) :
            base(Expression.Lambda<Func<T, bool>>(Expression.AndAlso(
                left.Criteria.Body, // Accessing the body of the lambda expression
                Expression.Invoke(right.Criteria, left.Criteria.Parameters)), // Invoking right criteria with parameters of left criteria
                left.Criteria.Parameters))
        {
            //if (left.GetType().i!= right.GetType().BaseType)
            //{
            //    throw new ArgumentException("Specifications must be of the same type", nameof(right));
            //}
        }
    }
    internal sealed class OrSpecification<T> : Specification<T> where T : class
    {
        public OrSpecification(Specification<T> left, Specification<T> right) :
            base(Expression.Lambda<Func<T, bool>>(Expression.OrElse(
                left.Criteria.Body, // Accessing the body of the lambda expression
                Expression.Invoke(right.Criteria, left.Criteria.Parameters)), // Invoking right criteria with parameters of left criteria
                left.Criteria.Parameters))
        {
            //if (left.GetType() != right.GetType())
            //{
            //    throw new ArgumentException("Specifications must be of the same type", nameof(right));
            //}
        }
    }
    internal sealed class NotSpecification<T> : Specification<T> where T : class
    {
        public NotSpecification(Specification<T> operation) :
            base(Expression.Lambda<Func<T, bool>>(Expression.Not(
                operation.Criteria.Body), // Invoking right criteria with parameters of left criteria
                operation.Criteria.Parameters))
        {
        }

    }
}
