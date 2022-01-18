using System.Threading;
using System.Threading.Tasks;
using FoodBotGqlApi.Data;
using FoodBotGqlApi.GraphQl.Foods;
using FoodBotGqlApi.GraphQl.Preparations;
using FoodBotGqlApi.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace FoodBotGqlApi.GraphQl.Mutation
{
    /// <summary>
    /// Represents the mutations available.
    /// </summary>
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        /// <summary>
        /// Adds a <see cref="Food"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddFoodInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <param name="eventSender">The <see cref="ITopicEventSender"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The added <see cref="Food"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a Food.")]
        public async Task<AddFoodPayload> AddFoodAsync(AddFoodInput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var food = new Food{
                NameOfFood = input.NameOfFood,
                Ingredients = input.Ingredients
            };

            context.Foods.Add(food);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnFoodAdded), food, cancellationToken);

            return new AddFoodPayload(food);
        }

        /// <summary>
        /// Adds a <see cref="Preparation"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddPreparationInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The added <see cref="Preparation"/>.</returns>
        [GraphQLDescription("Adds a Preparation.")]
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPreparationPayload> AddPreparationsAsync(AddPreparationInput input, [ScopedService] AppDbContext context)
        {
            var preparation = new Preparation{
                Steps = input.Steps,
                FoodId = input.foodId
            };

            context.Preparations.Add(preparation);
            await context.SaveChangesAsync();

            return new AddPreparationPayload(preparation);
        }
    }
}