using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorCrud.Server.DataAccess
{
    public interface IEntityRepository :IDisposable
    {
        /// <summary>
        ///  Returns a queryable data source for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of entity to query</typeparam>
        /// <returns>An instance of <see cref="System.Linq.IQueryable"/> of <typeparamref name="T"/>.</returns>
        IQueryable<T> Query<T>() where T : class;

        /// <summary>
        /// Asynchronously finds a list of entities using a custom expression, or the entire unfiltered list
        /// if no expression is provided.
        /// </summary>
        /// <typeparam name="T">Type of entity to find</typeparam>
        /// <param name="predicate">Optional predicate to find the entity with</param>
        /// <returns>A list of objects of type <typeparamref name="T"/>.</returns>
        Task<IList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        /// <summary>
        /// Asychronously finds a single entity by its primary key.
        /// </summary>
        /// <typeparam name="T">Type of entity to find</typeparam>
        /// <param name="id">Primary key value(s) for the entity</param>
        /// <returns>A task returning an object of <typeparamref name="T"/> or null if not found.</returns>
        Task<T> FindAsync<T>(params object[] id)
            where T : class;

        /// <summary>
        /// Asynchronously finds an entity using a custom expression.
        /// </summary>
        /// <typeparam name="T">Type of entity to find</typeparam>
        /// <param name="predicate">Predicate to find the enitity with</param>
        /// <returns>An object of type <typeparamref name="T"/> or <c>null</c>.</returns>
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;
    }
}
