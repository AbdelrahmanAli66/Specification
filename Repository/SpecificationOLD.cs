using System.Linq.Expressions;

namespace Repository
{
    public abstract class SpecificationOLD<T> where T : class
    {
        protected SpecificationOLD(Expression<Func<T, bool>> criteria) => Criteria = criteria;
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includeExpression) => IncludeExpressions.Add(includeExpression);
        public SpecificationOLD<T> And(SpecificationOLD<T> rightSpecification)
        {
            return new AndSpecificationOLD<T>(this, rightSpecification);
        }
        public SpecificationOLD<T> Or(SpecificationOLD<T> rightSpecification)
        {
            return new OrSpecificationOLD<T>(this, rightSpecification);
        }
        public SpecificationOLD<T> Not()
        {
            return new NotSpecificationOLD<T>(this);
        }
    }
    internal sealed class AndSpecificationOLD<T> : SpecificationOLD<T> where T : class
    {
        public AndSpecificationOLD(SpecificationOLD<T> left, SpecificationOLD<T> right) :
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
    internal sealed class OrSpecificationOLD<T> : SpecificationOLD<T> where T : class
    {
        public OrSpecificationOLD(SpecificationOLD<T> left, SpecificationOLD<T> right) :
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
    internal sealed class NotSpecificationOLD<T> : SpecificationOLD<T> where T : class
    {
        public NotSpecificationOLD(SpecificationOLD<T> operation) :
            base(Expression.Lambda<Func<T, bool>>(Expression.Not(
                operation.Criteria.Body), // Invoking right criteria with parameters of left criteria
                operation.Criteria.Parameters))
        {
        }

    }
}
