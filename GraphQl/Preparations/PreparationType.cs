using System.Linq;
using FoodBotGqlApi.Data;
using FoodBotGqlApi.Models;
using HotChocolate;
using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Preparations
{
    public class PreparationType : ObjectType<Preparation>
    {
        protected override void Configure(IObjectTypeDescriptor<Preparation> descriptor)
        {
            descriptor.Description("Represents the preparation steps for any meal");

            descriptor
                .Field(c => c.Id)
                .Description("Represents the unique ID for the preparation.");

            descriptor
                .Field(c => c.Steps)
                .Description("Represents the how-to for the food.");

            descriptor
                .Field(c => c.FoodId)
                .Description("Represents the unique ID of the food which the preparation belongs.");

            descriptor
                .Field(p => p.Food)
                .ResolveWith<Resolvers>(p => p.GetFood(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the food to which the preparation belongs");
        }

        private class Resolvers
        {
            public Food GetFood([Parent] Preparation preparation, [ScopedService] AppDbContext context)
            {
                return context.Foods.FirstOrDefault(p => p.Id == preparation.FoodId);
            }
        }
    }
}