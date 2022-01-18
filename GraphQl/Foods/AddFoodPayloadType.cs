using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Foods
{
    public class AddFoodPayloadType : ObjectType<AddFoodPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddFoodPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added food.");

            descriptor
                .Field(p => p.food)
                .Description("Represents the added food.");

            base.Configure(descriptor);
        }
    }
}