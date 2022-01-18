using FoodBotGqlApi.Models;
using HotChocolate;
using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl
{
    /// <summary>
    /// Represents the subscriptions available.
    /// </summary>
    [GraphQLDescription("Represents the queries available.")]
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="Food"/>.
        /// </summary>
        /// <param name="food">The <see cref="Food"/>.</param>
        /// <returns>The added <see cref="Food"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added food.")]
        public Food OnFoodAdded([EventMessage] Food food)
        {
            return food;
        }
    }
}