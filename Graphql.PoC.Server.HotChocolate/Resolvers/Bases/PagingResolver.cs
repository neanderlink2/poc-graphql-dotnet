using Graphql.PoC.Server.Infra.Context;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.Bases
{
    public abstract class PagingResolver<TEntity>
         where TEntity : class
    {
        [UseDbContext(typeof(InMemoryContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TEntity> GetAll([ScopedService] InMemoryContext dbContext) =>
            dbContext.Set<TEntity>();

        [UseDbContext(typeof(InMemoryContext))]
        [UseFirstOrDefault]
        [UseProjection]
        [UseFiltering]
        public virtual IEnumerable<TEntity> FindOne([ScopedService] InMemoryContext dbContext) =>
            dbContext.Set<TEntity>();
    }
}
