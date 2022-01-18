using System.Linq;
using FoodBotGqlApi.Data;
using FoodBotGqlApi.Models;
using HotChocolate;
using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Foods
{
    public class FoodType : ObjectType<Food>
    {
        protected override void Configure(IObjectTypeDescriptor<Food> descriptor)
        {
            descriptor.Description("Represents name of foods that needs to have its method of preparation explained");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the food.");

            descriptor
                .Field(p => p.NameOfFood)
                .Description("Represents the name for the food.");

            descriptor
                .Field(p => p.OwnerName).Ignore();

            descriptor
                .Field(p => p.Preparations)
                .ResolveWith<Resolvers>(p => p.GetPreparations(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available preparations for all foods");
        }

        private class Resolvers
        {
            public IQueryable<Preparation> GetPreparations([Parent] Food food, [ScopedService] AppDbContext context)
            {
                return context.Preparations.Where(p => p.FoodId == food.Id);
            }
        }
    }
}