using System.Linq;
using FoodBotGqlApi.Data;
using FoodBotGqlApi.Models;
using HotChocolate;
using HotChocolate.Data;

namespace FoodBotGqlApi.GraphQl
{
    /// <summary>
    /// Represents the queries available.
    /// </summary>
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        /// <summary>
        /// Gets the queryable <see cref="Food"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Food"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable food.")]
        public IQueryable<Food> GetFood([ScopedService] AppDbContext context)
        {
            return context.Foods;
        }

        /// <summary>
        /// Gets the queryable <see cref="Preparation"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Preparation"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable preparation.")]
        public IQueryable<Preparation> GetPreparations([ScopedService] AppDbContext context)
        {
            return context.Preparations;
        }
    }
}