using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Foods
{
    public class AddFoodInputType : InputObjectType<AddFoodInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddFoodInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a food.");

            descriptor
                .Field(p => p.NameOfFood)
                .Description("Represents the name for the food.");

            base.Configure(descriptor);
        }
    }
}