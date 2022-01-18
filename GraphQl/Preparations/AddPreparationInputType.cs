using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Preparations
{
    public class AddPreparationInputType : InputObjectType<AddPreparationInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddPreparationInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a preparation.");

            descriptor
                .Field(c => c.Steps)
                .Description("Represents the how-to for the food.");
            descriptor
                .Field(c => c.foodId)
                .Description("Represents the unique ID of the food which the preparation belongs.");

            base.Configure(descriptor);
        }
    };
}